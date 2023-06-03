using cev.api.Data;
using cev.api.Domain.Entidades;
using cev.api.Domain.Interfaces;
using cev.api.Domain.ModelsApi;
using cev.api.Domain.ModelsDb;
using cev.api.Uteis;
using cev.api.Uteis.Results;
using Flunt.Notifications;
using Microsoft.IdentityModel.Tokens;
using static cev.api.Uteis.Constantes;

namespace cev.api.Application
{
    public class VendaApplication : IVendaApplication
    {
        private readonly AppDbContext _appDbContext;

        public VendaApplication(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Result Excluir(int id)
        {
            var modelsDb = _appDbContext.Vendas.Where(v => v.IdVenda == id).ToList();

            if (!modelsDb.Any())
                return Result.Error(new Notification(nameof(id), Constantes.Vendas.VENDA_NAO_ENCONTRADA));

            _appDbContext.Vendas.RemoveRange(modelsDb);
            _appDbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<VendaLeitura> Inserir(VendaCriar vendaCriar)
        {
            var entidade = VendaCriarParaVenda(vendaCriar);

            if (entidade.Invalid)
                return Result<VendaLeitura>.Error(entidade.Notifications);

            var quantidadeErros = verificarQuantidadeProdutosDisponivel(vendaCriar.Produtos);
            if (quantidadeErros.Any())
                return Result<VendaLeitura>.Error(quantidadeErros);

            var modelsDb = VendaParaListVendaDb(entidade);

            foreach (var model in modelsDb)
            {
                _appDbContext.Vendas.Add(model);
                _appDbContext.SaveChanges();
            }

            BaixarEstoque(entidade.Produtos);

            return Result<VendaLeitura>.Ok(ListVendaDbParaVendaLeitura(modelsDb));
        }

        public Result<List<VendaLeitura>> Listar(string startDate, string endDate)
        {
            if (SomenteUmaData(startDate, endDate))
                return Result<List<VendaLeitura>>.Error(new Notification("Datas:", "Parametros incorretos!"));

            if (startDate.IsNullOrEmpty() && endDate.IsNullOrEmpty())
            {
                var modelsDbSemData = _appDbContext.Vendas.ToList();

                if (!modelsDbSemData.Any())
                    return Result<List<VendaLeitura>>.Error(new Notification(nameof(VendaLeitura), Constantes.Vendas.VENDA_NAO_ENCONTRADA));

                List<VendaLeitura> modelsLeituraSemData = ListVendaDbParaListVendaLeitura(modelsDbSemData);

                return Result<List<VendaLeitura>>.Ok(modelsLeituraSemData);
            }

            DateTime dataInicial = default;
            DateTime dataFinal = default;

            if (ValidarInvalidas(startDate, endDate, out dataInicial, out dataFinal))
                return Result<List<VendaLeitura>>.Error(new Notification("Datas:", "Valores incorretos!"));

            dataFinal = dataFinal.AddDays(1);

            var modelsDb = _appDbContext.Vendas.Where(v => v.DataVenda >= dataInicial &&  v.DataVenda <= dataFinal).ToList();

            if (!modelsDb.Any())
                return Result<List<VendaLeitura>>.Error(new Notification(nameof(VendaLeitura), Constantes.Vendas.VENDA_NAO_ENCONTRADA));

            List<VendaLeitura> modelsLeitura = ListVendaDbParaListVendaLeitura(modelsDb);

            return Result<List<VendaLeitura>>.Ok(modelsLeitura);
        }

        private bool ValidarInvalidas(string startDate, string endDate, out DateTime dataInicial, out DateTime dataFinal)
        {
            if (DateTime.TryParse(startDate, out dataInicial) && DateTime.TryParse(endDate, out dataFinal))
                return false;
            dataInicial = default;
            dataFinal = default;
            return true;
        }

        private bool SomenteUmaData(string startDate, string endDate)
        {
            if ((startDate == null && endDate != null) || (startDate != null && endDate == null))
                return true;
            return false;
        }

        public Result<VendaLeitura> RecuperarPorId(int id)
        {
            var modelsDb = _appDbContext.Vendas.Where(v => v.IdVenda == id).ToList();

            if (!modelsDb.Any())
                return Result<VendaLeitura>.Error(new Notification(nameof(VendaLeitura), Constantes.Vendas.VENDA_NAO_ENCONTRADA));

            return Result<VendaLeitura>.Ok(ListVendaDbParaVendaLeitura(modelsDb));
        }

        #region Métodos Privados
        private void BaixarEstoque(IReadOnlyCollection<VendaProduto> produtos)
        {
            foreach (var produto in produtos)
            {
                _appDbContext.Produtos.Find(produto.ProdutoId).Estoque -= produto.Quantidade;
                _appDbContext.SaveChanges();
            }
        }

        private List<Notification> verificarQuantidadeProdutosDisponivel(IReadOnlyCollection<VendaProdutoCriar> produtos)
        {
            List<Notification> notifications = new List<Notification>();

            foreach (var produto in produtos)
            {
                var produtoDb = _appDbContext.Produtos.Find(produto.ProdutoId);
                if (produtoDb.Estoque < produto.Quantidade)
                    notifications.Add(new Notification(nameof(Produto), $"{Constantes.Produtos.QUANTIDADE_INSUFICIENTE} Produto: {produtoDb.Descricao}, Quantidade Solicitada: {produto.Quantidade}"));
            }
            return notifications;
        }
        private Venda VendaCriarParaVenda(VendaCriar vendaCriar)
        {
            return new Venda
                (
                    BuscarUltimoValor(),
                    vendaCriar.DataVenda,
                    vendaCriar.FormaPagamento,
                    VendedorDbParaVendedor(vendaCriar.VendedorId),
                    ListVendaProdutoCriarParaListVendaProduto(vendaCriar.Produtos).AsReadOnly()
                );
        }

        private VendaLeitura ListVendaDbParaVendaLeitura(List<VendaDb> vendasDb)
        {
            List<VendaProdutoLeitura> produtos = new List<VendaProdutoLeitura>();

            foreach (var item in vendasDb)
            {
                produtos.Add(new VendaProdutoLeitura
                {
                    ProdutoId = item.ProdutoId,
                    ProdutoValor = item.ProdutoValor,
                    Quantidade = item.Quantidade
                });
            }

            string nomeVendedor = _appDbContext.Vendedores.FirstOrDefault(v => v.Id == vendasDb[0].VendedorId)?.Nome;

            VendedorLeitura vendedorLeitura = new VendedorLeitura
            {
                Id = vendasDb[0].VendedorId,
                Nome = nomeVendedor != null ? nomeVendedor : "Rose Petrina"
            };

            return new VendaLeitura
            {
                Id = vendasDb[0].IdVenda,
                DataVenda = vendasDb[0].DataVenda,
                FormaPagamento = vendasDb[0].FormaPagamento,
                Vendedor = vendedorLeitura,
                Produtos = produtos
            };
        }


        private Vendedor VendedorDbParaVendedor(int vendedorId)
        {
            var vendedorDb = _appDbContext.Vendedores.Find(vendedorId);

            if (vendedorDb != null)
                return new Vendedor(vendedorDb.Id, vendedorDb.Nome);

            var erro = new Notification(nameof(Vendedor), Constantes.Vendedores.VENDEDOR_NAO_ENCONTRADO);

            var vendedor = new Vendedor(vendedorDb.Nome);
            vendedor.AddNotification(erro);

            return vendedor;
        }

        private List<VendaDb> VendaParaListVendaDb(Venda venda)
        {
            List<VendaDb> vendasDb = new List<VendaDb>();

            VendedorDb vendedorDb = new VendedorDb
            {
                Id = venda.Vendedor.Id,
                Nome = venda.Vendedor.Nome
            };

            foreach (var item in venda.Produtos)
            {
                VendaDb vendaDb = new VendaDb
                {
                    IdDb = default,
                    IdVenda = venda.Id,
                    DataVenda = venda.DataVenda,
                    FormaPagamento = venda.FormaPagamento,
                    VendedorId = venda.Vendedor.Id,
                    ProdutoId = item.ProdutoId,
                    ProdutoValor = item.ProdutoValor,
                    Quantidade = item.Quantidade
                };

                vendasDb.Add(vendaDb);
            }

            return vendasDb;
        }

        private List<VendaProduto> ListVendaProdutoCriarParaListVendaProduto(IReadOnlyCollection<VendaProdutoCriar> produtos)
        {
            List<VendaProduto> vendaProdutos = new List<VendaProduto>();

            foreach (var produto in produtos)
            {
                var produtoDb = _appDbContext.Produtos.Find(produto.ProdutoId);

                if (produtoDb == null)
                {
                    VendaProduto vendaProduto = new VendaProduto(produto.ProdutoId, 0, produto.Quantidade);
                    vendaProduto
                        .AddNotification(nameof(produto.ProdutoId), Constantes.Entidades.ID_PRODUTO_INVALIDO);
                    vendaProdutos.Add(vendaProduto);
                    break;
                }
                vendaProdutos.Add(new VendaProduto(produto.ProdutoId, produtoDb.Valor, produto.Quantidade));
            }

            return vendaProdutos;
        }

        private List<VendaLeitura> ListVendaDbParaListVendaLeitura(List<VendaDb> vendasDb)
        {
            List<VendaLeitura> vendas = new List<VendaLeitura>();

            var listas = vendasDb.GroupBy(v => v.IdVenda);

            foreach (var group in listas)
            {
                List<VendaDb> vendasDbGroup = new List<VendaDb>();
                vendasDbGroup.AddRange(group);
                vendas.Add(ListVendaDbParaVendaLeitura(vendasDbGroup));
            }

            return vendas;
        }

        private int BuscarUltimoValor()
        {
            var controle = _appDbContext.ControlesDiversos.FirstOrDefault(c => c.Id == 1);

            if (controle == null)
            {
                controle = new ControlesDiversos
                {
                    CodigoVenda = 0
                };
                _appDbContext.ControlesDiversos.Add(controle);
                _appDbContext.SaveChanges();

                return controle.CodigoVenda;
            }

            controle.CodigoVenda++;
            _appDbContext.SaveChanges();
            return controle.CodigoVenda;
        }
        #endregion
    }
}

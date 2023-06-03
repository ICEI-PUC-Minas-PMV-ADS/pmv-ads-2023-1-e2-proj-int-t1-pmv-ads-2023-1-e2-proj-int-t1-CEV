using cev.api.Domain.Interfaces;
using cev.api.Domain.ModelsApi;
using cev.api.Uteis.Results;
using cev.api.Domain.ModelsDb;
using Flunt.Notifications;
using cev.api.Data;
using cev.api.Uteis;
using cev.api.Domain.Entidades;
using cev.api.Domain.Enums;

namespace cev.api.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoApplication(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Result<ProdutoLeitura> Atualizar(int id, string descricao, double valor)
        {
            List<Notification> notifications = new List<Notification>();
            if (id < 0)
                notifications.Add(new Notification(nameof(id), Constantes.Entidades.ID_INVALIDO));
            if (descricao == "" || string.IsNullOrWhiteSpace(descricao))
                notifications.Add(new Notification(nameof(descricao), Constantes.Entidades.DESCRICAO_NULA_OU_VAZIA));
            if (descricao.Length > 50)
                notifications.Add(new Notification(nameof(descricao), Constantes.Entidades.DESCRICAO_INVALIDA));
            if (valor < 0)
                notifications.Add(new Notification(nameof(valor), Constantes.Entidades.VALOR_INVALIDO));

            if (notifications.Any())
                return Result<ProdutoLeitura>.Error(notifications.AsReadOnly());

            var duplicado = _appDbContext.Produtos.FirstOrDefault(p => p.Descricao == descricao && p.Id != id);
            if (null != duplicado)
                return Result<ProdutoLeitura>.Error(new Notification(nameof(ProdutoLeitura), Constantes.Produtos.PRODUTO_DUPLICADO));

            var modelDb = _appDbContext.Produtos.Find(id);
            if (modelDb == null)
                return Result<ProdutoLeitura>.Error(new Notification(nameof(ProdutoLeitura), Constantes.Produtos.PRODUTO_NAO_ENCONTRADO));

            modelDb.Descricao = descricao;
            modelDb.Valor = valor;

            _appDbContext.SaveChanges();
            return Result<ProdutoLeitura>.Ok(new ProdutoLeitura
            {
                Id = modelDb.Id,
                Descricao = modelDb.Descricao,
                Estoque = modelDb.Estoque,
                Valor = modelDb.Valor
            });
        }

        public Result<ProdutoLeitura> AtualizarEstoque(int id, TipoAtualizacao tipoAtualizacao, int valor)
        {
            List<Notification> notifications = new List<Notification>();
            if (id < 0)
                notifications.Add(new Notification(nameof(id), Constantes.Entidades.ID_INVALIDO));
            if (valor < 0)
                notifications.Add(new Notification(nameof(valor), Constantes.Entidades.ESTOQUE_INVALIDO));

            if (notifications.Any())
                return Result<ProdutoLeitura>.Error(notifications.AsReadOnly());

            var modelDb = _appDbContext.Produtos.Find(id);
            if (modelDb == null)
                return Result<ProdutoLeitura>.Error(new Notification(nameof(ProdutoLeitura), Constantes.Produtos.PRODUTO_NAO_ENCONTRADO));

            if (tipoAtualizacao == TipoAtualizacao.Sub && ((modelDb.Estoque - valor) < 0))
                return Result<ProdutoLeitura>.Error(new Notification(nameof(ProdutoAtualizarEstoque.Valor), Constantes.Produtos.QUANTIDADE_INSUFICIENTE));
            
            if (tipoAtualizacao == TipoAtualizacao.Add)
                modelDb.Estoque += valor;
            if (tipoAtualizacao == TipoAtualizacao.Sub)
                modelDb.Estoque -= valor;

            _appDbContext.SaveChanges();
            return Result<ProdutoLeitura>.Ok(new ProdutoLeitura
            {
                Id = modelDb.Id,
                Descricao = modelDb.Descricao,
                Estoque = modelDb.Estoque,
                Valor = modelDb.Valor
            });
        }

        public Result Excluir(int id)
        {
            var modelDb = _appDbContext.Produtos.Find(id);

            if (modelDb == null)
                return Result.Error(new Notification(nameof(ProdutoLeitura), Constantes.Produtos.PRODUTO_NAO_ENCONTRADO));

            _appDbContext.Produtos.Remove(modelDb);
            _appDbContext.SaveChanges();
            return Result.Ok();
        }

        public Result<ProdutoLeitura> Inserir(ProdutoCriar produtoCriar)
        {
            var entidade = new Produto(produtoCriar.Descricao, produtoCriar.Valor, produtoCriar.Estoque);

            if (entidade.Invalid)
                return Result<ProdutoLeitura>.Error(entidade.Notifications);

            var duplicado = _appDbContext.Produtos.FirstOrDefault(p => p.Descricao == entidade.Descricao);
            if (null != duplicado)
                return Result<ProdutoLeitura>.Error(new Notification(nameof(ProdutoCriar), Constantes.Produtos.PRODUTO_DUPLICADO));

            var modelDb = new ProdutoDb
            {
                Descricao = entidade.Descricao,
                Valor = entidade.Valor,
                Estoque = entidade.Estoque,
            };

            _appDbContext.Produtos.Add(modelDb);
            _appDbContext.SaveChanges();

            return Result<ProdutoLeitura>.Ok(new ProdutoLeitura
            {
                Id = modelDb.Id,
                Descricao = modelDb.Descricao,
                Valor = modelDb.Valor,
                Estoque = modelDb.Estoque,
            });
        }

        public Result<List<ProdutoLeitura>> Listar()
        {
            var modelsDb = _appDbContext.Produtos.ToList();
            if (!modelsDb.Any())
                return Result<List<ProdutoLeitura>>.Error(new Notification(nameof(ProdutoLeitura), Constantes.Produtos.PRODUTO_NAO_ENCONTRADO));

            List<ProdutoLeitura> modelsLeitura = new List<ProdutoLeitura>();

            foreach (var model in modelsDb)
                modelsLeitura.Add(deProdutoDbParaProdutoLeitura(model));

            return Result<List<ProdutoLeitura>>.Ok(modelsLeitura);
        }

        public Result<ProdutoLeitura> RecuperarPorId(int id)
        {
            var modelDb = _appDbContext.Produtos.Find(id);

            if (modelDb == null)
                return Result<ProdutoLeitura>.Error(new Notification(nameof(ProdutoLeitura), Constantes.Produtos.PRODUTO_NAO_ENCONTRADO));

            var modelLeitura = deProdutoDbParaProdutoLeitura(modelDb);

            return Result<ProdutoLeitura>.Ok(modelLeitura);
        }

        #region Métodos Privados
        private ProdutoLeitura deProdutoDbParaProdutoLeitura(ProdutoDb produtoDb)
        {
            return new ProdutoLeitura
            {
                Id = produtoDb.Id,
                Descricao = produtoDb.Descricao,
                Valor = produtoDb.Valor,
                Estoque = produtoDb.Estoque
            };
        }
        #endregion
    }
}

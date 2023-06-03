using cev.api.Data;
using cev.api.Domain.Entidades;
using cev.api.Domain.Interfaces;
using cev.api.Domain.ModelsApi;
using cev.api.Domain.ModelsDb;
using cev.api.Uteis;
using cev.api.Uteis.Results;
using Flunt.Notifications;

namespace cev.api.Application
{
    public class VendedorApplication : IVendedorApplication
    {
        private readonly AppDbContext _appDbContext;

        public VendedorApplication(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Result<VendedorLeitura> AtualizarNome(int id, string nome)
        {
            List<Notification> notifications = new List<Notification>();

            if (nome == "" || string.IsNullOrWhiteSpace(nome))
                notifications.Add(new Notification(nameof(nome), Constantes.Entidades.NOME_NULO_OU_VAZIO));
            if (nome.Length > 10)
                notifications.Add(new Notification(nameof(nome), Constantes.Entidades.NOME_INVALIDO));

            if (notifications.Any())
                return Result<VendedorLeitura>.Error(notifications.AsReadOnly());

            var duplicado = _appDbContext.Vendedores.FirstOrDefault(v => v.Nome == nome);
            if (null != duplicado)
                return Result<VendedorLeitura>.Error(new Notification(nameof(VendedorLeitura), Constantes.Vendedores.VENDEDOR_DUPLICADO));

            var modelDb = _appDbContext.Vendedores.Find(id);

            if (modelDb == null)
                return Result<VendedorLeitura>.Error(new Notification(nameof(VendedorLeitura), Constantes.Vendedores.VENDEDOR_NAO_ENCONTRADO));

            modelDb.Nome = nome;
            _appDbContext.SaveChanges();

            return Result<VendedorLeitura>.Ok(new VendedorLeitura { Id = modelDb.Id, Nome = modelDb.Nome });
        }

        public Result Excluir(int id)
        {
            var modelDb = _appDbContext.Vendedores.Find(id);

            if (modelDb == null)
                return Result.Error(new Notification(nameof(id), Constantes.Vendedores.VENDEDOR_NAO_ENCONTRADO));

            _appDbContext.Vendedores.Remove(modelDb);
            _appDbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<VendedorLeitura> Inserir(VendedorCriar vendedorCriar)
        {
            var entidade = new Vendedor(vendedorCriar.Nome);

            if (entidade.Invalid)
                return Result<VendedorLeitura>.Error(entidade.Notifications);

            var duplicado = _appDbContext.Vendedores.FirstOrDefault(v => v.Nome == entidade.Nome);
            if (null != duplicado)
                return Result<VendedorLeitura>.Error(new Notification(nameof(VendedorCriar), Constantes.Vendedores.VENDEDOR_DUPLICADO));

            var modelDb = new VendedorDb
            {
                Nome = entidade.Nome,
            };

            _appDbContext.Vendedores.Add(modelDb);
            _appDbContext.SaveChanges();

            return Result<VendedorLeitura>.Ok(new VendedorLeitura
            {
                Id = modelDb.Id,
                Nome = modelDb.Nome
            });
        }

        public Result<List<VendedorLeitura>> Listar()
        {
            var modelsDb = _appDbContext.Vendedores.ToList();

            if (!modelsDb.Any())
                return Result<List<VendedorLeitura>>.Error(new Notification(nameof(VendedorLeitura), Constantes.Vendedores.VENDEDOR_NAO_ENCONTRADO));

            List<VendedorLeitura> modelsLeitura = new List<VendedorLeitura>();

            foreach (var modelDb in modelsDb)
                modelsLeitura.Add(DeVendedorDbParaVendedorLeitura(modelDb));

            return Result<List<VendedorLeitura>>.Ok(modelsLeitura);
        }

        public Result<VendedorLeitura> RecuperarPorId(int id)
        {
            var modelDb = _appDbContext.Vendedores.Find(id);

            if (modelDb == null)
                return Result<VendedorLeitura>.Error(new Notification(nameof(VendedorLeitura), Constantes.Vendedores.VENDEDOR_NAO_ENCONTRADO));

            var modelLeitura = DeVendedorDbParaVendedorLeitura(modelDb);

            return Result<VendedorLeitura>.Ok(modelLeitura);
        }

        #region Métodos Privados
        private VendedorLeitura DeVendedorDbParaVendedorLeitura(VendedorDb vendedorDb)
        {
            return new VendedorLeitura
            {
                Id = vendedorDb.Id,
                Nome = vendedorDb.Nome,
            };
        }
        #endregion
    }
}

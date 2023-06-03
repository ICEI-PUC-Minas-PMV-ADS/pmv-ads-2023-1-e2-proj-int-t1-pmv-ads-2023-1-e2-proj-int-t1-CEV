using cev.api.Domain.ModelsApi;
using cev.api.Uteis.Results;

namespace cev.api.Domain.Interfaces
{
    public interface IVendedorApplication
    {
        Result<VendedorLeitura> Inserir(VendedorCriar vendedorCriar);
        Result<List<VendedorLeitura>> Listar();
        Result<VendedorLeitura> RecuperarPorId(int id);
        Result<VendedorLeitura> AtualizarNome(int id, string nome);
        Result Excluir(int id);
    }
}

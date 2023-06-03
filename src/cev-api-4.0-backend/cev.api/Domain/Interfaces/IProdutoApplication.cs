using cev.api.Domain.Enums;
using cev.api.Domain.ModelsApi;
using cev.api.Uteis.Results;

namespace cev.api.Domain.Interfaces
{
    public interface IProdutoApplication
    {
        Result<ProdutoLeitura> Inserir(ProdutoCriar produtoCriar);
        Result<List<ProdutoLeitura>> Listar();
        Result<ProdutoLeitura> RecuperarPorId(int id);
        public Result<ProdutoLeitura> Atualizar(int id, string descricao, double valor);
        public Result<ProdutoLeitura> AtualizarEstoque(int id, TipoAtualizacao tipoAtualizacao,  int valor);
        Result Excluir(int id);
    }
}

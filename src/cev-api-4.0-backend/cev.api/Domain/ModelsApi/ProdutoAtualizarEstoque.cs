using cev.api.Domain.Enums;

namespace cev.api.Domain.ModelsApi
{
    public class ProdutoAtualizarEstoque
    {
        public TipoAtualizacao TipoAtualizacao { get; set; }
        public int Valor { get; set; }
    }
}

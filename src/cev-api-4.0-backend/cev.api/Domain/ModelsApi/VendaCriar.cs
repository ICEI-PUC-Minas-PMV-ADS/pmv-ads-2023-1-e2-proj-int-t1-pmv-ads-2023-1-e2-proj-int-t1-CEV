using cev.api.Domain.Enums;

namespace cev.api.Domain.ModelsApi
{
    public class VendaCriar
    {
        public DateTime DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int VendedorId { get; set; }
        public IReadOnlyCollection<VendaProdutoCriar> Produtos { get; set; }
    }
}

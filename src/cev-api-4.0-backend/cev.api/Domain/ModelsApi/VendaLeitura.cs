using cev.api.Domain.Enums;

namespace cev.api.Domain.ModelsApi
{
    public class VendaLeitura
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public VendedorLeitura Vendedor { get; set; }
        public List<VendaProdutoLeitura> Produtos { get; set; }

    }
}

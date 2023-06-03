using cev.api.Domain.Enums;
using cev.api.Uteis;
using Flunt.Notifications;

namespace cev.api.Domain.Entidades
{
    public class Venda : Notifiable
    {
        public int Id { get; private set; }
        public DateTime DataVenda { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public Vendedor Vendedor { get; private set; }

        public IReadOnlyCollection<VendaProduto> Produtos { get; private set; }

        public Venda(int id, DateTime dataVenda, FormaPagamento formaPagamento, Vendedor vendedor, IReadOnlyCollection<VendaProduto> produtos)
        {
            Id = id;
            if (Id < 0)
                AddNotification(nameof(Id), Constantes.Entidades.ID_INVALIDO);
            Validador(dataVenda, formaPagamento, vendedor, produtos);
        }

        public Venda(DateTime dataVenda, FormaPagamento formaPagamento, Vendedor vendedor, IReadOnlyCollection<VendaProduto> produtos)
        {
            Validador(dataVenda, formaPagamento, vendedor, produtos);
        }

        private void Validador(DateTime dataVenda, FormaPagamento formaPagamento, Vendedor vendedor, IReadOnlyCollection<VendaProduto> produtos)
        {
            DataVenda = dataVenda;
            FormaPagamento = formaPagamento;
            Vendedor = vendedor;
            Produtos = produtos;

            if (dataVenda.Year < 2023)
                AddNotification(nameof(dataVenda), Constantes.Entidades.DATA_INVALIDA);

            if ((int)formaPagamento < 1 || (int)formaPagamento > 4)
                AddNotification(nameof(FormaPagamento), Constantes.Entidades.FORMA_PAGAMENTO_INVALIDO);

            AddNotifications(vendedor);

            foreach (var produto in produtos)
                AddNotifications(produto);
        }
    }
}

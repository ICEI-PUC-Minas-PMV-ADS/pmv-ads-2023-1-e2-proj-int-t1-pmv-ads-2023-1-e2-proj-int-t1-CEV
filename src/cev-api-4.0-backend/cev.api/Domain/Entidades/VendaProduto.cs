using cev.api.Uteis;
using Flunt.Notifications;

namespace cev.api.Domain.Entidades
{
    public class VendaProduto : Notifiable
    {
        public int ProdutoId { get; private set; }
        public double ProdutoValor { get; private set; }
        public int Quantidade { get; private set; }

        public VendaProduto(int produtoId, double produtoValor, int quantidade)
        {
            ProdutoId = produtoId;
            if (ProdutoId < 0)
                AddNotification(nameof(ProdutoId), Constantes.Entidades.ID_PRODUTO_INVALIDO);
            Validador(produtoValor, quantidade);
        }
        public VendaProduto(double produtoValor, int quantidade)
        {
            Validador(produtoValor, quantidade);
        }

        private void Validador(double produtoValor, int quantidade)
        {
            ProdutoValor = produtoValor;
            Quantidade = quantidade;

            if (ProdutoValor < 0)
                AddNotification(nameof(ProdutoValor), Constantes.Produtos.VALOR_PRODUTO_INVALIDO);

            if (Quantidade < 0)
                AddNotification(nameof(Quantidade), Constantes.Produtos.QUANTIDADE_INVALIDA);
        }
    }
}

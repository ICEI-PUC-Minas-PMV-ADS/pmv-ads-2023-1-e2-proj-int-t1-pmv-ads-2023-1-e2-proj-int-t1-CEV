using System.Diagnostics.CodeAnalysis;

namespace cev.api.Uteis
{
    [ExcludeFromCodeCoverage]
    public static class Constantes
    {
        public static class Entidades
        {
            public const string ID_INVALIDO = "Id inválido.";
            public const string ID_VENDA_INVALIDO = "Id inválido.";
            public const string ID_VENDEDOR_INVALIDO = "Id Vendedor inválido.";
            public const string ID_PRODUTO_INVALIDO = "Id Produto inválido.";
            public const string NOME_NULO_OU_VAZIO = "Nome nulo ou vazio.";
            public const string NOME_INVALIDO = "Nome inválido.";
            public const string DESCRICAO_NULA_OU_VAZIA = "Descrição nula ou vazia.";
            public const string DESCRICAO_INVALIDA = "Descrição inválida.";
            public const string VALOR_INVALIDO = "Valor inválido.";
            public const string ESTOQUE_INVALIDO = "Estoque inválido.";
            public const string DATA_INVALIDA = "Data inválida.";
            public const string FORMA_PAGAMENTO_INVALIDO = "Forma Pagamento inválido.";
        }

        public static class Vendedores
        {
            public const string VENDEDOR_DUPLICADO = "Vendedor duplicado.";
            public const string VENDEDOR_NAO_ENCONTRADO = "Vendedor não encontrado.";
        }
        public static class Produtos
        {
            public const string PRODUTO_DUPLICADO = "Produto duplicado.";
            public const string PRODUTO_NAO_ENCONTRADO = "Produto não encontrado.";
            public const string VALOR_PRODUTO_INVALIDO = "Valor Produto inválido.";
            public const string QUANTIDADE_INVALIDA = "Quantidade inválida.";
            public const string QUANTIDADE_INSUFICIENTE = "Não é possível remover a quantidade solicitada do estoque! Estoque abaixo do solicitado.";
        }

        public static class Vendas
        {
            public const string VENDA_NAO_ENCONTRADA = "Venda não encontrada.";
        }
    }
}

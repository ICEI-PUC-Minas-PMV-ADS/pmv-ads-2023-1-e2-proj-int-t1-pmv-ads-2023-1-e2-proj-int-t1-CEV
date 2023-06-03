using System.ComponentModel.DataAnnotations;

namespace cev.api.Domain.ModelsApi
{
    public class ProdutoLeitura
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Estoque { get; set; }
    }
}

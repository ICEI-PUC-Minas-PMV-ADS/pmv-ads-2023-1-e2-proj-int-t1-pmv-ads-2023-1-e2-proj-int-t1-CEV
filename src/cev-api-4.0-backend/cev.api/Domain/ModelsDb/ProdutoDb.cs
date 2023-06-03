using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cev.api.Domain.ModelsDb
{
    public class ProdutoDb
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        [MaxLength(50)]
        public string Descricao { get; set; }
        [Column("valor")]
        public double Valor { get; set; }
        [Column("estoque")]
        public int Estoque { get; set; }
    }
}

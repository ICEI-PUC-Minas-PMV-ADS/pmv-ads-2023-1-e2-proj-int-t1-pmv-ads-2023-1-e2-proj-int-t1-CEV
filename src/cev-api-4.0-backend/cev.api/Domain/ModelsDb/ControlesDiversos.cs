using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cev.api.Domain.ModelsDb
{
    public class ControlesDiversos
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("codigo_venda")]
        public int CodigoVenda { get; set; }
    }
}

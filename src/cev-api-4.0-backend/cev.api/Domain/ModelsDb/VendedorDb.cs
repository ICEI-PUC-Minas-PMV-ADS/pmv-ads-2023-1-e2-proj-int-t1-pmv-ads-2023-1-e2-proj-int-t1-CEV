using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cev.api.Domain.ModelsDb
{
    public class VendedorDb
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        [MaxLength(10)]
        public string Nome { get; set; }
    }
}

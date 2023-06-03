using cev.api.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace cev.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        public DbSet<VendedorDb> Vendedores { get; set; }
        public DbSet<ProdutoDb> Produtos { get; set; }
        public DbSet<VendaDb> Vendas { get; set; }
        public DbSet<ControlesDiversos> ControlesDiversos { get; set; }
    }
}

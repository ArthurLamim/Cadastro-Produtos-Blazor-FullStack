
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalCRUD.Shared.Models;

namespace TrabalhoFinalCRUD.Server.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}

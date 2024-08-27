using ApiLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LivroModel> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
        
    }
}

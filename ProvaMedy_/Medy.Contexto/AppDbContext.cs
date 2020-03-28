using Microsoft.EntityFrameworkCore;
using Medy.Dominio;

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contato { get; set; }
    }
}
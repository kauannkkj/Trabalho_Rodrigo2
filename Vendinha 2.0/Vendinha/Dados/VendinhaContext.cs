using Microsoft.EntityFrameworkCore;
using Vendinha.Dominio;

namespace Vendinha.Dados;

public class VendinhaContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Divida> Dividas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=vendinha.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.Cpf)
            .IsUnique();
    }
}
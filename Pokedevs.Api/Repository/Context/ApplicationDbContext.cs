using Microsoft.EntityFrameworkCore;
using Pokedevs.Api.Models;

namespace Pokedevs.Api.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Parada> Parada { get; set; }
        public DbSet<Passagem> Passagem { get; set; }
        public DbSet<Rota> Rota { get; set; }
        public DbSet<RotaParada> RotaParada { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Viagem> Viagem { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passagem>(e =>
            {
                e.HasOne(e => e.Viagem);
                e.HasOne(e => e.RotaParada);
                e.HasOne(e => e.Usuario);
            });

            modelBuilder.Entity<RotaParada>(e =>
            {
                e.HasOne(e => e.Rota);
                e.HasOne(e => e.Parada);
            });

            modelBuilder.Entity<Viagem>(e =>
            {
                e.HasOne(e => e.Rota);
                e.HasOne(e => e.Veiculo);
            });
        }
    }
}
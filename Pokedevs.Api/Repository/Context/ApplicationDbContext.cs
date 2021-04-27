using Microsoft.EntityFrameworkCore;
using Pokedevs.Api.Models;

namespace Pokedevs.Api.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
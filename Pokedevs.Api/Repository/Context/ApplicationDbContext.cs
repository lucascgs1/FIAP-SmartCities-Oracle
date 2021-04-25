using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.EntityFrameworkCore;
using Pokedevs.Api.Models;

namespace Pokedevs.Api.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json").Build();

                //optionsBuilder.UseOracle(config.GetConnectionString("FiapSmartCityConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}

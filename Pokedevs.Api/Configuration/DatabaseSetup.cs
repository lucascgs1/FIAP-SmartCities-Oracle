using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedevs.Api.Repository.Context;

namespace Pokedevs.Api.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options => options.UseOracle(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}

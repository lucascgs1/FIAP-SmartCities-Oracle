using Microsoft.Extensions.DependencyInjection;
using Pokedevs.Api.Repository;
using Pokedevs.Api.Repository.Interface;
using Pokedevs.Api.Service;
using Pokedevs.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            if (services == null)
                throw new ArgumentNullException(nameof(services));

            #region repositorios
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITipoProdutoRepository, TipoProdutoRepository>();
            #endregion

            #region servicos
            services.AddTransient<IProdutoServices, ProdutoServices>();
            services.AddTransient<ITipoProdutoServices, TipoProdutoServices>();
            #endregion
        }

    }
}

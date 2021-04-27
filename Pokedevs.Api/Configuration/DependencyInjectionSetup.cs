using Microsoft.Extensions.DependencyInjection;
using Pokedevs.Api.Repository;
using Pokedevs.Api.Repository.Interface;
using Pokedevs.Api.Service;
using Pokedevs.Api.Service.Interface;
using System;

namespace Pokedevs.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            #region repositorios

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            #endregion repositorios

            #region servicos

            services.AddTransient<IVeiculoServices, VeiculoServices>();

            #endregion servicos
        }
    }
}
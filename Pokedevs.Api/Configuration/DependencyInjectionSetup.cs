using Microsoft.Extensions.DependencyInjection;
using Pokedevs.Data;
using Pokedevs.Data.Interfaces;
using Pokedevs.Services;
using Pokedevs.Services.Interfaces;
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

            services.AddScoped<IParadaRepository, ParadaRepository>();
            services.AddScoped<IPassagemRepository, PassagemRepository>();
            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IViagemRepository, ViagemRepository>();

            #endregion repositorios

            #region servicos

            services.AddTransient<IParadaServices, ParadaServices>();
            services.AddTransient<IPassagemServices, PassagemServices>();
            services.AddTransient<IRotaServices, RotaServices>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IVeiculoServices, VeiculoServices>();
            services.AddTransient<IViagemServices, ViagemServices>();

            #endregion servicos
        }
    }
}
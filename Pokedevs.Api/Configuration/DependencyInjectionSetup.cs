using Microsoft.Extensions.DependencyInjection;
using System;

namespace Pokedevs.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
        }
    }
}
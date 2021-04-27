using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace Pokedevs.Api.Configuration
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "CRUD",
                            Version = "v1",
                            Description = "Api criada para fiap SmartCitys",
                            Contact = new OpenApiContact
                            {
                                Name = "PokeDevs",
                                Url = new Uri("https://github.com/lucascgs1")
                            }
                        });

                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
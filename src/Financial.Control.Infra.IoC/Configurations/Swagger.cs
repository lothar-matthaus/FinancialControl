using Financial.Control.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Financial.Control.Infra.IoC.Configurations
{
    public static class Swagger
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            IApplication appService = services.BuildServiceProvider().GetRequiredService<IApplication>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(appService.AppConfig.ApiVersion, new OpenApiInfo
                {
                    Title = appService.AppConfig.ApiName,
                    Version = appService.AppConfig.ApiVersion,
                    Description = "Uma API para controle financeiro pessoal.",
                    TermsOfService = new Uri("https://github.com/lothar-matthaus/FinancialControl#readme"),
                    Contact = new OpenApiContact
                    {
                        Name = "Lothar Matthaus",
                        Email = "lotharmatt@alu.ufc.br",
                        Url = new Uri("https://www.linkedin.com/in/lothar-matthaus/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Uso ACADÊMICO aberto",
                    }
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var assemply = Assembly.Load("Financial.Control.Application");
                var xmlFile = $"{assemply.GetName().Name}.xml";

                var xmlPath = assemply.Location.Replace($"{assemply.GetName().Name}.dll", xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Configura
        /// </summary>
        /// <param name="app"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static WebApplication ConfigureSwagger(this WebApplication app, IServiceCollection services)
        {
            IApplication appService = services.BuildServiceProvider().GetRequiredService<IApplication>();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/{appService.AppConfig.ApiVersion}/swagger.json", appService.AppConfig.ApiName);
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}

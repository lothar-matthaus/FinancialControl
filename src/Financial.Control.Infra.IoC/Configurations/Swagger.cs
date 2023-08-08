using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Financial.Control.Infra.IoC.Configurations
{
    public static class Swagger
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(configuration["ApiVersion"], new OpenApiInfo
                {
                    Title = configuration["ApiName"],
                    Version = configuration["ApiVersion"],
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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Header de autorizao JWT usando esquema Bearer token. " +
                   "\r\n\r\n Introduza 'Bearer'[espao] e logo aps o seu token no campo abaixo." +
                    "\r\n\r\nExemplo: \"Bearer 12345abcdef\"",

                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                      {
                        {
                          new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              }
                            },
                            new List<string>()
                          }
                        });
                options.CustomSchemaIds(schema => schema.FullName);
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
        public static WebApplication ConfigureSwagger(this WebApplication app, IConfiguration configuration)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/{configuration["ApiVersion"]}/swagger.json", configuration["ApiName"]);
            });

            return app;
        }
    }
}

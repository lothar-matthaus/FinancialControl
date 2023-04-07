using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Repository;
using Financial.Control.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Control.Infra.IoC.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplication, Infra.Services.Application>();

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

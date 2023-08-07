using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Repository;
using Financial.Control.Infra.Config;
using Financial.Control.Infra.Data;
using Financial.Control.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Control.Infra.IoC.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAppConfig, AppConfig>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<INotificationManager, NotificationManager>();
            services.AddScoped<IApplicationServices, ApplicationServices>();
            services.AddScoped<IApplication>(service =>
            {
                IAppConfig appConfig = service.GetRequiredService<IAppConfig>();
                IConfiguration configuration = service.GetRequiredService<IConfiguration>();
                IApplicationServices applicationServices = service.GetRequiredService<IApplicationServices>();
                IUnitOfWork unitOfWork = service.GetRequiredService<IUnitOfWork>();
                IHttpContextAccessor httpContextAccessor = service.GetRequiredService<IHttpContextAccessor>();

                return new Config.Application(configuration, unitOfWork, applicationServices, appConfig, httpContextAccessor);
            });

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

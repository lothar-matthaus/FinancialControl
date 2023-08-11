using Financial.Control.Domain.Interfaces;
using Financial.Control.Domain.Interfaces.Config;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Domain.Repository;
using Financial.Control.Infra.Config;
using Financial.Control.Infra.Data;
using Financial.Control.Infra.Services;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IApplicationUser>(provider =>
            {
                IHttpContextAccessor httpContext = provider.GetRequiredService<IHttpContextAccessor>();
                return new ApplicationUser(httpContext);
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

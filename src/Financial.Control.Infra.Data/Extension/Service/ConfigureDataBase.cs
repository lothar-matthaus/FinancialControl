using Financial.Control.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Control.Infra.Data.Extension.Service
{
    public static class ConfigureDataBase
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IApplication application = serviceProvider.GetService<IApplication>();

            services.AddDbContext<FinancialControlDbContext>(options =>
            {
                options.UseNpgsql(application.AppConfig.DbConfig.ConnectionString);
            });

            return services;
        }
    }
}

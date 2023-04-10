using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Control.Infra.Data.Extension.Service
{
    public static class ConfigureDataBase
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinancialControlDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetSection("Database:DefaultConnection").Value ?? string.Empty);
            });

            return services;
        }
    }
}

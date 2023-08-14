using Financial.Control.Domain.Interfaces.Repository;
using Financial.Control.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Control.Infra.IoC.Repositories
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();

            return services;
        }
    }
}

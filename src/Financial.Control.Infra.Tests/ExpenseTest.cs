using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Notifications;
using Financial.Control.Domain.Interfaces.Services;
using Financial.Control.Infra.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Financial.Control.Infra.Tests
{
    public class ExpenseTest
    {
        [Fact]
        public void test()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<INotificationManager, NotificationManager>();

            IServiceProvider serviceProvider = services.BuildServiceProvider(); 

            var teste = Expense.Create("", null, null, null);

            INotificationManager notificationManager = serviceProvider.GetService<INotificationManager>();

            if(!teste.IsValid)
                notificationManager.AddNotifications(teste.GetNotifications()); 
        }
    }
}

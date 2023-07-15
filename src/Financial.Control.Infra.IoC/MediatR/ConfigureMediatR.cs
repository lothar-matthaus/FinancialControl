using Financial.Control.Application.Middlewares;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Financial.Control.Infra.IoC.MediatR
{
    public static class ConfigureMediatR
    {
        public static IServiceCollection AddApplicationMediatR(this IServiceCollection services)
        {
            services.AddMediatR(mediatR => mediatR.RegisterServicesFromAssembly(Assembly.Load("Financial.Control.Application")));
            return services;
        }

        public static IServiceCollection AddBaseRequestHandlerBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BaseRequestHandlerBehavior<,>));
            return services;
        }
    }
}

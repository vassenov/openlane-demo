using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Openlane.CarSaleManager.Application
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.ConfigureMediator();

            return services;
        }

        private static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}

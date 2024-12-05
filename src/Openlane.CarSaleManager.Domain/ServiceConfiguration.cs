using Microsoft.Extensions.DependencyInjection;
using Openlane.CarSaleManager.Domain.Abstractions;

namespace Openlane.CarSaleManager.Domain
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            services.ConfigureFactories();

            return services;
        }

        private static IServiceCollection ConfigureFactories(this IServiceCollection services)
            => services
                .Scan(selector => selector
                        .FromCallingAssembly()
                        .AddClasses(classes => classes.AssignableTo(typeof(IFactory<>)))
                        .AsMatchingInterface()
                        .WithTransientLifetime());
    }
}

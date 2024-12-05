using Openlane.CarSaleManager.Infrastructure;
using Openlane.CarSaleManager.Application;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Service
{
    internal static class HostConfiguration
    {
        public static IServiceCollection Setup(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureInfrastructure(configuration)
                .ConfigureApplication()
                .ConfigureDomain();

            return services;
        }
    }
}

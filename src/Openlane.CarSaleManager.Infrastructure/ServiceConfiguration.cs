using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Openlane.CarSaleManager.Application;

namespace Openlane.CarSaleManager.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureWebComponents()
                .ConfigureDatabase(configuration)
                .ConfigureRepositories()
                .ConfigureMessaging()
                .ConfigureInitializer();

            return services;
        }

        private static IServiceCollection ConfigureWebComponents(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddApplicationPart(Assembly.GetExecutingAssembly())
                .AddControllersAsServices();

            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<CarSalesDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
            => services
                .Scan(selector => selector
                        .FromCallingAssembly()
                        .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                        .AsMatchingInterface()
                        .WithScopedLifetime());

        private static IServiceCollection ConfigureMessaging(this IServiceCollection services)
        {
            services.AddMassTransit(busConfig => 
            {
                busConfig.AddConsumer<CarSaleConsumer>();
                busConfig.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
            });

            services.AddHostedService<Publisher>();

            return services;
        }

        private static IServiceCollection ConfigureInitializer(this IServiceCollection services) 
        { 
            services.AddScoped<IInitializer, CarSalesDbInitializer>();

            return services;
        }
    }
}

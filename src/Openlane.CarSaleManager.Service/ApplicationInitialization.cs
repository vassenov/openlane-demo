using Openlane.CarSaleManager.Infrastructure;

namespace Openlane.CarSaleManager.Service
{
    public static class ApplicationInitialization
    {
        internal static IApplicationBuilder Initialize(this IApplicationBuilder builder)
        {
            using(var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var initializer = serviceScope.ServiceProvider.GetService<IInitializer>()!;
                initializer.Initialize();
                
                return builder;
            }
        }
    }
}

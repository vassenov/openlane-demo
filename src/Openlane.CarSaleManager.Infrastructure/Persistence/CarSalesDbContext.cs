using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class CarSalesDbContext : DbContext
    {
        public CarSalesDbContext(DbContextOptions<CarSalesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Openlane.CarSaleManager.Application;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class CarSaleRepository : Repository<CarSale>, ICarSaleRepository
    {
        public CarSaleRepository(CarSalesDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<CarSale>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            var carSales = await All()
                                .ToListAsync(cancellationToken);

            return carSales;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Openlane.CarSaleManager.Application;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class DealerRepository : Repository<Dealer>, IDealerRepository
    {
        public DealerRepository(CarSalesDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Dealer?> FindByNameAsync(string dealerName, CancellationToken cancellationToken = default)
        {
            var dealer = await All()
                               .FirstOrDefaultAsync(x => x.Name == dealerName, cancellationToken);

            return dealer;
        }
    }
}

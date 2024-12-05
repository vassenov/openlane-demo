using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Application
{
    public interface IDealerRepository : IRepository<Dealer>
    {
        Task<Dealer?> FindByNameAsync(string dealerName, CancellationToken cancellationToken = default);
    }
}

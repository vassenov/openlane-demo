using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Application
{
    public interface ICarSaleRepository : IRepository<CarSale>
    {
        Task<IEnumerable<CarSale>> FindAllAsync(CancellationToken cancellationToken = default);
    }
}

using Openlane.CarSaleManager.Domain.Abstractions;

namespace Openlane.CarSaleManager.Domain
{
    public interface ICarSaleFactory : IFactory<CarSale>
    {
        ICarSaleFactory WithManufacturer(string manufacturer);

        ICarSaleFactory WithTransmission(string transmission);

        ICarSaleFactory WithPrice(decimal price);
    }
}

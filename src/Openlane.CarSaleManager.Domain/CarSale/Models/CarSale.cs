using Openlane.CarSaleManager.Domain.Abstractions;

namespace Openlane.CarSaleManager.Domain
{
    public class CarSale : Entity, IAggregateRoot
    {
        private CarSale() { }

        protected internal CarSale(Manufacturer manufacturer, Transmission transmission, decimal price) 
        { 
            Manufacturer = manufacturer;
            Transmission = transmission;
            Price = price;
        }

        public Manufacturer Manufacturer { get; init; } = default!;

        public Transmission Transmission { get; init; } = default!;
                
        public decimal Price { get; private set; }
    }
}

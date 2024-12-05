using Openlane.CarSaleManager.Application;

namespace Openlane.CarSaleManager.Infrastructure
{
    internal static partial class Mapper
    {
        internal static CreateCarSaleCommand ToCommand(this CreateCarSaleMessage message)
            => new CreateCarSaleCommand
            {
                Manufacturer = message.Manufacturer,
                Transmission = message.Transmission,
                Dealer = message.Dealer,
                Price = message.Price
            };
    }
}

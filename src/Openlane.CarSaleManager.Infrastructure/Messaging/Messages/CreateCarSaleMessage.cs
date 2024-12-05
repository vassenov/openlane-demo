namespace Openlane.CarSaleManager.Infrastructure
{
    public class CreateCarSaleMessage
    {
        public string Manufacturer { get; init; } = default!;

        public string Transmission { get; init; } = default!;

        public decimal Price { get; init; } = default!;

        public string Dealer { get; init; } = default!;
    }
}

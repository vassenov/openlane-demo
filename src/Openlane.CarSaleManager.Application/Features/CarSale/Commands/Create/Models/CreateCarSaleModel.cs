namespace Openlane.CarSaleManager.Application
{
    public class CreateCarSaleModel
    {
        public string Manufacturer { get; set; } = default!;

        public string Transmission { get; set; } = default!;

        public decimal Price { get; set; } = default!;

        public string Dealer { get; set; } = default!;
    }
}

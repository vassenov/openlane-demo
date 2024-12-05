namespace Openlane.CarSaleManager.Application
{
    public class CarSaleOutputModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; init; } = default!;

        public string Transmission { get; init; } = default!;

        public decimal Price { get; set; }
    }
}

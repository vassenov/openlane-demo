using Bogus;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class CreateCarSaleMessageFaker : Faker<CreateCarSaleMessage>
    {
        public CreateCarSaleMessageFaker() 
        {
            RuleFor(x => x.Manufacturer, x => x.PickRandom(Manufacturer.Volvo, Manufacturer.LandRover).ToString());
            RuleFor(x => x.Transmission, x => x.PickRandom(Transmission.Manual, Transmission.Automatic).ToString());
            RuleFor(x => x.Dealer, x => x.PickRandom("ABC", "Land Rover Brussels East Zaventem"));
            RuleFor(x => x.Price, x => x.Finance.Amount(10000, 50000));
        }
    }
}

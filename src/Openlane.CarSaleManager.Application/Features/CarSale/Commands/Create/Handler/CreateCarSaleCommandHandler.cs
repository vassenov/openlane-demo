using MediatR;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Application
{
    public class CreateCarSaleCommandHandler : IRequestHandler<CreateCarSaleCommand, CreateCarSaleOutputModel>
    {
        private readonly ICarSaleFactory _carSaleFactory;
        private readonly IDealerRepository _dealerRepository;
        
        public CreateCarSaleCommandHandler(ICarSaleFactory carSaleFactory, IDealerRepository dealerRepository) 
        { 
            _carSaleFactory = carSaleFactory;
            _dealerRepository = dealerRepository;
        }

        public async Task<CreateCarSaleOutputModel> Handle(CreateCarSaleCommand request, CancellationToken cancellationToken)
        {
            var dealer = await _dealerRepository.FindByNameAsync(request.Dealer, cancellationToken);

            if (dealer is null)
            {
                return new CreateCarSaleOutputModel { Id = 0 };
            }

            var carSale = _carSaleFactory
                            .WithManufacturer(request.Manufacturer)
                            .WithTransmission(request.Transmission)
                            .WithPrice(request.Price)
                            .Build();

            dealer.AddCarSale(carSale);
            await _dealerRepository.UpdateAsync(dealer);

            return new CreateCarSaleOutputModel { Id = carSale.Id };
        }
    }
}

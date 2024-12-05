using MediatR;

namespace Openlane.CarSaleManager.Application
{
    public class AllCarSalesQueryHandler : IRequestHandler<AllCarSalesQuery, IEnumerable<CarSaleOutputModel>>
    {
        private readonly ICarSaleRepository _carSaleRepository;

        public AllCarSalesQueryHandler(ICarSaleRepository carSaleRepository) 
            => _carSaleRepository = carSaleRepository;

        public async Task<IEnumerable<CarSaleOutputModel>> Handle(AllCarSalesQuery request, CancellationToken cancellationToken)
        {
            var carSales = await _carSaleRepository.FindAllAsync(cancellationToken);
            var outputModels = carSales.ToOutputModels();

            return outputModels;
        }
    }
}

using MediatR;

namespace Openlane.CarSaleManager.Application
{
    public class AllCarSalesQuery : IRequest<IEnumerable<CarSaleOutputModel>>
    {
    }
}

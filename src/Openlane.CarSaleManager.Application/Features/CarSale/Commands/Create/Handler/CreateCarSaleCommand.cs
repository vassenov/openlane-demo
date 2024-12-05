using MediatR;

namespace Openlane.CarSaleManager.Application
{
    public class CreateCarSaleCommand : CreateCarSaleModel, IRequest<CreateCarSaleOutputModel>
    {
    }
}

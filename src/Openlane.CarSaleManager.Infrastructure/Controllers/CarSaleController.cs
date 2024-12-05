using Microsoft.AspNetCore.Mvc;
using MediatR;
using Openlane.CarSaleManager.Application;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class CarSaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarSaleController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost(ApiRoutes.CarSales.Create)]
        public async Task<IActionResult> CreateCarSale(CreateCarSaleCommand command)
        {
            var outputResult = await _mediator.Send(command);

            return Ok(outputResult);
        }

        [HttpGet(ApiRoutes.CarSales.GetAll)]
        public async Task<IActionResult> AllCarSales()
        {
            var outputResult = await _mediator.Send(new AllCarSalesQuery());

            return Ok(outputResult);
        }
    }
}

using Microsoft.Extensions.Hosting;
using MassTransit;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class Publisher : BackgroundService
    {
        private readonly IBus _bus;
        
        public Publisher(IBus bus)
            => _bus = bus;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                var messages = GetMessageBatch();
                await _bus.PublishBatch(messages, stoppingToken);

                await Task.Delay(1000);
            }
        }

        private IEnumerable<CreateCarSaleMessage> GetMessageBatch()
            => new CreateCarSaleMessageFaker().Generate(100);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Infrastructure
{
    public class CarSalesDbInitializer : IInitializer
    {
        private readonly ILogger<CarSalesDbInitializer> _logger;
        private readonly IConfiguration _configuration;
        private readonly CarSalesDbContext _context;

        public CarSalesDbInitializer(ILogger<CarSalesDbInitializer> logger, IConfiguration configuration, CarSalesDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }

        public void Initialize()
        {
            CreateDatabase();
            AddInitialData();
        }

        private void CreateDatabase()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            _context
                .Database
                .SetConnectionString(connectionString);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _logger.LogInformation($"Created database on localhost");
        }

        private void AddInitialData()
        {
            var dealers = DealerData.GetData();
            foreach (var dealer in dealers)
            {
                _context.Add(dealer);
            }

            _context.SaveChanges();

            _logger.LogInformation("Initialized Dealer data");
        }
    }
}

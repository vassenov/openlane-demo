using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Infrastructure
{
    internal class CarSaleConfiguration : IEntityTypeConfiguration<CarSale>
    {
        public void Configure(EntityTypeBuilder<CarSale> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Manufacturer)
                .HasConversion(
                    x => x.ToString(),
                    x => Enum.Parse<Manufacturer>(x))
                .IsRequired();

            builder
                .Property(x => x.Transmission)
                .HasConversion(
                    x => x.ToString(),
                    x => Enum.Parse<Transmission>(x))
                .IsRequired();

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder.ToTable("CarSales");
        }
    }
}

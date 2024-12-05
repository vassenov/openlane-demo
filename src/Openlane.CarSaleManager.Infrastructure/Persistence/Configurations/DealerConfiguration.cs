using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Openlane.CarSaleManager.Domain;

namespace Openlane.CarSaleManager.Infrastructure
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsOne(
                x => x.Address, 
                address =>
                {
                    address
                        .Property(x => x.City)
                        .IsRequired();
                    address
                        .Property(x => x.Street)
                        .IsRequired();
                    address
                        .Property(x => x.StreetNumber)
                        .IsRequired();
                    address
                        .Property(x => x.PostCode)
                        .IsRequired();
                });

            builder
                .HasMany(x => x.CarSales)
                .WithOne()
                .HasForeignKey("DealerId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata
                .PrincipalToDependent!
                .SetField("_carSales");

            builder.ToTable("Dealers");
        }
    }
}

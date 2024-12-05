﻿using Openlane.CarSaleManager.Domain.Abstractions;
using static Openlane.CarSaleManager.Domain.Abstractions.Guard;

namespace Openlane.CarSaleManager.Domain
{
    public class Dealer : Entity, IAggregateRoot
    {
        private readonly HashSet<CarSale> _carSales = new HashSet<CarSale>();

        private Dealer() { }

        protected internal Dealer(string name, Address address)
        {
            Validate(name, address);

            Name = name;
            Address = address;
        }

        public string Name { get; init; } = default!;

        public Address Address { get; init; } = default!;

        public IEnumerable<CarSale> CarSales
            => _carSales
                .ToList()
                .AsReadOnly();

        public void AddCarSale(CarSale carSale)
        {
            ValidateCarSale(carSale);
            _carSales.Add(carSale);
        }

        private void Validate(string name, Address address)
        {
            ValidateName(name);
            ValidateAddress(address);
        }

        public void ValidateName(string name)
            => ForStringLength<InvalidDealerException>(name, 1, 50);

        public void ValidateAddress(Address address)
            => AgainstNullObject<InvalidDealerException>(address);

        public void ValidateCarSale(CarSale carSale)
            => AgainstNullObject<InvalidDealerException>(carSale);
    }
}

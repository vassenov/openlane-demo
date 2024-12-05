﻿using Openlane.CarSaleManager.Domain.Abstractions;

namespace Openlane.CarSaleManager.Domain
{
    public class InvalidDealerException : DomainException
    {
        public InvalidDealerException()
        {
        }

        public InvalidDealerException(string error) 
            => Error = error;
    }
}

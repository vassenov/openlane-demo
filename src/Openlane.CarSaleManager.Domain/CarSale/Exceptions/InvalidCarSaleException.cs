using Openlane.CarSaleManager.Domain.Abstractions;

namespace Openlane.CarSaleManager.Domain
{
    public class InvalidCarSaleException : DomainException
    {
        public InvalidCarSaleException()
        {
        }

        public InvalidCarSaleException(string error) 
            => Error = error;
    }
}

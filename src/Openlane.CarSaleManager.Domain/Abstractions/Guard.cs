namespace Openlane.CarSaleManager.Domain.Abstractions
{
    internal static class Guard
    {
        internal static void AgainstNullOrEmptyString<TException>(string value)
            where TException : DomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            var message = $"{value} can't be null or empty";
            ThrowException<TException>(message);
        }

        internal static void ForStringLength<TException>(string value, int minLength, int maxLength)
            where TException : DomainException, new()
        {
            AgainstNullOrEmptyString<TException>(value);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            var message = $"Value length must be between {minLength} and {maxLength}.";
            ThrowException<TException>(message);
        }

        internal static void AgainstNullObject<TException>(object value)
            where TException : DomainException, new()
        {
            if (value is not null)
            {
                return;
            }

            var message = $"{value} can't be null";
            ThrowException<TException>(message);
        }

        private static void ThrowException<TException>(string message)
            where TException : DomainException, new()
            => throw new TException
            {
                Error = message
            };
    }
}

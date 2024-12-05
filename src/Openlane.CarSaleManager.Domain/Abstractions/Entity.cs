namespace Openlane.CarSaleManager.Domain.Abstractions
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; protected set; } = default!;

        public bool Equals(Entity? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return Equals((Entity)obj);
        }

        public static bool operator ==(Entity? obj, Entity? otherObj)
        {
            if (obj is null && otherObj is null)
                return true;

            if (obj is null || otherObj is null)
                return false;

            return obj.Equals(otherObj);
        }

        public static bool operator !=(Entity? obj, Entity? otherObj)
            => !(obj == otherObj);

        public override int GetHashCode()
            => (GetType().ToString() + Id).GetHashCode();
    }
}

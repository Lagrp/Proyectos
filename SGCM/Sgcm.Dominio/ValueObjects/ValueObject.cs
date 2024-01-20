namespace Sgcm.Dominio.ValueObjects
{
    public abstract record ValueObject
    {
        protected static bool IsEqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(IsEqualOperator(left, right));
        }

        //protected abstract IEnumerable<object> GetEqualityComponents();

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || obj.GetType() != GetType())
        //    {
        //        return false;
        //    }

        //    var other = (ValueObject)obj;

        //    return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        //}

        //public override int GetHashCode()
        //{
        //    return GetEqualityComponents()
        //        .Select(x => x != null ? x.GetHashCode() : 0)
        //        .Aggregate((x, y) => x ^ y);
        //}

        // Other utility methods

        //public static bool operator ==(ValueObject one, ValueObject two)
        //{
        //    return IsEqualOperator(one, two);
        //}

        //public static bool operator !=(ValueObject one, ValueObject two)
        //{
        //    return NotEqualOperator(one, two);
        //}
    }
}
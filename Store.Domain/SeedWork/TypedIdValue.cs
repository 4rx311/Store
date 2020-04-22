using System;

namespace Store.Domain.SeedWork
{
    public abstract class TypedIdValue : IEquatable<TypedIdValue>
    {
        protected TypedIdValue(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public bool Equals(TypedIdValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TypedIdValue) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(TypedIdValue obj1, TypedIdValue obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(TypedIdValue x, TypedIdValue y)
        {
            return !(x == y);
        }
    }
}

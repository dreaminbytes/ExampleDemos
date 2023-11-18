using System;

namespace ExcelLibraryTesting
{
    public struct CustomerId : IEquatable<CustomerId>
    {
        public Guid Value { get; }

        public CustomerId(Guid value)
        {
            Value = value;
        }

        public bool Equals(CustomerId other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return obj is CustomerId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}

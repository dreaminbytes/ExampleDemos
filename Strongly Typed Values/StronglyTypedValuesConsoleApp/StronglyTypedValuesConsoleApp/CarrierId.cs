using System;

namespace ExcelLibraryTesting
{
    public struct CarrierId : IEquatable<CarrierId>
    {
        public int Value { get; }

        public CarrierId(int value)
        {
            Value = value;
        }

        public bool Equals(CarrierId other)
        {
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is CarrierId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}

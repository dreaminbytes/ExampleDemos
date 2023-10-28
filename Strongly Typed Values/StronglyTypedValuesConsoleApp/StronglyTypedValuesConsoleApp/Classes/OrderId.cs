using System;

namespace StronglyTypedValuesConsoleApp.Classes
{
    public readonly struct OrderId : IComparable<OrderId>, IEquatable<OrderId>
    {
        public Guid Value { get; }

        public OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId New() => new OrderId(Guid.NewGuid());

        public int CompareTo(OrderId other) => Value.CompareTo(other.Value);
        public bool Equals(OrderId other) => this.Value.Equals(other.Value);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is OrderId other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static bool operator ==(OrderId a, OrderId b) => a.CompareTo(b) == 0;
        public static bool operator !=(OrderId a, OrderId b) => !(a == b);
    }

}

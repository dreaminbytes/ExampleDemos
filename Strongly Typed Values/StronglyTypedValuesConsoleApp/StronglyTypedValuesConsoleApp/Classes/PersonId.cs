using System;

namespace StronglyTypedValuesConsoleApp.Classes
{
    internal readonly struct PersonId : IComparable<PersonId>, IEquatable<PersonId>
    {
        internal int Value { get; }

        internal PersonId(int value)
        {
            Value = value;
        }

        //review: is this need, maybe only for GUID
        internal static PersonId New() => new PersonId(0);

        public bool Equals(PersonId other) => this.Value.Equals(other.Value);
        public int CompareTo(PersonId other) => Value.CompareTo(other.Value);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            //review if (ReferenceEquals(this, obj)) return true;
            return obj is PersonId other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(PersonId a, PersonId b) => a.CompareTo(b) == 0;
        public static bool operator !=(PersonId a, PersonId b) => !(a == b);
    }

}

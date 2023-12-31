﻿using System;
using System.Collections.Generic;

// ref: https://event-driven.io/en/using_strongly_typed_ids_with_marten/

namespace StronglyTypedValuesConsoleApp.Classes.Base
{
    public class StronglyTypedValue<T> : IEquatable<StronglyTypedValue<T>> where T : IComparable<T>
    {
        public T Value { get; }

        public StronglyTypedValue(T value)
        {
            Value = value;
        }

        public bool Equals(StronglyTypedValue<T>? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StronglyTypedValue<T>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(StronglyTypedValue<T>? left, StronglyTypedValue<T>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StronglyTypedValue<T>? left, StronglyTypedValue<T>? right)
        {
            return !Equals(left, right);
        }
    }
}

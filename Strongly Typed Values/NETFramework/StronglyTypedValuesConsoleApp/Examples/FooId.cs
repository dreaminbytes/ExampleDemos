namespace StronglyTypedValuesConsoleApp.Examples
{
    // Example generated from StronglyTypedId NuGet package.
    // see https://andrewlock.net/using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-2/#a-full-example-implementation

    [System.ComponentModel.TypeConverter(typeof(CarrierIdTypeConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(CarrierIdNewtonsoftJsonConverter))]
    internal readonly /*partial*/ struct FooId : System.IComparable<FooId>, System.IEquatable<FooId>
    {
        public int Value
        {
            get;
        }

        public FooId(int value)
        {
            Value = value;
        }

        // No New()
        public static readonly FooId Empty = new FooId(0);
        public int CompareTo(FooId other) => Value.CompareTo(other.Value);
        public bool Equals(FooId other) => this.Value.Equals(other.Value);
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is FooId other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(FooId a, FooId b) => a.CompareTo(b) == 0;
        public static bool operator !=(FooId a, FooId b) => !(a == b);
        class CarrierIdTypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
            {
                return sourceType == typeof(int) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value is int intValue)
                {
                    return new FooId(intValue);
                }

                return base.ConvertFrom(context, culture, value);
            }
        }

        class CarrierIdNewtonsoftJsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override bool CanConvert(System.Type objectType)
            {
                return objectType == typeof(FooId);
            }

            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var id = (FooId)value;
                serializer.Serialize(writer, id.Value);
            }

            public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                return new FooId(serializer.Deserialize<int>(reader));
            }
        }
    }
}

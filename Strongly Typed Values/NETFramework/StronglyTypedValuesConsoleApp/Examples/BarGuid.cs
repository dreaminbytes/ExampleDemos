namespace StronglyTypedValuesConsoleApp.Examples
{
    // Example generated from StronglyTypedId NuGet package.

    [System.ComponentModel.TypeConverter(typeof(FooIdTypeConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(FooIdNewtonsoftJsonConverter))]
    internal readonly /*partial*/ struct BarGuid : System.IComparable<BarGuid>, System.IEquatable<BarGuid>
    {
        public System.Guid Value
        {
            get;
        }

        public BarGuid(System.Guid value)
        {
            Value = value;
        }

        public static BarGuid New() => new BarGuid(System.Guid.NewGuid());
        public static readonly BarGuid Empty = new BarGuid(System.Guid.Empty);
        public int CompareTo(BarGuid other) => Value.CompareTo(other.Value);
        public bool Equals(BarGuid other) => this.Value.Equals(other.Value);
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is BarGuid other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();
        public static bool operator ==(BarGuid a, BarGuid b) => a.CompareTo(b) == 0;
        public static bool operator !=(BarGuid a, BarGuid b) => !(a == b);
        class FooIdTypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                var stringValue = value as string;
                if (!string.IsNullOrEmpty(stringValue) && System.Guid.TryParse(stringValue, out var guid))
                {
                    return new BarGuid(guid);
                }

                return base.ConvertFrom(context, culture, value);
            }
        }

        class FooIdNewtonsoftJsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override bool CanConvert(System.Type objectType)
            {
                return objectType == typeof(BarGuid);
            }

            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var id = (BarGuid)value;
                serializer.Serialize(writer, id.Value);
            }

            public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                var guid = serializer.Deserialize<System.Guid>(reader);
                return new BarGuid(guid);
            }
        }
    }
}

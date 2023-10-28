using StronglyTypedValuesConsoleApp.Classes.Base;

using System;

namespace StronglyTypedValuesConsoleApp.Classes
{
    internal class PersonInheritedId : StronglyTypedValue<int>
    {
        public PersonInheritedId(int value) : base(value)
        {
        }
    }

    internal class PersonGuidInherited : StronglyTypedValue<Guid>
    {
        public PersonGuidInherited(Guid value) : base(value)
        {
        }
    }

    internal class PersonStringInherited : StronglyTypedValue<string>
    {
        public PersonStringInherited(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value) || value.StartsWith("RES/") || value.Length <= 4)
                throw new ArgumentOutOfRangeException(nameof(value));
        }
    }

}

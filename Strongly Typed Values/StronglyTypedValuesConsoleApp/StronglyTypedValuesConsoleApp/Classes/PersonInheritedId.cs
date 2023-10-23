using StronglyTypedValuesConsoleApp.Classes.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedValuesConsoleApp.Classes
{
    internal readonly struct PersonInheritedId : StronglyTypedValue<int>
    {
    }
}

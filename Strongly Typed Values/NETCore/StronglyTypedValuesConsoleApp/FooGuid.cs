using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using StronglyTypedIds;

namespace StronglyTypedValuesConsoleApp;

[StronglyTypedId] // <- Add this attribute to auto-generate the rest of the type
public partial struct FooGuid { } // Default is Guid

//[StronglyTypedId]
//internal partial struct FooInternalGuid { } // no difference
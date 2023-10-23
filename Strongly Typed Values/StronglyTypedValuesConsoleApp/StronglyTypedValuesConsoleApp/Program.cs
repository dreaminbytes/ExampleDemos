using StronglyTypedValuesConsoleApp.Classes;

using System;

namespace StronglyTypedValuesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var personId = new PersonId();
            var personId2 = new PersonId(0);

            var test1 = personId.CompareTo(personId2);
            var test2 = personId.Equals(personId2);
            var test3 = personId == personId2;
            var test4 = personId != personId2;

            Console.WriteLine($"Test1: {test1}");
            Console.WriteLine($"Test2: {test2}");
            Console.WriteLine($"Test3: {test3}");
            Console.WriteLine($"Test4: {test4}");

            Console.Write("Press a key to exit.");
            Console.ReadLine();
        }
    }
}

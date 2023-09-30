using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ExcelLibraryTesting
{
    static class Helper
    {
        const int num = 1000; //todo 10000;
        internal static readonly List<int> listOfNumbers = Enumerable.Range(500000, num).ToList();

        internal static void DeleteExistingFile(string filepath)
        {
            if (File.Exists(filepath)) File.Delete(filepath);
            Thread.Sleep(1000);
        }
    }
}

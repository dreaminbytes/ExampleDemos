using System;
using System.Collections.Generic;
using System.Data;
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

        internal static DataTable GetDataTable()
        {
            // We add 4 columns, each with a Type.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Diagnosis", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // here we add rows.
            //table.Rows.Add(25, "Drug A", "Disease A", DateTime.Now);
            //table.Rows.Add(50, "Drug Z", "Problem Z", DateTime.Now);
            //table.Rows.Add(10, "Drug Q", "Disorder Q", DateTime.Now);
            //table.Rows.Add(21, "Medicine A", "Diagnosis A", DateTime.Now);

            for (int rowNumber = 1; rowNumber <= 1000; rowNumber++)
            {
                table.Rows.Add(rowNumber, $"Drug {rowNumber}", $"Disorder {rowNumber}", DateTime.Now);
            }

            return table;
        }
    }
}

using ClosedXML.Excel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Useful Links:
// https://docs.closedxml.io/en/latest/features/bulk-insert-data.html
// https://github.com/ClosedXML/ClosedXML/tree/develop


namespace ExcelLibraryTesting.ClosedXmlClasses
{
    static class ClosedXml
    {
        const string filePath = @"C:\temp\Excel_ClosedXmlTest.xlsx";

        public static void CreateExcelWorkbook()
        {
            Helper.DeleteExistingFile(filePath);
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet();

                wb.SaveAs(filePath);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Create Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void ReadExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet(1);

                var cells = ws.Range("A1:E1").CellsUsed().Select(c => c.Value).ToList();
                foreach (string result in cells)
                {
                    Console.WriteLine(result);
                }
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Read Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet(1);

                // Write same value to two cells.
                ws.Cells("A1:A5").Value = "Pizza!";

                // Write range to cells.
                string[] things = new[] { "WOW!!", "Hamburger", "Cars", "Trees" };
                ws.Cell("B1").InsertData(things, true);

                wb.SaveAs(filePath);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Write Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataList(List<int> data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet(1);

                // Write range to cells.
                ws.Cell("F1").InsertData(data);

                wb.SaveAs(filePath);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataList Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataTable(System.Data.DataTable data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet(1);

                // Write range to cells.
                ws.Cell("A6").InsertTable(data);

                wb.SaveAs(filePath);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataTable Execution Time: {watch.ElapsedMilliseconds} ms");
        }

    }
}

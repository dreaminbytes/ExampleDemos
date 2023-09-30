using ClosedXML.Excel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

                //ws.Cell("A1").Value = "Apple";
                //ws.Cell("A2").Value = "Banana";
                //ws.Cell("A3").Value = "Grape";
                //ws.Cell("B1").Value = "Wine";
                //ws.Cell("B2").Value = "Beer";
                //ws.Cell("B3").Value = "Sugar";

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
                //ws.Cell("A1").Value = "Pizza!";
                //ws.Cell("A2").Value = "Pizza!";
                //ws.Cell("A3").Value = "Pizza!";
                //ws.Cell("A4").Value = "Pizza!";
                //ws.Cell("A5").Value = "Pizza!";
                ws.Cells("A1:A5").Value = "Pizza!";

                // Write range to cells.
                string[] things = new[] { "WOW!!", "Hamburger", "Cars", "Trees" };
                //ws.Cell("B1").InsertData(things);
                ws.Cell("B1").InsertData(things, true);

                wb.SaveAs(filePath);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Write Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelData(List<int> data)
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
            Console.WriteLine($"WriteExcelData Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}

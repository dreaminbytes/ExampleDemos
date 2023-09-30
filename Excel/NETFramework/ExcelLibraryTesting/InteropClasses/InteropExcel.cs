using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExcelLibraryTesting.InteropClasses
{
    static class InteropExcel
    {
        const string filePath = @"C:\temp\Excel_InteropTest.xlsx";

        public static void CreateExcelWorkbook()
        {
            Helper.DeleteExistingFile(filePath);
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Add("");
            //Worksheet ws = wb.Worksheets[1];

            wb.SaveAs(filePath);
            wb.Close();
            excel.Quit();
            excel = null;

            //------------
            watch.Stop();
            Console.WriteLine($"Create Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void ReadExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filePath);
            Worksheet ws = wb.Worksheets[1];

            Range cell = ws.Range["A1:E1"];
            foreach (string result in cell.Value)
            {
                Console.WriteLine(result);
            }

            wb.Close();
            excel.Quit();
            excel = null;

            //------------
            watch.Stop();
            Console.WriteLine($"Read Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filePath);
            Worksheet ws = wb.Worksheets[1];

            // Write same value to two cells.
            Range cells = ws.Range["A1:A5"];
            cells.Value = "Pizza!";

            // Write range to cells.
            Range cellRange = ws.Range["B1:E1"];
            string[] things = new[] { "WOW!!", "Hamburger", "Cars", "Trees" };
            cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, things);

            wb.Save();
            //excel.DisplayAlerts = false;    // Use to hide overwrite file alerts
            //wb.SaveAs(filePath, AccessMode: XlSaveAsAccessMode.xlNoChange);
            //wb.SaveAs(filePath);
            wb.Close();
            excel.Quit();
            excel = null;

            //------------
            watch.Stop();
            Console.WriteLine($"Write Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelData(List<int> data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filePath);
            Worksheet ws = wb.Worksheets[1];

            // Write range to cells.
            //Range cellRange = ws.Range[$"F1:F{data.Count}"];
            //string[] things = new[] { "WOW!!", "Hamburger", "Cars", "Trees" };
            //cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, data);

            object[,] allData1 = new object[data.Count,1];
            for (int i = 0; i < data.Count; i++)
            {
                allData1[i, 0] = data[i];
            }

            Range cellRange = ws.UsedRange.Range["F1", $"F{data.Count}"];
            cellRange.Value2 = allData1;

            wb.Save();
            wb.Close();
            excel.Quit();
            excel = null;

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelData Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}

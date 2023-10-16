using SwiftExcel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Useful Links:
//
//

namespace ExcelLibraryTesting.SwiftExcelClasses
{

    static class SwiftExcelClass
    {
        const string filePath = @"C:\temp\Excel_SwiftExcelTest.xlsx";
        const string filePath2 = @"C:\temp\Excel_SwiftExcelTest2.xlsx";
        const string filePath3 = @"C:\temp\Excel_SwiftExcelTest3.xlsx";

        public static void CreateExcelWorkbook()
        {
            Helper.DeleteExistingFile(filePath);
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            var sheet = new Sheet
            {
                Name = "Monthly Report",
                ColumnsWidth = new List<double> { 10, 12, 8, 8, 35 }
            };

            //var ew = new ExcelWriter(filePath, sheet);
            var ew = new ExcelWriter(filePath);
            ew.Dispose();

            //------------
            watch.Stop();
            Console.WriteLine($"Create Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void ReadExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            //todo ReadExcel - if it can do it??
            Console.WriteLine("SKIP ReadExcel Test - Does not have read capability.");
            //using(var wb = new ExcelWriter(filePath))
            //{
            //    var ws = new Sheet();
            //    ws.
            //}

            //using (var wb = new XLWorkbook(filePath))
            //{
            //    var ws = wb.Worksheet(1);

            //    var cells = ws.Range("A1:E1").CellsUsed().Select(c => c.Value).ToList();
            //    foreach (string result in cells)
            //    {
            //        Console.WriteLine(result);
            //    }
            //}

            //------------
            watch.Stop();
            Console.WriteLine($"Read Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            //todo WriteExcel
            var ws = new Sheet() { Name = "sheet1" };
            using (var wb = new ExcelWriter(filePath, ws))
            {

                // Write same value to two cells.
                wb.Write("Pizza!", 1, 1);

                wb.Write("WOW!!", 2, 1);
                wb.Write("Hamburger", 3, 1);
                wb.Write("Cars", 4, 1);
                wb.Write("Trees", 5, 1);

                wb.Write("Pizza!", 1, 2);
                wb.Write("Pizza!", 1, 3);
                wb.Write("Pizza!", 1, 4);
                wb.Write("Pizza!", 1, 5);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Write Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataList(List<int> data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            //todo WriteExcelDataList
            var ws = new Sheet(); // { Name = "sheet2" };
            using (var ew = new ExcelWriter(filePath3, ws))
            {
                for (var row = 0; row < data.Count; row++)
                {
                    ew.Write(data[row].ToString(), 6, row+1, DataType.Number);
                }
            }

            //using (var wb = new XLWorkbook(filePath))
            //{
            //    var ws = wb.Worksheet(1);

            //    // Write range to cells.
            //    ws.Cell("F1").InsertData(data);

            //    wb.SaveAs(filePath);
            //}

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataList Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataTable(System.Data.DataTable data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            //todo WriteExcelDataTable
            var ws = new Sheet(); // { Name = "sheet2" };
            using (var ew = new ExcelWriter(filePath2, ws))
            {
                for (var row = 0; row < data.Rows.Count; row++)
                {
                    for (var col = 0; col < data.Columns.Count; col++)
                    {
                        if (col == 0) // number
                            ew.Write(data.Rows[row][col].ToString(), col+1, row + 6, DataType.Number);
                        else
                            ew.Write(data.Rows[row][col].ToString(), col+1, row + 6);
                    }
                }
            }

            //using (var wb = new XLWorkbook(filePath))
            //{
            //    var ws = wb.Worksheet(1);

            //    // Write range to cells.
            //    ws.Cell("A6").InsertTable(data);

            //    wb.SaveAs(filePath);
            //}

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataTable Execution Time: {watch.ElapsedMilliseconds} ms");
        }

    }
}

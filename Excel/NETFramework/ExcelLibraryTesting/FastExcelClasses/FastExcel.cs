using DocumentFormat.OpenXml.Office2010.ExcelAc;

using FastExcel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ExcelLibraryTesting.FastExcelClasses
{
    static class FastExcelClass
    {
        const string filePath = @"C:\temp\Excel_FastExcelTest.xlsx";
        const string templatefilePath = @"C:\temp\Template.xlsx";

        public static void CreateExcelWorkbook()
        {
            Helper.DeleteExistingFile(filePath);
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(templatefilePath), new FileInfo(filePath)))
            {
                //Create a worksheet with some rows
                var worksheet = new Worksheet();
                var rows = new List<Row>();
                //for (int rowNumber = 1; rowNumber < 100; rowNumber++)
                //{
                //    var cells = new List<Cell>();
                //    for (int columnNumber = 1; columnNumber < 13; columnNumber++)
                //    {
                //        cells.Add(new Cell(columnNumber, columnNumber * DateTime.Now.Millisecond));
                //    }
                //    cells.Add(new Cell(13, "FileFormat" + rowNumber));
                //    cells.Add(new Cell(14, "FileFormat Developer Guide"));

                //    rows.Add(new Row(rowNumber, cells));
                //}
                worksheet.Rows = rows;

                fastExcel.Write(worksheet, "sheet1");
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Create Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void ReadExcel()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(filePath), true))
            {
                var worksheet = fastExcel.Read("sheet1");

                var cells = worksheet.GetCellsInRange(new CellRange("A1", "E1"));
                foreach (var result in cells)
                {
                    Console.WriteLine(result.Value);
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

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(filePath)))
            {
                //var worksheet = fastExcel.Read("sheet1");

                //var cells = worksheet.GetCellsInRange(new CellRange("A1", "A5"));
                //foreach (var cell in cells)
                //{
                //    cell.Value = "Pizza!";
                //}
                //worksheet.PopulateRows(cells);

                var worksheet = new Worksheet(fastExcel);
                var rows = new List<Row>();
                
                for (int rowNumber = 1; rowNumber <= 5; rowNumber ++)
                {
                    List<Cell> cells = new List<Cell>();
                    //for (int columnNumber = 1; columnNumber < 13; columnNumber += 2)
                    //{
                    //    cells.Add(new Cell(columnNumber, rowNumber));
                    //}
                    cells.Add(new Cell(1, "Pizza!"));

                    rows.Add(new Row(rowNumber, cells));
                }
                worksheet.Rows = rows;
                fastExcel.Update(worksheet, "sheet1");

                //string[] things = new[] { "WOW!!", "Hamburger", "Cars", "Trees" };
                //var things = new[] { "WOW!!", "Hamburger", "Cars", "Trees" };
                var rows2 = new List<Row>();
                var cells2 = new List<Cell>();
                cells2.Add(new Cell(2, "Woo"));
                cells2.Add(new Cell(3, "Woo"));
                cells2.Add(new Cell(4, "Woo"));
                cells2.Add(new Cell(5, "Woo"));
                rows2.Add(new Row(1, cells2));

                //var cells2 = worksheet.GetCellsInRange(new CellRange("B1", "B4"));
                //foreach (var cell in cells2)
                //{
                //    cell.Value = "Wow!!";
                //}
                //worksheet.PopulateRows(rows);

                worksheet.Rows = rows2;

                fastExcel.Update(worksheet, "sheet1");
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Read Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void tmp2()
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            //------------
            watch.Stop();
            Console.WriteLine($"Read Execution Time: {watch.ElapsedMilliseconds} ms");
        }

    }
}

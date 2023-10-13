using FastExcel;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

// Ref: https://github.com/ahmedwalid05/FastExcel

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
                var worksheet = new Worksheet(fastExcel);
                var rows = new List<Row>();
                
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
                var worksheet = new Worksheet(fastExcel);
                var rows = new List<Row>();

                // Write same value to two cells.
                for (int rowNumber = 1; rowNumber <= 5; rowNumber ++)
                {
                    List<Cell> cells = new List<Cell>();
                    cells.Add(new Cell(1, "Pizza!"));
                    rows.Add(new Row(rowNumber, cells));
                }
                worksheet.Rows = rows;
                fastExcel.Update(worksheet, "sheet1");

                // Write range to cells.
                var rows2 = new List<Row>();
                var cells2 = new List<Cell>
                {
                    new Cell(2, "Wow!!"),
                    new Cell(3, "Hamburger"),
                    new Cell(4, "Cars"),
                    new Cell(5, "Trees")
                };
                rows2.Add(new Row(1, cells2));

                worksheet.Rows = rows2;
                fastExcel.Update(worksheet, "sheet1");
            }

            //------------
            watch.Stop();
            Console.WriteLine($"Write Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataList(List<int> data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---
                        
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(filePath)))
            {
                var worksheet = new Worksheet(fastExcel);
                var rows = new List<Row>();

                for (int rowNumber = 1; rowNumber <= data.Count; rowNumber++)
                {
                    var cells = new List<Cell>();
                    cells.Add(new Cell(6, data[rowNumber-1]));
                    rows.Add(new Row(rowNumber, cells));
                }

                // Write range to cells.
                worksheet.Rows = rows;
                //?? worksheet.PopulateRows(data);
                fastExcel.Update(worksheet, "sheet1");
            }

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataList Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataTable(DataTable data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(filePath)))
            {
                var worksheet = new Worksheet(fastExcel);
                
                // Issue: Can't preserve number list when writting table.
                // So write data table test first before number list.
                worksheet.PopulateRowsFromDataTable(data, 5);

                //error - fastExcel.Update(worksheet, "sheet1");
                fastExcel.Write(worksheet, "sheet1", 5);
            }

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataTable Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}

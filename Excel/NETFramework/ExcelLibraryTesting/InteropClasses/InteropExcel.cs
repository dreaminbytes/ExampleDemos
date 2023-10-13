using Microsoft.Office.Interop.Excel;

using System;
using System.Collections.Generic;
using System.Diagnostics;

// Ref: https://learn.microsoft.com/en-us/answers/questions/1144394/export-data-to-excel-from-table-with-modified-valu


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

        public static void WriteExcelDataList(List<int> data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filePath);
            Worksheet ws = wb.Worksheets[1];

            // Write range to cells.
            object[,] allData1 = new object[data.Count, 1];
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
            Console.WriteLine($"WriteExcelDataList Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataTable(System.Data.DataTable data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filePath);
            Worksheet ws = wb.Worksheets[1];

            //// Try 1 - Write data table to cells.
            //var rowcount = data.Rows.Count;
            //Range cellRange = ws.Range[ws.Cells[6,1], ws.Cells[rowcount, data.Columns.Count]];
            ////cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, data);
            //cellRange.Value2 = data;

            // Try 2 - Write data table to cells.
            for (int col = 0; col < data.Columns.Count; col++)
            {
                ws.Range["A6"].Offset[0, col].Value = data.Columns[col].ColumnName;
            }
            for (int row = 0; row < data.Rows.Count; row++)
            {
                ws.Range["A7"].Offset[row].Resize[1, data.Columns.Count].Value =
                data.Rows[row].ItemArray;
            }

            wb.Save();
            wb.Close();
            excel.Quit();
            excel = null;

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataTable Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void WriteExcelDataTableImproved(System.Data.DataTable data)
        {
            var watch = new Stopwatch(); watch.Start();
            //--- start test ---

            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filePath);
            Worksheet ws = wb.Worksheets[2];
            
            var iCols = data.Columns.Count;
            var iRows = data.Rows.Count;
            object[,] objData = new object[iRows, iCols];

            // Write data table to object.
            for (int row = 0; row < iRows; row++)
            {
                for(var column = 0; column < iCols; column++)
                {
                    objData[row, column] = data.Rows[row][column];
                }
            }
            // NOTE: DateTime Formatting is lost in this code (even though it's faster)

            // Write headers
            for (int col = 0; col < data.Columns.Count; col++)
                ws.Range["A6"].Offset[0, col].Value = data.Columns[col].ColumnName;
                        
            // Write object data to cells.
            //ws.Range["A7"].Value2 = objData;
            //Range rng = ws.UsedRange.Range["A7", "D"+iRows];
            Range rng = ws.Range["A7", "D"+iRows];
            rng.Value2 = objData;


            wb.Save();
            wb.Close();
            excel.Quit();
            excel = null;

            //------------
            watch.Stop();
            Console.WriteLine($"WriteExcelDataTableImproved Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}

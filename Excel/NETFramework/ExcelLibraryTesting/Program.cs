using ExcelLibraryTesting.ClosedXmlClasses;
using ExcelLibraryTesting.FastExcelClasses;
using ExcelLibraryTesting.InteropClasses;
using ExcelLibraryTesting.SwiftExcelClasses;

using System;
using System.Threading;

namespace ExcelLibraryTesting
{
    static class Program
    {
        const int WaitBetweentests = 3000;

        static void Main(string[] args)
        {
            // Set up
            var listData = Helper.listOfNumbers;
            var dataTable = Helper.GetDataTable();

            #region Test Interop Excel
            if (1 == 11)
            {
                Console.WriteLine($"Start Test1 {DateTime.Now} - Interop");

                InteropExcel.CreateExcelWorkbook();     // First Test Create file
                InteropExcel.WriteExcel();              // Then test write to file
                InteropExcel.ReadExcel();               // Then test read file
                InteropExcel.WriteExcelDataTable(dataTable);
                InteropExcel.WriteExcelDataTableImproved(dataTable);
                InteropExcel.WriteExcelDataList(listData);

                Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
                Thread.Sleep(WaitBetweentests);
            }
            #endregion

            #region Test ClosedXml Excel
            if (1 == 11)
            {
                Console.WriteLine($"Start Test2 {DateTime.Now} - ClosedXml");

                ClosedXml.CreateExcelWorkbook();        // First Test Create file
                ClosedXml.WriteExcel();                 // Then test write to file
                ClosedXml.ReadExcel();                  // Then test read file
                ClosedXml.WriteExcelDataTable(dataTable);
                ClosedXml.WriteExcelDataList(listData);

                Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
                Thread.Sleep(WaitBetweentests);
            }
            #endregion

            #region Test FastExcel
            if (1 == 11)
            {
                Console.WriteLine($"Start Test3 {DateTime.Now} - FastExcel");

                FastExcelClass.CreateExcelWorkbook();     // First Test Create file
                FastExcelClass.WriteExcel();              // Then test write to file
                FastExcelClass.ReadExcel();               // Then test read file
                FastExcelClass.WriteExcelDataTable(dataTable);
                FastExcelClass.WriteExcelDataList(listData);

                Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
                Thread.Sleep(WaitBetweentests);
            }
            #endregion

            #region Test SwiftExcel
            if (1 == 1)
            {
                Console.WriteLine($"Start Test4 {DateTime.Now} - SwiftExcel");

                SwiftExcelClass.CreateExcelWorkbook();     // First Test Create file
                SwiftExcelClass.WriteExcel();              // Then test write to file
                SwiftExcelClass.ReadExcel();               // Then test read file
                SwiftExcelClass.WriteExcelDataTable(dataTable);
                SwiftExcelClass.WriteExcelDataList(listData);

                Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
                Thread.Sleep(WaitBetweentests);
            }
            #endregion


            //#region Test ClosedXml Excel
            //Console.WriteLine("Start Test3 " + DateTime.Now);

            //ClosedXml.CreateExcelWorkbook();        // First Test Create file
            //ClosedXml.WriteExcel();                 // Then test write to file
            //ClosedXml.ReadExcel();                  // Then test read file

            //Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
            //Thread.Sleep(WaitBetweentests);
            //#endregion

            //#region Test ClosedXml Excel
            //Console.WriteLine("Start Test4 " + DateTime.Now);

            //InteropExcel.CreateExcelWorkbook();     // First Test Create file
            //InteropExcel.WriteExcel();              // Then test write to file
            //InteropExcel.ReadExcel();               // Then test read file

            //Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
            //Thread.Sleep(WaitBetweentests);
            //#endregion




            Console.WriteLine("Press a key to exit.");
            Console.ReadLine();
        }
    }
}

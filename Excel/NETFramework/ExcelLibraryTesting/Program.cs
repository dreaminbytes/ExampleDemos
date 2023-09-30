using ExcelLibraryTesting.ClosedXmlClasses;
using ExcelLibraryTesting.FastExcelClasses;
using ExcelLibraryTesting.InteropClasses;

using System;
using System.Threading;

namespace ExcelLibraryTesting
{
    static class Program
    {
        const int WaitBetweentests = 5000;

        static void Main(string[] args)
        {
            #region Test FastExcel
            Console.WriteLine("Start Test1 " + DateTime.Now);

            FastExcelClass.CreateExcelWorkbook();     // First Test Create file
            FastExcelClass.WriteExcel();              // Then test write to file
            //FastExcelClass.ReadExcel();               // Then test read file
            //InteropExcel.WriteExcelData(Helper.listOfNumbers);

            Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
            Thread.Sleep(WaitBetweentests);
            #endregion


            #region Test Interop Excel
            Console.WriteLine("Start Test1 " + DateTime.Now);

            InteropExcel.CreateExcelWorkbook();     // First Test Create file
            InteropExcel.WriteExcel();              // Then test write to file
            InteropExcel.ReadExcel();               // Then test read file
            InteropExcel.WriteExcelData(Helper.listOfNumbers);

            Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
            Thread.Sleep(WaitBetweentests);
            #endregion

            #region Test ClosedXml Excel
            Console.WriteLine("Start Test2 " + DateTime.Now);

            ClosedXml.CreateExcelWorkbook();        // First Test Create file
            ClosedXml.WriteExcel();                 // Then test write to file
            ClosedXml.ReadExcel();                  // Then test read file
            ClosedXml.WriteExcelData(Helper.listOfNumbers);

            Console.WriteLine("End " + DateTime.Now + Environment.NewLine);
            Thread.Sleep(WaitBetweentests);
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

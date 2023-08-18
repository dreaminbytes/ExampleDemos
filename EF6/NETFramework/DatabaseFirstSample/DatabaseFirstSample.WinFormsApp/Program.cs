using System;
using System.Windows.Forms;

// Ref: https://learn.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms

namespace DatabaseFirstSample.WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

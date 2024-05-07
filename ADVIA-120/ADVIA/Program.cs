using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ADVIA2120
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            args = new string[] { "ADVIA120" };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmloading(args));
        }
    }
}
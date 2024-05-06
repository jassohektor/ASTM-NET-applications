using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DIMENSIONRL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            args = new string[] { "IMM" };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmImmulite(args));
        }
    }
}
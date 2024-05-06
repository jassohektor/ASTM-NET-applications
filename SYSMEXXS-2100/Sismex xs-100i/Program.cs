using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sismex_xs_100i
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {

            args = new string[] { "SYSMEXXE2100"};
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Sysmex100i(args));
        }
    }
}
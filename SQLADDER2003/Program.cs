using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SQLADDER2003
{
    static class Program
    {
        /// <summary>
        /// Made by Bartosz Chrominski aka Marvetick
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaHotel
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
            Application.Run(new FrbaHotel.ABM_de_Usuario.Form1());
           //Application.Run(new ABM_de_Cliente.Modificacion_Cliente());
        }
    }
}

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
<<<<<<< HEAD
            Application.Run(new ABM_de_Hotel.MainHotel());
           //Application.Run(new ABM_de_Cliente.Modificacion_Cliente());
=======
            Application.Run(new FrbaHotel.ABM_de_Usuario.Form1());
>>>>>>> 87806b3882470fbb62139c2fd7b2b54f73cab55c
        }
    }
}

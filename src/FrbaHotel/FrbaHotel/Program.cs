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
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.RegistroCliente(27501));
            //Application.Run(new Listado_Estadistico.Form1());
            //Application.Run(new FrbaHotel.ABM_de_Rol.MainRol());
            //Application.Run(new FrbaHotel.Cancelar_Reserva.Form1(1,"admin","Administrador General"));
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(1,"guest"));
            Application.Run(new FrbaHotel.Generar_Modificar_Reserva.ModificarReserva("admin","777990e8",1));
            //Application.Run(new ABM_de_Cliente.Modificacion_Cliente());
        }
    }
}

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
            // Application.Run(new FrbaHotel.ABM_de_Rol.MainRol());
            Application.Run(new FrbaHotel.Login.Form1());
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.RegistroCliente(27501));            
            //Application.Run(new Listado_Estadistico.Form1());
            //Application.Run(new FrbaHotel.ABM_de_Hotel.MainHotel(1));
            //Application.Run(new FrbaHotel.ABM_de_Habitacion.MainHabitacion());            
            //Application.Run(new FrbaHotel.Cancelar_Reserva.Form1(1,"admin","Administrador General",true));
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(1,"guest"));
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(1,"guest"));
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.GenerarReserva(1,"admin"));
            //Application.Run(new FrbaHotel.Generar_Modificar_Reserva.ModificarReserva("admin","761e2028",1));
            //Application.Run( new FrbaHotel.Registrar_Consumible.Form1(1,"11111111"));
            }
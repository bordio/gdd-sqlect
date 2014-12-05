using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{
    class appModel_ConfirmarReserva_Cliente : AppModel_Base_Cliente
    {
        int idReservaDelCliente;
        
        public appModel_ConfirmarReserva_Cliente(int idReserva)
        {
            this.idReservaDelCliente = idReserva;
        }

        public virtual void Accionarbt_ConfirmarReserva(string emailSeleccionado, int documentoSeleccionado, ModificacionMain_Cliente modificacionMain) {
            FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva formConfirmarCliente = new FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva(emailSeleccionado, documentoSeleccionado, idReservaDelCliente, modificacionMain);
            formConfirmarCliente.ShowDialog();
        }

    }
}
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
        public int huespedes;

        public appModel_ConfirmarReserva_Cliente(int cantHuespedes)
        {
            this.huespedes = cantHuespedes;
        }

        public virtual void Accionarbt_ConfirmarReserva(string emailSeleccionado, int documentoSeleccionado, int idReservaDelCliente, ModificacionMain_Cliente modificacionMain) {
            FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva formConfirmarCliente = new FrbaHotel.Generar_Modificar_Reserva.ConfirmarClienteReserva(emailSeleccionado, documentoSeleccionado, idReservaDelCliente, modificacionMain);
             formConfirmarCliente.ShowDialog();
        }


        public virtual void Accionarbt_AltaHuesped() { }
        public virtual void Accionarbt_Modificar(ModificacionMain_Cliente modificacionMain, DataGridView gridClientes, StringBuilder emailSeleccionado, StringBuilder documentoSeleccionado, StringBuilder tipodocSeleccionado) { }

        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipo_documento, string telefono, string localidad, ComboBox pais)
        {
        }

        public override void levantar(StringBuilder sentence, int posicionId)
        {
        }

    }
}
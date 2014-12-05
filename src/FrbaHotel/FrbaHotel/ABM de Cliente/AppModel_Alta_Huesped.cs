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
    class AppModel_Alta_Huesped : AppModel_Base_Cliente
    {
        public int huespedes;

        public AppModel_Alta_Huesped(int cantHuespedes)
        {
            this.huespedes = cantHuespedes;
        }

        public void AccionarbtModificar(ModificacionMain_Cliente modificacionMain, DataGridView gridClientes, StringBuilder emailSeleccionado, StringBuilder documentoSeleccionado, StringBuilder tipodocSeleccionado)
        {
           
        }

        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipo_documento, string telefono, string localidad, ComboBox pais)
        {  
        }

        public override void levantar(StringBuilder sentence, int posicionId)
        {
        }

    }
}
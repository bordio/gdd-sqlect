using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class Alta_Cliente : BaseAltaModificacion_Cliente

    {
        public Alta_Cliente() : base() // Alta comun
        { 
        }

        public Alta_Cliente(int idReserva, FrbaHotel.Generar_Modificar_Reserva.RegistroCliente formulario) : base(idReserva, formulario) //Alta desde proceso de Reserva
        {  
        }

        public Alta_Cliente(int cantHuespedes, ModificacionMain_Cliente modificacionMain) //Alta desde checkIn
            : base(cantHuespedes, modificacionMain)
        {
        }

        public override void validacionesAlGuardar()
        {
            base.validacionesAlGuardar();
            
        }

        public override void btGuardar_Click(object sender, EventArgs e)
        {   
            validacionesAlGuardar();
            base.btGuardar_Click(sender, e);
        }
    }
}

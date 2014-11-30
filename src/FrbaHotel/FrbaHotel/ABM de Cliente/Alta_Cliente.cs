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
    public class Alta_Cliente : BaseAltaModificacion_Cliente

    {
        public Alta_Cliente() : base()
        { 
        }

        public Alta_Cliente(int idReserva) : base()
        {  
        }

        public override void validacionesAlGuardar()
        {
            MessageBox.Show("Entra a validar alta bien", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            base.validacionesAlGuardar();
            
        }

        public override void btGuardar_Click(object sender, EventArgs e)
        {   
            validacionesAlGuardar();
            base.btGuardar_Click(sender, e);
        }
    }
}

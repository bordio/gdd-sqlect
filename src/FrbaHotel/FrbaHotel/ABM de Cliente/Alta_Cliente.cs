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
        public Alta_Cliente() : base()
        { 
        }

        public Alta_Cliente(int idReserva) : base(idReserva)
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

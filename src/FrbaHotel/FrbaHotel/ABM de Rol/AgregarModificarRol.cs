using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FrbaHotel.Commons.Database;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class AgregarModificarRol : Form
    {
        public AgregarModificarRol()
        {
            InitializeComponent();
        } 

        private void AgregarModificarRol_Load(object sender, EventArgs e)
        {
            List<string> funcs = getFunciones();
            for (int i = 0; i < funcs.Count; i++)
            {
                checkedListBox1.Items.Add(funcs[i]);    
            }
        }

        public List<string> getFunciones()
        {
           List<string> funcs = new List<string>();

           DataTable tabla = Conexion.Instance.ejecutarQuery("SELECT id_funcion 'id', nombre 'Funcion' FROM SQLECT.Funcionalidades WHERE estado_func = 1");

           for (int i = 0; i < tabla.Rows.Count; i++)
           {
               funcs.Add(tabla.Rows[i]["Funcion"].ToString());
           }

           return funcs;
       }
    }
}

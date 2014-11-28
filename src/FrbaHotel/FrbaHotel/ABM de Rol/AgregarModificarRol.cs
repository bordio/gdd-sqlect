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
        private bool update;
        private Int32 idRol;

        public AgregarModificarRol(Int32 elIdRol)
        {
            InitializeComponent();

            idRol = elIdRol;
            update = true;
        }

        public AgregarModificarRol(string nombre, string descripcion)
        {
            InitializeComponent();

            txtNombre.Text = nombre;
            txtDescrip.Text = descripcion;
            getFunciones();
            update = false;
        }

        private void AgregarModificarRol_Load(object sender, EventArgs e)
        {
            getFunciones();
        }

        public void getFunciones()
        {
           List<string> funcs = new List<string>();

           DataTable tabla = Conexion.Instance.ejecutarQuery("SELECT id_funcion 'id', nombre 'Funcion' FROM SQLECT.Funcionalidades WHERE estado_func = 1");

           for (int i = 0; i < tabla.Rows.Count; i++)
           {
               chkLstFunc.Items.Add(tabla.Rows[i]["Funcion"].ToString());
           }
       }
    }
}

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
        private Int32 idRol;
        private DataTable funcsRol;

        public AgregarModificarRol()
        {
            InitializeComponent();
            funcsRol = new DataTable();
            getFunciones();
        }

        public AgregarModificarRol(Int32 elIdRol, string nombre, string descripcion, DataTable funciones)
        {
            InitializeComponent();

            idRol = elIdRol;
            txtNombre.Text = nombre;
            txtDescrip.Text = descripcion;
            funcsRol = funciones;
            getFunciones();
        }

        public void getFunciones()
        {

            DataTable tabla = Conexion.Instance.ejecutarQuery("SELECT id_funcion 'id', nombre 'Funcion' FROM SQLECT.Funcionalidades WHERE estado_func = 1");

            foreach(DataRow rowFuncs in tabla.Rows)
            {
                String funcX = rowFuncs["Funcion"].ToString();
                bool check = false;
                foreach (DataRow rowFRol in funcsRol.Rows)
                {
                    String funcRol = rowFRol["Funcion"].ToString();
                    if (funcRol == funcX)
                        check = true;
                }
                chkLstFunc.Items.Add(funcX, check);
            }
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

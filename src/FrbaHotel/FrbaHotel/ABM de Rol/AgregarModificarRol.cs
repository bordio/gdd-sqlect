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

        public AgregarModificarRol()
        {
            InitializeComponent();

            getFunciones();
        }

        public AgregarModificarRol(Int32 elIdRol, string nombre, string descripcion, DataTable funciones)
        {
            InitializeComponent();

            idRol = elIdRol;
            txtNombre.Text = nombre;
            txtDescrip.Text = descripcion;
            getFunciones();
            checkearFuncionesRol(funciones);
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

        private void checkearFuncionesRol(DataTable funciones)
        {
            foreach ( item in chkLstFunc.Items)
            {
                if (funciones.Contains(item.ToString()))
                {
                    
            }
        }
    }
}

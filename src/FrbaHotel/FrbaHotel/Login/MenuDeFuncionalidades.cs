using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.Login
{
    public partial class MenuDeFuncionalidades : Form
    {
        public MenuDeFuncionalidades()
        {
            InitializeComponent();
        }

        private void MenuDeFuncionalidades_Load(object sender, EventArgs e)
        {

        }
        public void cargarFuncionalidades(string rolAsignado)
        {
            label1.Text = string.Format("Listado de funcionalidades del rol: {0}", rolAsignado);
            DataTable elListadoDeFuncionalidades = listarFuncionalidades(rolAsignado);

            tablaDeFuncionalidades.DataSource = elListadoDeFuncionalidades.DefaultView;
            

        }

        public DataTable listarFuncionalidades(string nombreRol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand listadoFunc = new System.Data.SqlClient.SqlCommand();

            listadoFunc.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            listadoFunc.Parameters.Add("@nombreRol", SqlDbType.VarChar);
            listadoFunc.Parameters[contador].Value = nombreRol;
            contador++;

            listadoFunc.CommandText = "SQLECT.listarFuncionalidades";

            DataTable table = cnn.ejecutarQueryConSP(listadoFunc); 

            return table;
        }
    }


}

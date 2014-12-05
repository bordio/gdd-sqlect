using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class BajaUsuario : Form
    {
        public BajaUsuario(string usuario)
        {
            InitializeComponent();
            usuarioADarDeBaja.Text = usuario;
            this.usuarioActual = usuario;
        }

        string usuarioActual;
        private void BajaUsuario_Load(object sender, EventArgs e)
        {

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            inhabilitarUsuario(usuarioADarDeBaja.Text);
            MessageBox.Show("Usuario dado de baja","Operacion confirmada",MessageBoxButtons.OK,MessageBoxIcon.None);
            this.Close();
        }

        public void inhabilitarUsuario(string usuario)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoDarDeBajaUsuario = new System.Data.SqlClient.SqlCommand();
            comandoDarDeBajaUsuario.CommandType = CommandType.StoredProcedure;

            comandoDarDeBajaUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
 
            comandoDarDeBajaUsuario.Parameters[0].Value = usuario;

            comandoDarDeBajaUsuario.CommandText = "SQLECT.darDeBajaUsuario";
            conexion.ejecutarSP(comandoDarDeBajaUsuario);
        
        }
    }
}

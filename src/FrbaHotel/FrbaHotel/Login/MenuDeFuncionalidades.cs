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

        public void mostrarHotelesACargo(string nombreDeUsuario, string rolElegido)
        {
           DataTable tabla = buscarHotelesDisponibles(nombreDeUsuario);

            foreach (DataRow dat in tabla.Rows)
            {
                listaHotelesHabilitados.Items.Add(dat[0]);
            }

            cargarFuncionalidades(rolElegido);

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

        private void listaHotelesHabilitados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (listaHotelesHabilitados.SelectedItem == null)

                MessageBox.Show("Debe seleccionar un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if (string.IsNullOrEmpty(tareaARealizar.Text))
                    MessageBox.Show("Debe seleccionar una tarea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    MessageBox.Show("Accedio correctamente");
            }
            
            
       
        }

       
        
        public DataTable buscarHotelesDisponibles(string nombreUsuario)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoHotelesDisponibles = new System.Data.SqlClient.SqlCommand();

            comandoHotelesDisponibles.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoHotelesDisponibles.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoHotelesDisponibles.Parameters[contador].Value = nombreUsuario;
            contador++;


            comandoHotelesDisponibles.CommandText = "SQLECT.buscarHotelesDisponibles";
            DataTable tablaHoteles = cnn.ejecutarQueryConSP(comandoHotelesDisponibles);
            return tablaHoteles;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tablaDeFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaDeFuncionalidades_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tareaARealizar.Text = tablaDeFuncionalidades.CurrentRow.Cells[0].Value.ToString();
        }

       
    }



}

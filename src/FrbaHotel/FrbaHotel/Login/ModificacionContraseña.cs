using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.Commons.FuncionalidadesVarias;
using FrbaHotel.Commons.Database;

namespace FrbaHotel.Login
{
    public partial class ModificacionContraseña : Form
    {
        public ModificacionContraseña(string usuarioDeSesionActual)
        {
            InitializeComponent();
            this.usuarioDeSesion= usuarioDeSesionActual;
            
            nombreDelUsuario.Visible = true;
            nombreDelUsuario.Text = usuarioDeSesionActual;
        }
        private AppModel_Alta_Usuario funcionesValidacion = new AppModel_Alta_Usuario();
        private Funcionalidades funcionesVarias = new Funcionalidades();
        string usuarioDeSesion;
        StringBuilder mensajeDeAviso= new StringBuilder();

        private void button1_Click(object sender, EventArgs e)
        {
            /*Valido campos en blanco*/
            bool contraActualOK = funcionesValidacion.validarNoVacio(contraseñaActual, mensajeDeAviso);
            bool contraNuevaOK = funcionesValidacion.validarNoVacio(contraseñaNueva, mensajeDeAviso);
            bool contraConfirOK = funcionesValidacion.validarNoVacio(contraseñaConfirmada, mensajeDeAviso);

            if (contraActualOK && contraNuevaOK && contraConfirOK)
            {
                if (validarPassword(usuarioDeSesion, contraseñaActual.Text) && (contraseñaNueva.Text == contraseñaConfirmada.Text))
                {
                    modificarPassword(usuarioDeSesion, contraseñaNueva.Text);
                    MessageBox.Show("Contraseña cambiada correctamente");
                }
                else
                {
                    if (!validarPassword(usuarioDeSesion, contraseñaActual.Text))
                     MessageBox.Show("Contraseña incorrecta"); 
                    else
                    MessageBox.Show("La contraseña confirmada difiere de la nueva"); 
                }
            
            }
            else
                MessageBox.Show(mensajeDeAviso.ToString());
            mensajeDeAviso.Remove(0, mensajeDeAviso.Length);


        }

        public bool validarPassword(string usuarioDeSesion, string password)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAUsuario = new System.Data.SqlClient.SqlCommand();
            comandoAUsuario.CommandType = CommandType.StoredProcedure;

            string passHasheada = funcionesVarias.encriptarPassword(password);

            comandoAUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoAUsuario.Parameters.Add("@password", SqlDbType.VarChar);
        

            comandoAUsuario.Parameters[0].Value = usuarioDeSesion;
            comandoAUsuario.Parameters[1].Value = passHasheada;


            comandoAUsuario.CommandText = "SQLECT.validarPassword";
            bool passwordCorrecta = conexion.ejecutarEscalar(comandoAUsuario);

            return passwordCorrecta;
            
            
        }

        public void modificarPassword(string usuario, string nuevaPassword)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoModificarPassword = new System.Data.SqlClient.SqlCommand();
            comandoModificarPassword.CommandType = CommandType.StoredProcedure;

            string passHasheada = funcionesVarias.encriptarPassword(nuevaPassword);

            comandoModificarPassword.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoModificarPassword.Parameters.Add("@passwordNueva", SqlDbType.VarChar);


            comandoModificarPassword.Parameters[0].Value = usuarioDeSesion;
            comandoModificarPassword.Parameters[1].Value = passHasheada;


            comandoModificarPassword.CommandText = "SQLECT.modificarPassword";
            conexion.ejecutarSP(comandoModificarPassword);

        }


    }


}

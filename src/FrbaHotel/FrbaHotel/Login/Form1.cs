using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.Commons;
using System.Security.Cryptography;
using FrbaHotel.Commons.FuncionalidadesVarias;

namespace FrbaHotel.Login
{
    public partial class Form1 : Form
    {
        const int numeroDeIntentos = 3;
  
        public Form1()
        {
            InitializeComponent();
           
        }
        private Funcionalidades funciones = new Funcionalidades();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkUsuarioRegis.Checked)
            {
                Generar_Modificar_Reserva.Form1 generarReserva = new Generar_Modificar_Reserva.Form1(0,"guest");
                generarReserva.ShowDialog();

            }

            else
            {
                if (string.IsNullOrEmpty(textUsuario.Text) || string.IsNullOrEmpty(textPass.Text) || comboBoxRol.SelectedIndex == -1)
                    MessageBox.Show("Complete todos los campos", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    if (!funciones.chequearExistenciaDeUsuarioYRol(textUsuario.Text,comboBoxRol.SelectedItem.ToString())) /*Chequeo si existe el usuario y su rol asignado*/
                    {
                        MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        int intentosActual = intentosRealizados(textUsuario.Text, comboBoxRol.SelectedItem.ToString());

                      if (intentosActual<numeroDeIntentos)
                         
                      { string passHasheada = funciones.encriptarPassword(textPass.Text);

                      if (validarUsuario(textUsuario.Text, passHasheada, comboBoxRol.SelectedItem.ToString())) /*Me fijo si ingreso la pass correctamente*/
                      {
                          limpiarCantidadDeIntentos(textUsuario.Text, comboBoxRol.SelectedItem.ToString());
                         
                          
                          Login.MenuDeFuncionalidades listadoDeFuncionalidades = new MenuDeFuncionalidades(textUsuario.Text,comboBoxRol.SelectedItem.ToString());
                          listadoDeFuncionalidades.ShowDialog();
                          
                          
                      }
                      else
                      {
                          intentosActual++;
                          actualizarIntentosFallidos(textUsuario.Text, comboBoxRol.SelectedItem.ToString());
                          if (intentosActual == numeroDeIntentos)
                          {
                              funciones.inhabilitarUsuario(textUsuario.Text);
                              MessageBox.Show(string.Format("El usuario {0} quedó bloqueado", textUsuario.Text));
                          }
                          else
                          {

                              MessageBox.Show(string.Format("Password incorrecto, le queda {0} intentos", numeroDeIntentos - intentosActual), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          }
                      
                      }
                       
                         
                      }
                      else
                          MessageBox.Show("Usuario bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             
                        
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkUsuarioRegis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUsuarioRegis.Checked)
            {
                labelUsuario.Visible = true; labelPass.Visible = true; labelRol.Visible = true;
                textUsuario.Visible = true; textPass.Visible = true; comboBoxRol.Visible = true;

                StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT r.nombre FROM SQLECT.Roles r WHERE r.estado_rol=1 AND r.nombre<>'Guest'");
                DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

                foreach (DataRow dat in tabla.Rows)
                {

                    comboBoxRol.Items.Add(dat[0]);
                }
            }
            else
            {
                comboBoxRol.Items.Clear();
                labelUsuario.Visible = false; labelPass.Visible = false; labelRol.Visible = false;
                textUsuario.Visible = false; textPass.Visible = false; comboBoxRol.Visible = false;
            }
        }
        public bool validarUsuario(string usuario, string password, string rol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoValidacion = new System.Data.SqlClient.SqlCommand();

            comandoValidacion.CommandType = CommandType.StoredProcedure;
            int contador = 0;


            comandoValidacion.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoValidacion.Parameters[contador].Value = usuario;
            contador++;


            comandoValidacion.Parameters.Add("@password", SqlDbType.VarChar);
            comandoValidacion.Parameters[contador].Value = password;
            contador++;

            comandoValidacion.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoValidacion.Parameters[contador].Value = rol;
            contador++;


            comandoValidacion.CommandText = "SQLECT.validarUsuarioLogin";

            bool validacion = cnn.ejecutarEscalar(comandoValidacion);

            return validacion;
        }

        public void actualizarIntentosFallidos(string usuario, string rol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoActualizarIntentos = new System.Data.SqlClient.SqlCommand();

            comandoActualizarIntentos.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoActualizarIntentos.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoActualizarIntentos.Parameters[contador].Value = usuario;
            contador++;

            comandoActualizarIntentos.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoActualizarIntentos.Parameters[contador].Value = rol;
            contador++;

            comandoActualizarIntentos.CommandText = "SQLECT.actualizarIntentosFallidos";
            cnn.ejecutarSP(comandoActualizarIntentos);
        
        }

        public int intentosRealizados(string usuario, string rol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoIntentosRealizados = new System.Data.SqlClient.SqlCommand();

            comandoIntentosRealizados.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoIntentosRealizados.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoIntentosRealizados.Parameters[contador].Value = usuario;
            contador++;

            comandoIntentosRealizados.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoIntentosRealizados.Parameters[contador].Value = rol;
            contador++;

            comandoIntentosRealizados.CommandText = "SQLECT.verificarIntentos";

            int intentosRealizados = cnn.ejecutarEscalarInt(comandoIntentosRealizados);
            return intentosRealizados;
        }
    

        public void limpiarCantidadDeIntentos(string usuario, string rol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoInhabilitarUsuario = new System.Data.SqlClient.SqlCommand();

            comandoInhabilitarUsuario.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoInhabilitarUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoInhabilitarUsuario.Parameters[contador].Value = usuario;
            contador++;

            comandoInhabilitarUsuario.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoInhabilitarUsuario.Parameters[contador].Value = rol;
            contador++;

            comandoInhabilitarUsuario.CommandText = "SQLECT.resetearCantidadDeIntentos";
            cnn.ejecutarSP(comandoInhabilitarUsuario);
        
        }
    
    }

}

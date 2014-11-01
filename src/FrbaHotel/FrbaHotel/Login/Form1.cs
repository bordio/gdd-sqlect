using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using System.Security.Cryptography;

namespace FrbaHotel.Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkUsuarioRegis.Checked)
            {
                Generar_Modificar_Reserva.Form1 generarReserva = new Generar_Modificar_Reserva.Form1();
                generarReserva.Show();
            }

            else
            {
                if (string.IsNullOrEmpty(textUsuario.Text) || string.IsNullOrEmpty(textPass.Text) || comboBoxRol.SelectedIndex == -1)
                    MessageBox.Show("Campos incompletos");
                else 
                {
                    string passHasheada = encriptarPassword(textPass.Text);

                    if (validarUsuario(textUsuario.Text, passHasheada, comboBoxRol.SelectedItem.ToString()))
                        MessageBox.Show("Validación exitosa");
                    else
                        MessageBox.Show("Usuario o password incorrecto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        
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
                
                StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT nombre FROM SQLECT.Roles");
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
           
        public string encriptarPassword(string input)
            {
                SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();


                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashedBytes = provider.ComputeHash(inputBytes);


                StringBuilder output = new StringBuilder();


                for (int i = 0; i < hashedBytes.Length; i++)

                    output.Append(hashedBytes[i].ToString("x2").ToLower());


                return output.ToString();
            }

    }

    }


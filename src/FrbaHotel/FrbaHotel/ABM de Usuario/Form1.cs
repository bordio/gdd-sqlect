using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.Commons.FuncionalidadesVarias;
using FrbaHotel.ABM_de_Usuario;

namespace FrbaHotel.ABM_de_Usuario
{
    
    
    public partial class Form1 : Form
    {
      public Form1()
        {
            InitializeComponent();
        }
      private AppModel_Alta_Usuario funcionesUsuarios = new AppModel_Alta_Usuario();
        
    private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT DISTINCT nombre FROM SQLECT.Roles");
            DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

            foreach (DataRow dat in tabla.Rows)
            {

                comboRol.Items.Add(dat[0]);
            }



        }
        public static StringBuilder getAllInstances()
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT u.usr_name 'Nombre', u.estado_usr 'Estado',r.nombre 'Rol' FROM SQLECT.Usuarios u JOIN SQLECT.Roles_Usuarios ru ON (u.id_usuario=ru.fk_usuario) JOIN SQLECT.Roles r ON (r.id_rol = ru.fk_rol)");
            return sentence;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            comboRol.SelectedItem = null;
            radioHabilitado.Checked = false;
            radioInhabilitado.Checked = false;
            tablaDeUsuarios.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder listadoUsuarios = getAllInstances();

            if ((textBoxNombre.Text != "") || (comboRol.SelectedIndex > -1) || (radioHabilitado.Checked != false) || (radioInhabilitado.Checked != false))
            {
                listadoUsuarios.Append(" WHERE ");
                if (textBoxNombre.Text != "") 
                    listadoUsuarios.AppendFormat(" (u.usr_name LIKE '%{0}%') AND ", textBoxNombre.Text);

                if (comboRol.SelectedIndex>-1) 
                    listadoUsuarios.AppendFormat(" (r.nombre = '{0}') AND ", comboRol.SelectedItem.ToString());

                if (radioHabilitado.Checked == true)
                    listadoUsuarios.Append(" (u.estado_usr=1) AND ");
                 else
                {
                    if (radioInhabilitado.Checked == true)
                        listadoUsuarios.Append(" (u.estado_usr=0) AND ");
              }
                StringBuilder listadoUsuariosFiltrados = new StringBuilder().AppendFormat(listadoUsuarios.ToString().Substring(0, listadoUsuarios.Length - 5));
                cargarLista(listadoUsuariosFiltrados);
            }
            else
             cargarLista(listadoUsuarios);
        }

        public void cargarLista(StringBuilder consulta)
        {
            DataTable tabla = Conexion.Instance.ejecutarQuery(consulta.ToString());

            tablaDeUsuarios.DataSource = tabla.DefaultView;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (funcionesUsuarios.nombresHotelesVacios())
            {
                MessageBox.Show("Error", "Todos los hoteles están sin nombre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                ABM_de_Usuario.AltaUsuario formularioAlta = new AltaUsuario();
                formularioAlta.Show();
            }
        }


    }
}

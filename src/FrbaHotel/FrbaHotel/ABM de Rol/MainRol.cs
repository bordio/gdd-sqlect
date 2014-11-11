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
    public partial class MainRol : Form
    {
        public MainRol()
        {
            InitializeComponent();
        }

        private void MainRol_Load(object sender, EventArgs e)
        {
            gridRoles.DataSource = refrescarLista();
        }

        private DataTable refrescarLista() {
            return Conexion.Instance.ejecutarQuery("SELECT nombre 'Rol', descripcion 'Descripción', estado_rol 'Activo' FROM SQLECT.Roles");
        }

        private void bttnNuevo_Click(object sender, EventArgs e)
        {
            AgregarModificarRol formNuevo = new AgregarModificarRol();
            formNuevo.Show();
        }
    }
}

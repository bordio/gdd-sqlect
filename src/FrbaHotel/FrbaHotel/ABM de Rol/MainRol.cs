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

        private Int32 idRolSelecc = -1;
        private List<String> funcionesRolSelecc = null;

        private void MainRol_Load(object sender, EventArgs e)
        {
            gridRoles.DataSource = refrescarLista();
        }

        private DataTable refrescarLista() {
            return Conexion.Instance.ejecutarQuery("SELECT id_rol 'ID', nombre 'Rol', descripcion 'Descripción', estado_rol 'Activo' FROM SQLECT.Roles");
        }

        private void bttnNuevo_Click(object sender, EventArgs e)
        {
            AgregarModificarRol formNuevo = new AgregarModificarRol(idRolSelecc);
            formNuevo.Show();
        }

        public DataTable getFuncionesRolSelecc()
        {
            List<string> funcs = new List<string>();
            StringBuilder sentence = new StringBuilder();
            sentence.AppendFormat("SELECT f.id_funcion 'ID', f.nombre 'Función' FROM SQLECT.Roles r, SQLECT.Funcionalidades f, SQLECT.Funcionalidades_Roles fr WHERE r.id_rol = {0} AND fr.fk_rol = {0} AND f.id_funcion = fr.fk_funcion AND r.estado_rol = 1", this.idRolSelecc);
            
            return Conexion.Instance.ejecutarQuery(sentence.ToString());
        }

        private void gridRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idRolSelecc = Int32.Parse(gridRoles.CurrentRow.Cells[0].Value.ToString());
            gridFunciones.DataSource = getFuncionesRolSelecc();

            bttnEliminar.Enabled = true;
            bttnModificar.Enabled = true;
        }

        private void bttnModificar_Click(object sender, EventArgs e)
        {
            string nombreRolSelecc = gridRoles.CurrentRow.Cells[1].Value.ToString();
            string descripRolSelecc = gridRoles.CurrentRow.Cells[2].Value.ToString();
            
            AgregarModificarRol formNuevo = new AgregarModificarRol(nombreRolSelecc, descripRolSelecc);
            formNuevo.Show();
        }
    }
}

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
        private DataTable funcionesRolSelecc = new DataTable();

        private void MainRol_Load(object sender, EventArgs e)
        {
            getRoles();
        }

        public void getRoles() {
            gridRoles.DataSource = Conexion.Instance.ejecutarQuery("SELECT id_rol 'ID', nombre 'Rol', descripcion 'Descripción', estado_rol 'Activo' FROM SQLECT.Roles");
        }

        private void bttnNuevo_Click(object sender, EventArgs e)
        {
            AgregarModificarRol formNuevo = new AgregarModificarRol(this);
            formNuevo.Show();
        }

        private DataTable getFuncionesRolSelecc()
        {
            StringBuilder sentence = new StringBuilder();
            sentence.AppendFormat("SELECT f.id_funcion 'ID', f.nombre 'Funcion' FROM SQLECT.Roles r, SQLECT.Funcionalidades f, SQLECT.Funcionalidades_Roles fr WHERE r.id_rol = {0} AND fr.fk_rol = {0} AND f.id_funcion = fr.fk_funcion AND r.estado_rol = 1", this.idRolSelecc);
            return Conexion.Instance.ejecutarQuery(sentence.ToString());
        }

        private void bttnModificar_Click(object sender, EventArgs e)
        {
            string nombreRolSelecc = gridRoles.CurrentRow.Cells[1].Value.ToString();
            string descripRolSelecc = gridRoles.CurrentRow.Cells[2].Value.ToString();
            
            AgregarModificarRol formModif = new AgregarModificarRol(this, idRolSelecc ,nombreRolSelecc, descripRolSelecc, funcionesRolSelecc);
            formModif.Show();
        }

        public void gridRoles_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow filaActual = gridRoles.CurrentRow;

            if (filaActual != null)
            {
                idRolSelecc = Int32.Parse(filaActual.Cells[0].Value.ToString());
                funcionesRolSelecc = getFuncionesRolSelecc();
                gridFunciones.DataSource = funcionesRolSelecc;

                bttnModificar.Enabled = true;
                bttnActivar.Enabled = ((Int32.Parse(filaActual.Cells[3].Value.ToString()) == 1) ? false : true);
                bttnDesact.Enabled = ((Int32.Parse(filaActual.Cells[3].Value.ToString()) == 1) ? true : false);
            }
        }

        private void bttnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttnActivar_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder();
            sentence.AppendFormat("UPDATE SQLECT.Roles SET estado_rol = 1 WHERE id_rol = {0}", this.idRolSelecc);
            Conexion.Instance.ejecutarQuery(sentence.ToString());
            getRoles();
        }

        private void bttnDesact_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder();
            sentence.AppendFormat("UPDATE SQLECT.Roles SET estado_rol = 0 WHERE id_rol = {0}", this.idRolSelecc);
            Conexion.Instance.ejecutarQuery(sentence.ToString());
            getRoles();
        }
    }
}

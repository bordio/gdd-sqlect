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
        public MainRol(Login.MenuDeFuncionalidades owner)
        {
            InitializeComponent();
            padre = owner;
        }

        public MainRol()
        {
            InitializeComponent();
        }

        private Login.MenuDeFuncionalidades padre;
        private Int32 idRolSelecc = -1;
        private DataTable funcionesRolSelecc = new DataTable();

        private void MainRol_Load(object sender, EventArgs e)
        {
            refrescarListas();
        }

        public void refrescarListas() 
        {
            gridRoles.DataSource = getRoles();
            gridRoles.Columns[0].Visible = false;
        }

        public DataTable getRoles()
        {
            return Conexion.Instance.ejecutarQuery("SELECT id_rol 'ID', nombre 'Rol', descripcion 'Descripción', CASE estado_rol WHEN 1 THEN 'SI' ELSE 'NO' END 'Activo' FROM SQLECT.Roles");
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
                gridFunciones.Columns[0].Visible = false;

                bttnModificar.Enabled = ((filaActual.Cells[3].Value.ToString() == "SI") ? true : false);
                bttnActivar.Enabled = ((filaActual.Cells[3].Value.ToString() == "SI") ? false : true);
                bttnDesact.Enabled = ((filaActual.Cells[3].Value.ToString() == "SI") ? true : false);
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
            refrescarListas();
        }

        private void bttnDesact_Click(object sender, EventArgs e)
        {
            StringBuilder sentence = new StringBuilder();
            sentence.AppendFormat("UPDATE SQLECT.Roles SET estado_rol = 0 WHERE id_rol = {0}", this.idRolSelecc);
            Conexion.Instance.ejecutarQuery(sentence.ToString());
            refrescarListas();
        }
    }
}

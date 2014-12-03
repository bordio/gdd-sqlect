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
    public partial class AgregarModificarRol : Form
    {
        private Int32 idRol;
        private DataTable funcsRol;
        private ABM_de_Rol.MainRol padre;

        public AgregarModificarRol(ABM_de_Rol.MainRol owner)
        {
            InitializeComponent();
            padre = owner;

            idRol = -1;
            funcsRol = new DataTable();
        }

        public AgregarModificarRol(ABM_de_Rol.MainRol owner, Int32 elIdRol, string nombre, string descripcion, DataTable funciones)
        {
            InitializeComponent();
            padre = owner;

            idRol = elIdRol;
            txtNombre.Text = nombre;
            txtDescrip.Text = descripcion;
            funcsRol = funciones;
            checkFunciones();
        }

        private void checkFunciones()
        {
            List<int> idsFuncs = new List<int>();

            foreach (DataRow rowFRol in funcsRol.Rows)
                idsFuncs.Add(Int32.Parse(rowFRol["ID"].ToString()));

            chkBxGestRol.Checked = ((idsFuncs.Contains(1)) ? true : false);
            chkBxGestUsr.Checked = ((idsFuncs.Contains(2)) ? true : false);
            chkBxGestCli.Checked = ((idsFuncs.Contains(3)) ? true : false);
            chkBxGestHotel.Checked = ((idsFuncs.Contains(4)) ? true : false);
            chkBxGestHab.Checked = ((idsFuncs.Contains(5)) ? true : false);
            chkBxGestRes.Checked = ((idsFuncs.Contains(6)) ? true : false);
            chkBxCancelRes.Checked = ((idsFuncs.Contains(7)) ? true : false);
            chkBxGestConsu.Checked = ((idsFuncs.Contains(8)) ? true : false);
            chkBxGestEstad.Checked = ((idsFuncs.Contains(9)) ? true : false);
            chkBxGestFactu.Checked = ((idsFuncs.Contains(10)) ? true : false);
            chkBxListados.Checked = ((idsFuncs.Contains(11)) ? true : false);
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            padre.refrescarListas();
            this.Close();
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            validarDatos(errores);
            if (errores.Length<=1)
                doAceptar();
            else
                MessageBox.Show(errores.ToString(), "Errores en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void doAceptar()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmd.Parameters[0].Value = txtNombre.Text;

            cmd.Parameters.Add("@descrip", SqlDbType.VarChar);
            cmd.Parameters[1].Value = txtDescrip.Text;

            cmd.Parameters.Add("@gestRol", SqlDbType.Int);
            cmd.Parameters[2].Value = ((chkBxGestRol.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestUsr", SqlDbType.Int);
            cmd.Parameters[3].Value = ((chkBxGestUsr.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestCli", SqlDbType.Int);
            cmd.Parameters[4].Value = ((chkBxGestCli.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestHotel", SqlDbType.Int);
            cmd.Parameters[5].Value = ((chkBxGestHotel.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestHab", SqlDbType.Int);
            cmd.Parameters[6].Value = ((chkBxGestHab.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestRes", SqlDbType.Int);
            cmd.Parameters[7].Value = ((chkBxGestRes.Checked) ? 1 : 0);

            cmd.Parameters.Add("@cancelRes", SqlDbType.Int);
            cmd.Parameters[8].Value = ((chkBxCancelRes.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestConsu", SqlDbType.Int);
            cmd.Parameters[9].Value = ((chkBxGestConsu.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestEstad", SqlDbType.Int);
            cmd.Parameters[10].Value = ((chkBxGestEstad.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestFactu", SqlDbType.Int);
            cmd.Parameters[11].Value = ((chkBxGestFactu.Checked) ? 1 : 0);

            cmd.Parameters.Add("@listados", SqlDbType.Int);
            cmd.Parameters[12].Value = ((chkBxListados.Checked) ? 1 : 0);

            if (idRol > 0)
            {
                cmd.Parameters.Add("@RolId", SqlDbType.Int);
                cmd.Parameters[13].Value = idRol;
                cmd.CommandText = "SQLECT.modifRol";
            }
            else
            {
                cmd.CommandText = "SQLECT.altaRol";
            }

            Conexion.Instance.ejecutarQueryConSP(cmd);
            MessageBox.Show("Operación exitosa", "ABM de Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            padre.refrescarListas();
            this.Close();
        }

        private void validarDatos(StringBuilder errores)
        {
            validarNombre(errores);
            validarDescrip(errores);
        }

        private void validarNombre(StringBuilder e)
        {
            if (txtNombre.Text == "")
                e.AppendLine("Debe definir un nombre!");
            else
            {
                StringBuilder querry = new StringBuilder();
                querry.AppendFormat(((idRol > 0) ? "SELECT nombre FROM SQLECT.Roles WHERE nombre = '{1}' AND id_rol != {0}" : "SELECT nombre FROM SQLECT.Roles WHERE nombre = '{1}'"), idRol, txtNombre.Text);
                if (Conexion.Instance.ejecutarQuery(querry.ToString()).Rows.Count > 0)
                    e.AppendLine("Ya existe un rol con ese nombre!");
            }
        }

        private void validarDescrip(StringBuilder e)
        {
            if (txtDescrip.Text == "")
                e.AppendLine("Debe dar una descripción para el rol!");
        }

    }
}

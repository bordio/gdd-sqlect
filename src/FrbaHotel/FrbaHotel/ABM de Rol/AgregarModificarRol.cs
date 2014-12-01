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
        private List<CheckBox> lstFuncs;
        private ABM_de_Rol.MainRol padre;

        public AgregarModificarRol(ABM_de_Rol.MainRol owner)
        {
            InitializeComponent();
            llenarFuncs();
            padre = owner;

            idRol = -1;
            funcsRol = new DataTable();
        }

        public AgregarModificarRol(ABM_de_Rol.MainRol owner, Int32 elIdRol, string nombre, string descripcion, DataTable funciones)
        {
            InitializeComponent();
            llenarFuncs();
            padre = owner;

            idRol = elIdRol;
            txtNombre.Text = nombre;
            txtDescrip.Text = descripcion;
            funcsRol = funciones;
            checkFunciones();
        }

        private void checkFunciones()
        {
            foreach (CheckBox func in lstFuncs)
            {
                String funcX = func.Text;
                func.Checked = false;
                foreach (DataRow rowFRol in funcsRol.Rows)
                {
                    String funcRol = rowFRol["Funcion"].ToString();
                    if (funcRol == funcX)
                        func.Checked = true;
                }
            }
        }

        private void llenarFuncs()
        {
            List<CheckBox> lista = new List<CheckBox>();

            /*lista.Add(chkBxGestRol);
            lista.Add(chkBxGestUsr);
            lista.Add(chkBxGestCli);
            lista.Add(chkBxGestHotel);
            lista.Add(chkBxGestHab);
            lista.Add(chkBxGestRes);
            lista.Add(chkBxCancelRes);
            lista.Add(chkBxGestConsu);
            lista.Add(chkBxGestEstad);
            lista.Add(chkBxGestFactu);
            lista.Add(chkBxListados);*/

            lstFuncs = lista;
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            padre.getRoles();
            this.Close();
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmd.Parameters[0].Value = txtNombre.Text;

            cmd.Parameters.Add("@descrip", SqlDbType.VarChar);
            cmd.Parameters[1].Value = txtDescrip.Text;

            cmd.Parameters.Add("@gestRol", SqlDbType.Int);
           // cmd.Parameters[2].Value = ((chkBxGestRol.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestUsr", SqlDbType.Int);
           // cmd.Parameters[3].Value = ((chkBxGestUsr.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestCli", SqlDbType.Int);
           // cmd.Parameters[4].Value = ((chkBxGestCli.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestHotel", SqlDbType.Int);
           // cmd.Parameters[5].Value = ((chkBxGestHotel.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestHab", SqlDbType.Int);
         //   cmd.Parameters[6].Value = ((chkBxGestHab.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestRes", SqlDbType.Int);
          //  cmd.Parameters[7].Value = ((chkBxGestRes.Checked) ? 1 : 0);

            cmd.Parameters.Add("@cancelRes", SqlDbType.Int);
           // cmd.Parameters[8].Value = ((chkBxCancelRes.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestConsu", SqlDbType.Int);
           // cmd.Parameters[9].Value = ((chkBxGestConsu.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestEstad", SqlDbType.Int);
           // cmd.Parameters[10].Value = ((chkBxGestEstad.Checked) ? 1 : 0);

            cmd.Parameters.Add("@gestFactu", SqlDbType.Int);
           // cmd.Parameters[11].Value = ((chkBxGestFactu.Checked) ? 1 : 0);

            cmd.Parameters.Add("@listados", SqlDbType.Int);
            //cmd.Parameters[12].Value = ((chkBxListados.Checked) ? 1 : 0);

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
            padre.getRoles();
            this.Close();
        }
    }
}

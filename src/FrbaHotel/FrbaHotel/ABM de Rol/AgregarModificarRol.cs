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

        public AgregarModificarRol()
        {
            InitializeComponent();
            llenarFuncs();

            funcsRol = new DataTable();
        }

        public AgregarModificarRol(Int32 elIdRol, string nombre, string descripcion, DataTable funciones)
        {
            InitializeComponent();
            llenarFuncs();

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

            lista.Add(chkBxGestRol);
            lista.Add(chkBxGestUsr);
            lista.Add(chkBxGestCli);
            lista.Add(chkBxGestHotel);
            lista.Add(chkBxGestHab);
            lista.Add(chkBxGestRes);
            lista.Add(chkBxCancelRes);
            lista.Add(chkBxGestConsu);
            lista.Add(chkBxGestEstad);
            lista.Add(chkBxGestFactu);
            lista.Add(chkBxListados);

            lstFuncs = lista;
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 
    }
}

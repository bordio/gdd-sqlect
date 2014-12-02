using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class Modificacion_Cliente : BaseAltaModificacion_Cliente
    {
        public Modificacion_Cliente(DataGridView lsClientes, StringBuilder email, StringBuilder documento, StringBuilder tipodocumento)
            : base(lsClientes, email, documento, tipodocumento)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre,apellido,mail,telefono,dom_Calle,nro_Calle,piso,depto,fecha_Nac,nacionalidad,tipodocumento,documento_Nro, id_cliente FROM SQLECT.Clientes WHERE mail='{0}' AND documento_Nro='{1}' AND tipodocumento='{2}' ", email.ToString(), documento.ToString(), tipodocumento.ToString());
            appModel = new AppModel_Modificacion_Cliente();
            this.appModel.levantar(sentence);

            Nombre.Text = appModel.rowCliente.Rows[0][0].ToString();
            Apellido.Text = appModel.rowCliente.Rows[0][1].ToString();
            Email.Text = appModel.rowCliente.Rows[0][2].ToString();
            Telefono.Text = appModel.rowCliente.Rows[0][3].ToString();
            Calle.Text = appModel.rowCliente.Rows[0][4].ToString();
            Numero.Text = appModel.rowCliente.Rows[0][5].ToString();
            Piso.Text = appModel.rowCliente.Rows[0][6].ToString();
            Depto.Text = appModel.rowCliente.Rows[0][7].ToString();
            //Localidad.Text = appModel.rowCliente.Rows[0][6].ToString();
            Fecha.Text = appModel.rowCliente.Rows[0][8].ToString();
            Nacionalidad.Text = appModel.rowCliente.Rows[0][9].ToString();
            Documento.Text = appModel.rowCliente.Rows[0][11].ToString();
            if (appModel.rowCliente.Rows[0][10].ToString() == "DNI") cbTipoDoc.SelectedIndex = 0;
            else cbTipoDoc.SelectedIndex = 1;

        }

        public override void btGuardar_Click(object sender, EventArgs e)
        {
            base.validacionesAlGuardar();
            base.btGuardar_Click(sender, e);
        }
    }
}

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
        public Modificacion_Cliente(ABM_de_Cliente.ModificacionMain_Cliente pantallaFiltros, DataGridView lsClientes, StringBuilder email, StringBuilder documento, StringBuilder tipodocumento)
            : base(pantallaFiltros,lsClientes, email, documento, tipodocumento)
        {
            StringBuilder sentence = new StringBuilder().AppendFormat("SELECT c.nombre 'Nombre', c.apellido 'Apellido',c.mail 'Email',c.telefono 'Telefono',c.fecha_Nac 'Fecha Nacimiento', c.dom_Calle 'Calle', c.nro_calle 'Nro Calle', c.piso 'Piso',c.depto 'Departamento', c.localidad 'Localidad', p.nombrePais 'Pais', c.nacionalidad 'Nacionalidad', c.tipoDocumento 'Tipo de Documento',c.documento_Nro 'Número de Documento', c.habilitado 'Habilitado', c.fk_paisOrigen, c.id_cliente, c.inconsistente FROM SQLECT.Clientes c LEFT JOIN SQLECT.Paises p ON (p.id_pais = c.fk_paisOrigen) WHERE mail='{0}' AND documento_Nro='{1}' AND tipodocumento='{2}' ", email.ToString(), documento.ToString(), tipodocumento.ToString());

            //StringBuilder sentence = new StringBuilder().AppendFormat("SELECT nombre,apellido,mail,telefono,dom_Calle,nro_Calle,piso,depto,localidad,fecha_Nac,nacionalidad,tipodocumento,documento_Nro, id_cliente FROM SQLECT.Clientes WHERE mail='{0}' AND documento_Nro='{1}' AND tipodocumento='{2}' ", email.ToString(), documento.ToString(), tipodocumento.ToString());
            int posicionId = 16;
            appModel = new AppModel_Modificacion_Cliente();
            this.appModel.levantar(sentence, posicionId);
           
            Nombre.Text = appModel.rowCliente.Rows[0][0].ToString();
            Apellido.Text = appModel.rowCliente.Rows[0][1].ToString();
            Email.Text = appModel.rowCliente.Rows[0][2].ToString();
            Telefono.Text = appModel.rowCliente.Rows[0][3].ToString();
            Fecha.Text = appModel.rowCliente.Rows[0][4].ToString();
            Calle.Text = appModel.rowCliente.Rows[0][5].ToString();
            Numero.Text = appModel.rowCliente.Rows[0][6].ToString();
            Piso.Text = appModel.rowCliente.Rows[0][7].ToString();
            Depto.Text = appModel.rowCliente.Rows[0][8].ToString();
            Localidad.Text = appModel.rowCliente.Rows[0][9].ToString();
            //PaisOrigen noombre es el 10 // el 14 es habilitado
            Nacionalidad.Text = appModel.rowCliente.Rows[0][11].ToString();
            Documento.Text = appModel.rowCliente.Rows[0][13].ToString();
            if (appModel.rowCliente.Rows[0][12].ToString() == "DNI") cbTipoDoc.SelectedIndex = 0; //Posiciono al combobox para que muestre el tipo de documento del cliente
            else cbTipoDoc.SelectedIndex = 1;

            if (appModel.rowCliente.Rows[0][17].ToString() == "1") labelAdvertencia.Visible = true;

            //Carga de paises al comboBox
            appModel.cargarPaises(PaisOrigen);
            //Se selecciona del comboBox el pais del Cliente seleccionado
            if (appModel.rowCliente.Rows[0][15].ToString() != "") PaisOrigen.SelectedIndex = Int32.Parse(appModel.rowCliente.Rows[0][15].ToString()) - 1; // El 15 es el fkHotel
            
        }

        public override void btGuardar_Click(object sender, EventArgs e)
        {
            base.validacionesAlGuardar();
            base.btGuardar_Click(sender, e);
        }
    }
}

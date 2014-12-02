using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    class AppModel_Modificacion_Cliente : AppModel_Base_Cliente
    {
        private Conexion sqlconexion = Conexion.Instance;
        public Int32 idCliente;

        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, String fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipo_documento, string telefono)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoACliente = new System.Data.SqlClient.SqlCommand();
            comandoACliente.CommandType = CommandType.StoredProcedure;

            comandoACliente.Parameters.Add("@idCliente", SqlDbType.Int);
            comandoACliente.Parameters.Add("@Nombre", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Apellido", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Mail", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Dom_Calle", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Nro_Calle", SqlDbType.Int);
            comandoACliente.Parameters.Add("@Piso", SqlDbType.TinyInt);
            comandoACliente.Parameters.Add("@Depto", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@Fecha_Nac", SqlDbType.DateTime);
            comandoACliente.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@documento_Nro", SqlDbType.BigInt);
            comandoACliente.Parameters.Add("@tipodocumento", SqlDbType.VarChar);
            comandoACliente.Parameters.Add("@telefono", SqlDbType.Int);

            comandoACliente.Parameters[0].Value = idCliente;
            comandoACliente.Parameters[1].Value = nombre;
            comandoACliente.Parameters[2].Value = apellido;
            comandoACliente.Parameters[3].Value = mail;
            comandoACliente.Parameters[4].Value = dom_Calle;
            comandoACliente.Parameters[5].Value = Int32.Parse(nro_Calle);
            comandoACliente.Parameters[6].Value = Int32.Parse(piso);
            comandoACliente.Parameters[7].Value = depto;
            comandoACliente.Parameters[8].Value = DateTime.Parse(fecha_Nac);
            comandoACliente.Parameters[9].Value = nacionalidad;
            comandoACliente.Parameters[10].Value = documento_Nro;
            comandoACliente.Parameters[11].Value = tipo_documento;
            if (telefono != "") comandoACliente.Parameters[12].Value = Int32.Parse(telefono);
            else comandoACliente.Parameters[12].Value = null;
            

            comandoACliente.CommandText = "SQLECT.modificacionCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

            MessageBox.Show("Modificacion exitosa", "Modificacion de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

        
        }

          public override void levantar(StringBuilder sentence)
         {
             rowCliente = Conexion.Instance.ejecutarQuery(sentence.ToString());
             idCliente = Int32.Parse(rowCliente.Rows[0][12].ToString());
         }

          public override void validarDocumento(Control documento, string tipo, StringBuilder mensajeValidacion)
          {
              StringBuilder query = new StringBuilder();
              query.AppendFormat("SELECT * FROM SQLECT.Clientes WHERE ((id_cliente!='{0}' AND documento_Nro='{1}' AND tipodocumento='{2}'))", idCliente,documento.Text, tipo);
              if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
              {
                  mensajeValidacion.AppendLine(string.Format(" El documento {0} ya existe. Debe modificarlo para poder Guardar los cambios", documento.Text));
              };
          }

          public override void validarEmail(Control mail, StringBuilder mensajeValidacion)
          {
              StringBuilder query = new StringBuilder();
              query.AppendFormat("SELECT * FROM SQLECT.Clientes WHERE mail='{0}' AND id_Cliente!='{1}'", mail.Text, idCliente);
              if (this.sqlconexion.ejecutarQuery(query.ToString()).Rows.Count > 0)
              {
                  mensajeValidacion.AppendLine(string.Format(" El email {0} ya existe. Debe modificarlo para poder Guardar los cambios", mail.Text));
              };
          }

    }
}

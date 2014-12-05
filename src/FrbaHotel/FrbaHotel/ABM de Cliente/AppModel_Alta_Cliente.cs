using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{
    class AppModel_Alta_Cliente : AppModel_Base_Cliente
    {


        public override void abmlCliente(string nombre, string apellido, string mail, string dom_Calle, string nro_Calle, string piso, string depto, string fecha_Nac, string nacionalidad, string documento_Nro, int idReserva, string tipo_documento, string telefono, string localidad, ComboBox pais)
        {
                Conexion conexion = Conexion.Instance;
                System.Data.SqlClient.SqlCommand comandoACliente = new System.Data.SqlClient.SqlCommand();
                comandoACliente.CommandType = CommandType.StoredProcedure;

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
                comandoACliente.Parameters.Add("@idReserva", SqlDbType.Int);
                comandoACliente.Parameters.Add("@tipodocumento", SqlDbType.VarChar);
                comandoACliente.Parameters.Add("@telefono", SqlDbType.Int);
                comandoACliente.Parameters.Add("@localidad", SqlDbType.VarChar);
                comandoACliente.Parameters.Add("@pais", SqlDbType.VarChar);

                comandoACliente.Parameters[0].Value = nombre;
                comandoACliente.Parameters[1].Value = apellido;
                comandoACliente.Parameters[2].Value = mail;
                comandoACliente.Parameters[3].Value = dom_Calle;

                if (nro_Calle != "") comandoACliente.Parameters[4].Value = Int32.Parse(nro_Calle);
                else comandoACliente.Parameters[4].Value = null;

                if (piso != "") comandoACliente.Parameters[5].Value = Int32.Parse(piso); //si lo deja en blanco el parse explota.
                else comandoACliente.Parameters[5].Value = null;
            
                comandoACliente.Parameters[6].Value = depto;
                comandoACliente.Parameters[7].Value = DateTime.Parse(fecha_Nac);
                comandoACliente.Parameters[8].Value = nacionalidad;
                comandoACliente.Parameters[9].Value = documento_Nro;
                comandoACliente.Parameters[10].Value = idReserva;
                comandoACliente.Parameters[11].Value = tipo_documento;

                if (telefono != "") comandoACliente.Parameters[12].Value = Int32.Parse(telefono);
                else comandoACliente.Parameters[12].Value = null;

                comandoACliente.Parameters[13].Value = localidad;

                //El Pais Origen no es un campo obligatorio. Por lo cual, puede venir en blanco:
                if (pais.SelectedItem != null) { comandoACliente.Parameters[14].Value = pais.SelectedItem.ToString(); }
                else comandoACliente.Parameters[14].Value = "";

                comandoACliente.CommandText = "SQLECT.altaCliente";
                conexion.ejecutarQueryConSP(comandoACliente); //Pedimos la ejecucion del StoredProcedure SQLECT.altaCliente
                
                MessageBox.Show("Alta exitosa", "Alta de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    class AppModel_Baja_Cliente : AppModel_Base_Cliente
    {
        private Conexion sqlconexion = Conexion.Instance;
        System.Data.SqlClient.SqlCommand comandoACliente;


        public void comandoCliente(StringBuilder email, StringBuilder documento_Nro, StringBuilder tipodocumento)
        {       
                comandoACliente.Parameters.Add("@Mail", SqlDbType.VarChar);
                comandoACliente.Parameters.Add("@documento_Nro", SqlDbType.BigInt);
                comandoACliente.Parameters.Add("@tipodocumento", SqlDbType.VarChar);

                comandoACliente.Parameters[0].Value = email.ToString();
                comandoACliente.Parameters[1].Value = Int64.Parse(documento_Nro.ToString());
                comandoACliente.Parameters[2].Value = tipodocumento.ToString();
        }

        public void inhabilitarCliente(StringBuilder email, StringBuilder documento_Nro, StringBuilder tipodocumento)
        {
            Conexion conexion = Conexion.Instance;
            comandoACliente = new System.Data.SqlClient.SqlCommand();
            comandoACliente.CommandType = CommandType.StoredProcedure;

            comandoCliente(email, documento_Nro, tipodocumento);

            comandoACliente.CommandText = "SQLECT.inhabilitarCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

            MessageBox.Show("Inhabilitacion exitosa", "Inhabilitacion del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void habilitarCliente(StringBuilder email, StringBuilder documento_Nro, StringBuilder tipodocumento)
        {
            Conexion conexion = Conexion.Instance;
            comandoACliente = new System.Data.SqlClient.SqlCommand();
            comandoACliente.CommandType = CommandType.StoredProcedure;

            comandoCliente(email, documento_Nro, tipodocumento);

            comandoACliente.CommandText = "SQLECT.habilitarCliente";
            conexion.ejecutarQueryConSP(comandoACliente);

            MessageBox.Show("Habilitacion exitosa", "Habilitacion del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }
}

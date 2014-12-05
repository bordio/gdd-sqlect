using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Security.Cryptography;


namespace FrbaHotel.Commons.FuncionalidadesVarias
{
    public class Funcionalidades
    {

        public int devolverFechaAppConfig()
        {
            int fechaFormateada = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Año"].ToString()) * 10000 + Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Mes"].ToString()) * 100 + Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Dia"].ToString());
            return fechaFormateada;
        }

        public string pasarIntADatetime()
        
        {
            StringBuilder fecha = new StringBuilder();
            fecha.Append(System.Configuration.ConfigurationManager.AppSettings["Dia"].ToString());
            fecha.Append("/");
            fecha.Append(System.Configuration.ConfigurationManager.AppSettings["Mes"].ToString());
            fecha.Append("/");
            fecha.Append(System.Configuration.ConfigurationManager.AppSettings["Año"].ToString());

            return fecha.ToString();
        
        }

        public bool chequearExistenciaDeUsuarioYRol(string nombreUsuario, string rolElegido)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoExistenciaUsuario = new System.Data.SqlClient.SqlCommand();

            comandoExistenciaUsuario.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoExistenciaUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoExistenciaUsuario.Parameters[contador].Value = nombreUsuario;
            contador++;

            comandoExistenciaUsuario.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoExistenciaUsuario.Parameters[contador].Value = rolElegido;
            contador++;

            comandoExistenciaUsuario.CommandText = "SQLECT.validarExistenciaDeUsuarioYRol";

            bool existencia = cnn.ejecutarEscalar(comandoExistenciaUsuario);

            return existencia;
        }

        public string encriptarPassword(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();


            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            byte[] hashedBytes = provider.ComputeHash(inputBytes);


            StringBuilder output = new StringBuilder();


            for (int i = 0; i < hashedBytes.Length; i++)

                output.Append(hashedBytes[i].ToString("x2").ToLower());


            return output.ToString();
        }

        public void inhabilitarUsuario(string usuario)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoInhabilitarUsuario = new System.Data.SqlClient.SqlCommand();

            comandoInhabilitarUsuario.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoInhabilitarUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoInhabilitarUsuario.Parameters[contador].Value = usuario;
            contador++;

            comandoInhabilitarUsuario.CommandText = "SQLECT.inhabilitarUsuario";
            cnn.ejecutarSP(comandoInhabilitarUsuario);
        }
        public int obtenerIDUsuario(string nombreUsuario)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoIDUsuario = new System.Data.SqlClient.SqlCommand();

            comandoIDUsuario.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoIDUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoIDUsuario.Parameters[contador].Value = nombreUsuario;
            contador++;

            comandoIDUsuario.CommandText = "SQLECT.obtenerIDUsuario";
            int idUsuario = cnn.ejecutarEscalarInt(comandoIDUsuario);

            return idUsuario;
        }

        public bool chequearExistenciaDeHotelAsignado(string usuario, string hotel)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoExistenciaDeHotel = new System.Data.SqlClient.SqlCommand();

            comandoExistenciaDeHotel.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoExistenciaDeHotel.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoExistenciaDeHotel.Parameters[contador].Value = usuario;
            contador++;

            comandoExistenciaDeHotel.Parameters.Add("@nombreHotel", SqlDbType.VarChar);
            comandoExistenciaDeHotel.Parameters[contador].Value = hotel;
            contador++;

            comandoExistenciaDeHotel.CommandText = "SQLECT.chequearUsuarioConHotelAsignado";

            bool existencia = cnn.ejecutarEscalar(comandoExistenciaDeHotel);

            return existencia;
        }

        public int obtenerIDHotel(string nombreHotel)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoIDHotel = new System.Data.SqlClient.SqlCommand();

            comandoIDHotel.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoIDHotel.Parameters.Add("@hotel", SqlDbType.VarChar);
            comandoIDHotel.Parameters[contador].Value = nombreHotel;
            contador++;

            comandoIDHotel.CommandText = "SQLECT.obtenerIDHotel";
            int idUsuario = cnn.ejecutarEscalarInt(comandoIDHotel);

            return idUsuario;
        }

        public string obtenerNombreHotel(int idDeHotel)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoNombreHotel = new System.Data.SqlClient.SqlCommand();

            comandoNombreHotel.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoNombreHotel.Parameters.Add("@idHotel", SqlDbType.Int);
            comandoNombreHotel.Parameters[contador].Value = idDeHotel;
            contador++;


            comandoNombreHotel.CommandText = "SQLECT.obtenerNombreHotel";
            string nombreDelHotel = cnn.ejecutarEscalarString(comandoNombreHotel);
            
            return nombreDelHotel;
        
        }

   
    }





}
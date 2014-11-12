﻿using System;
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

        public void inhabilitarUsuario(string usuario, string rol)
        {
            Conexion cnn = Conexion.Instance;

            System.Data.SqlClient.SqlCommand comandoInhabilitarUsuario = new System.Data.SqlClient.SqlCommand();

            comandoInhabilitarUsuario.CommandType = CommandType.StoredProcedure;
            int contador = 0;

            comandoInhabilitarUsuario.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoInhabilitarUsuario.Parameters[contador].Value = usuario;
            contador++;

            comandoInhabilitarUsuario.Parameters.Add("@rol", SqlDbType.VarChar);
            comandoInhabilitarUsuario.Parameters[contador].Value = rol;
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
    
    }




}
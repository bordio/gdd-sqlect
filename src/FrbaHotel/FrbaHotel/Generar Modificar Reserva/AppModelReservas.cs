﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrbaHotel.Commons.Database;
using System.Windows.Forms;
using FrbaHotel.Commons.FuncionalidadesVarias;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    class AppModel_Reservas
    {
        private Conexion sqlconexion = Conexion.Instance;
        Funcionalidades funcionesVarias = new Funcionalidades();


        public int devolverFechaAppConfig()
        {
            int fechaFormateada = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Año"].ToString()) * 10000 + Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Mes"].ToString()) * 100 + Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Dia"].ToString());
            return fechaFormateada;
        }

        public int pasarDateTimeAInt(DateTime fecha)
        {
            int fechaInt = fecha.Year * 10000 + fecha.Month * 100 + fecha.Day;
            return fechaInt;
        
        }

        public DataTable habitacionesMaximasDisponibles(string fechaDesde, string fechaHasta, int idHotel)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = DateTime.Parse(fechaDesde);
            comandoAReserva.Parameters[1].Value = DateTime.Parse(fechaHasta);
            comandoAReserva.Parameters[2].Value = idHotel;


            comandoAReserva.CommandText = "SQLECT.obtenerMaximasHabitacionesDisponibles";
            DataTable maximasDisponibles = conexion.ejecutarQueryConSP(comandoAReserva);

            return maximasDisponibles;
        }


        public void cargarCantidadesMaximasDeHabitaciones(DataTable tablaDeMaximos, NumericUpDown simples, NumericUpDown dobles, NumericUpDown triples, NumericUpDown cuadruples, NumericUpDown quintuples)
        {

            simples.Maximum = 0;
            dobles.Maximum = 0;
            triples.Maximum = 0;
            cuadruples.Maximum = 0;
            quintuples.Maximum = 0;

            for (int i = 0; i < tablaDeMaximos.Rows.Count; i++)
            {
                int tipoHab = Convert.ToInt32(tablaDeMaximos.Rows[i][0].ToString());

                switch (tipoHab)
                {
                    case 1001:
                        simples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i][1].ToString());
                        break;
                    case 1002:
                        dobles.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i][1].ToString());
                        break;
                    case 1003:
                        triples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i][1].ToString());
                        break;
                    case 1004:
                        cuadruples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i][1].ToString());
                        break;
                    case 1005:
                        quintuples.Maximum = Convert.ToInt32(tablaDeMaximos.Rows[i][1].ToString());
                        break;


                }

            }



        }

        public DataTable obtenerPreciosDeHabtitaciones(string tipoRegimen, int idHotel)
        {

            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@tipoRegimen", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = tipoRegimen;
            comandoAReserva.Parameters[1].Value = idHotel;
           
            comandoAReserva.CommandText = "SQLECT.obtenerPreciosDeHabitaciones";
            DataTable tablaDePrecios = conexion.ejecutarQueryConSP(comandoAReserva);

            return tablaDePrecios;

        
        }


        public bool chequearCantHuespedesYHabitaciones(int cantidadHuespedes, int habSimples, int habDobles, int habTriples, int habCuadruples, int habQuintuples)
        {
            int huespedesMaximos = habSimples * 1 + habDobles * 2 + habTriples * 3 + habCuadruples * 4 + habQuintuples * 5;

              if (cantidadHuespedes<=huespedesMaximos)
                  return true;
            else
                  return false;
        
        
        }

        public decimal calcularPrecioReserva(DataTable tablaDePrecios, int cantidadDias,int cantSimples, int cantDobles, int cantTriples, int cantCuadruples, int cantQuintuples)
        {
            decimal precioTotal = cantidadDias * (cantSimples * Convert.ToDecimal(tablaDePrecios.Rows[0][1]) + cantDobles * Convert.ToDecimal(tablaDePrecios.Rows[1][1]) + cantTriples * Convert.ToDecimal(tablaDePrecios.Rows[2][1]) + cantCuadruples * Convert.ToDecimal(tablaDePrecios.Rows[3][1]) + cantQuintuples * Convert.ToDecimal(tablaDePrecios.Rows[4][1]));

                return precioTotal;
        }

        public bool realizarReserva(string fechaInicio, int cantidadNoches, string usuarioDeSesion, string tipoRegimen, int idDeHotel,int cantidadHuespedes)
        {
            string fechaActual = Convert.ToString(this.devolverFechaAppConfig());
            
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@fechaInicio", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@cantidadNoches", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@tipoRegimen", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@cantHuespedes", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@fechaDelSistema", SqlDbType.VarChar);
         
            comandoAReserva.Parameters[0].Value = DateTime.Parse(fechaInicio);
            comandoAReserva.Parameters[1].Value = cantidadNoches;
            comandoAReserva.Parameters[2].Value = usuarioDeSesion;
            comandoAReserva.Parameters[3].Value = tipoRegimen;
            comandoAReserva.Parameters[4].Value = idDeHotel;
            comandoAReserva.Parameters[5].Value = cantidadHuespedes;
            comandoAReserva.Parameters[6].Value = fechaActual;


            comandoAReserva.CommandText = "SQLECT.realizarReserva";
            conexion.ejecutarQuery("BEGIN TRANSACTION");
            conexion.ejecutarSP(comandoAReserva);

            return true;
        }

        public DataTable obtenerHabitacionesDisponibles(int idHotel, string fechaDesde, string fechaHasta)
        
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = DateTime.Parse(fechaDesde);
            comandoAReserva.Parameters[1].Value = DateTime.Parse(fechaHasta);
            comandoAReserva.Parameters[2].Value = idHotel;


            comandoAReserva.CommandText = "SQLECT.mostrarHabitacionesDisponibles";
            DataTable habitacionesDsiponibles = conexion.ejecutarQueryConSP(comandoAReserva);

            return habitacionesDsiponibles;
        
        }


        public void reservarHabitacion(int idHotel, int numeroHabitacion, int idReserva, string fechaDesde, int cantNoches)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@numeroHabitacion", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@idReserva", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@cantNoches",SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = idHotel;
            comandoAReserva.Parameters[1].Value = numeroHabitacion;
            comandoAReserva.Parameters[2].Value = idReserva;
            comandoAReserva.Parameters[3].Value = DateTime.Parse(fechaDesde);
            comandoAReserva.Parameters[4].Value = cantNoches;

            comandoAReserva.CommandText = "SQLECT.reservarHabitacion";
            conexion.ejecutarSP(comandoAReserva);

        }

        public int obtenerIdReserva()
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.CommandText = "SQLECT.obtenerIdReserva";
            int idReserva = conexion.ejecutarEscalarInt(comandoAReserva);
            
            return idReserva;
        
        }

        public string generarCodigoReserva()
        {
            string codigoReserva = Guid.NewGuid().ToString().Substring(0,8);
            return codigoReserva;
        }
        public bool verificarCodigoReservaRepetido(string codigo)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
           
            comandoAReserva.Parameters[0].Value = codigo;
          
            comandoAReserva.CommandText = "SQLECT.verificarExistenciaCodigoReserva";
            bool existenciaCodigo = conexion.ejecutarEscalar(comandoAReserva);

            return existenciaCodigo;
        }

        public void adjuntarCodigoALaReserva(int idReserva, string codigo)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@idReserva", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = idReserva;
            comandoAReserva.Parameters[1].Value = codigo;

            comandoAReserva.CommandText = "SQLECT.adjuntarCodigoALaReserva";
            conexion.ejecutarSP(comandoAReserva);        
        }

        public bool adjudicarClienteALaReserva(string email, int documento, int idReserva)
        
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@email", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@documento_nro", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@idReserva", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = email;
            comandoAReserva.Parameters[1].Value = documento;
            comandoAReserva.Parameters[2].Value = idReserva;
          
            comandoAReserva.CommandText = "SQLECT.adjuntarClienteALaReserva";
            conexion.ejecutarSP(comandoAReserva);
            conexion.ejecutarQuery("COMMIT");
            return true;
        
        }
        public string obtenerCodigoReserva(int idReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;
       
            comandoAReserva.Parameters.Add("@idReserva", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = idReserva;

            comandoAReserva.CommandText = "SQLECT.obtenerCodigoReserva";
            string codigoDeLaReserva = conexion.ejecutarEscalarString(comandoAReserva);
            
            return codigoDeLaReserva;
        }

        public bool correspondeReservaAlHotel(string codigo, int idHotel)
        
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = codigo;
            comandoAReserva.Parameters[1].Value = idHotel;

            comandoAReserva.CommandText = "SQLECT.correspondeReservaAlHotel";
            bool correspondeAlHotel = conexion.ejecutarEscalar(comandoAReserva);

            return correspondeAlHotel;       
        }

        public bool chequearHabilitacionDeCancelacion(string codigoReserva)
    
        {
            string fechaActual = Convert.ToString(this.devolverFechaAppConfig());
            
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaActual", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = fechaActual;

            comandoAReserva.CommandText = "SQLECT.chequearHabilitacionDeCancelacion";
            bool efectivizacion=conexion.ejecutarEscalar(comandoAReserva);

            return efectivizacion;       
   
        }

        public bool cancelarReserva(string codigo, string usuarioDeSesion,string nombreRol,string motivo)
        {

            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@usuario", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@nombreRol", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@motivo", SqlDbType.VarChar);
           
            comandoAReserva.Parameters[0].Value = codigo;
            comandoAReserva.Parameters[1].Value = usuarioDeSesion;
            comandoAReserva.Parameters[2].Value = nombreRol;
            comandoAReserva.Parameters[3].Value = motivo;
            
            comandoAReserva.CommandText = "SQLECT.cancelarReserva";
            conexion.ejecutarSP(comandoAReserva);
               
            return true;
        }

        public DataTable obtenerHabitacionesActualesDeReserva(string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
        
            comandoAReserva.Parameters[0].Value = codigoReserva;

            comandoAReserva.CommandText = "SQLECT.obtenerHabitacionesActualesDeReserva";
            DataTable habitacionesActuales = conexion.ejecutarQueryConSP(comandoAReserva);

            return habitacionesActuales;

        
        }

     /*   public DataTable obtenerHabitacionesDisponiblesMasActuales(int idHotel, string fechaDesde, string fechaHasta, string codigoReserva)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);
            comandoAReserva.Parameters.Add("@fechaDesde", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@fechaHasta", SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);

            comandoAReserva.Parameters[0].Value = idHotel;
            comandoAReserva.Parameters[1].Value = DateTime.Parse(fechaDesde);
            comandoAReserva.Parameters[2].Value = DateTime.Parse(fechaHasta);
            comandoAReserva.Parameters[3].Value = codigoReserva;

            comandoAReserva.CommandText = "SQLECT.obtenerHabitacionesDiponiblesMasActuales";
            DataTable habitacionesDisponibles = conexion.ejecutarQueryConSP(comandoAReserva);

            return habitacionesDisponibles;


        }*/

        public bool modificarReserva(string codigoReserva,string usuarioDeModificacion,int cantHuespedes, string regimenNuevo,string fechaDesde, string fechaHasta)
        
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@usuario",SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@cantHuespedes",SqlDbType.Int);
            comandoAReserva.Parameters.Add("@regimen",SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@fechaDesde",SqlDbType.DateTime);
            comandoAReserva.Parameters.Add("@fechaHasta",SqlDbType.DateTime);
       
            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value= usuarioDeModificacion;
            comandoAReserva.Parameters[2].Value= cantHuespedes;
            comandoAReserva.Parameters[3].Value= regimenNuevo;
            comandoAReserva.Parameters[4].Value= DateTime.Parse(fechaDesde);
            comandoAReserva.Parameters[5].Value= DateTime.Parse(fechaHasta);
            
            comandoAReserva.CommandText = "SQLECT.modificarReserva";
            conexion.ejecutarSP(comandoAReserva);

            return true;
        
        }


        public void desocuparHabitacionesDeReserva(string codigoReserva)

        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
       
            comandoAReserva.Parameters[0].Value = codigoReserva;
            
            comandoAReserva.CommandText = "SQLECT.desocuparHabitacionesDeReserva";
            conexion.ejecutarQuery("BEGIN TRANSACTION");
            
            conexion.ejecutarSP(comandoAReserva);
       
        }

        public void modificarHabitacionDeReserva(string codigoReserva, int numeroHabitacion, int idHotel)
        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
            comandoAReserva.Parameters.Add("@numeroHabitacion",SqlDbType.Int);
            comandoAReserva.Parameters.Add("@idHotel", SqlDbType.Int);

            comandoAReserva.Parameters[0].Value = codigoReserva;
            comandoAReserva.Parameters[1].Value = numeroHabitacion;
            comandoAReserva.Parameters[2].Value = idHotel;

            comandoAReserva.CommandText = "SQLECT.modificarHabitacionDeReserva";
            conexion.ejecutarSP(comandoAReserva);
        
        }

        public void borrarHabitacionesViejas(string codigoReserva)

        {
            Conexion conexion = Conexion.Instance;
            System.Data.SqlClient.SqlCommand comandoAReserva = new System.Data.SqlClient.SqlCommand();
            comandoAReserva.CommandType = CommandType.StoredProcedure;

            comandoAReserva.Parameters.Add("@codigoReserva", SqlDbType.VarChar);
   
            comandoAReserva.Parameters[0].Value = codigoReserva;

            comandoAReserva.CommandText = "SQLECT.borrarHabitacionesViejas";
            conexion.ejecutarQuery("BEGIN TRANSACTION");
            conexion.ejecutarSP(comandoAReserva);
        
        }

        public void confirmarModificacionDeReserva()
        {
            Conexion conexion = Conexion.Instance;
            conexion.ejecutarQuery("COMMIT TRANSACTION");
        }
        public void terminarModificacion()
        {
            Conexion conexion = Conexion.Instance;
            conexion.ejecutarQuery("ROLLBACK");
        
        }
    
    
    }


   
}

    

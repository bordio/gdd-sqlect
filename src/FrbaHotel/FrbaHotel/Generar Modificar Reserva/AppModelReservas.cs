using System;
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

        }

    }

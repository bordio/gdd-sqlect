using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace FrbaHotel.Commons.Database
{
    class Conexion
    {
        static Conexion instance = null;
        private SqlConnection conn;
        private SqlConnection Conn
        {
            get { return this.conn; }
            set { this.conn = value; }
        }

        private string error;
        public string Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        public Conexion()
        {
            this.Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["gd"].ConnectionString);
            this.Conn.Open();
        }

        public static Conexion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Conexion();
                }
                return instance;
            }
        }

        public bool ejecutarEscalar(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;
            if (cmd.ExecuteScalar() != null)
                return true;
            else
                return false;
        }

        public DataTable ejecutarQuery(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 800;

            cmd.Connection = this.Conn;
            cmd.CommandText = query;

            // Usaremos un DataAdapter para leer los datos
            SqlDataAdapter da = new SqlDataAdapter(query, this.Conn);
            // El resultado lo guardaremos en una tabla
            DataTable tabla = new DataTable();
            tabla.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Llenamos la tabla con los datos leídos
            da.Fill(tabla);

            return tabla;
        }

        public DataTable ejecutarQueryConSP(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;

            // El resultado lo guardaremos en una tabla
            DataTable tabla = new DataTable();
            // Usaremos un DataAdapter para leer los datos
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // Llenamos la tabla con los datos leídos
            da.Fill(tabla);

            cmd.Dispose();
            cmd = null;

            return tabla;
        }

        public void ejecutarSP(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cmd = null;
        }

        public string ejecutarEscalarString(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;
            return cmd.ExecuteScalar().ToString();
        }

        public int ejecutarEscalarInt(SqlCommand cmd)
        {
            cmd.Connection = this.Conn;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}

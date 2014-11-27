using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Commons.Database;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class Form1 : Form
    {
        public Form1(string usuario, int idHotel)
        {
            InitializeComponent();
            this.usuarioDeSesionActual = usuario;
            this.idHotelEnCuestion = idHotel;
        }


        AppModel_Alta_Usuario funcionesVarias = new AppModel_Alta_Usuario();
        AppModel_Reservas funcionesReservas = new AppModel_Reservas();
        StringBuilder mensaje = new StringBuilder();
        string usuarioDeSesionActual;
        int idHotelEnCuestion;
        private int idReservaActual;
        private DateTime fechaInicioActual;
        private int cantNochesReserva;
        private int cantNochesEstadia;
        private int cantHuespedes;
        private int estadoReservaActual;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (!funcionesVarias.validarNoVacio(codigoReserva, mensaje))
            {
                MessageBox.Show(mensaje.ToString());
                mensaje.Remove(0, mensaje.Length);
            }
            else
            {
                if (funcionesReservas.correspondeReservaAlHotel(codigoReserva.Text, idHotelEnCuestion))
                {
                    StringBuilder sentence = new StringBuilder().AppendFormat("SELECT id_reserva,fecha_inicio,cant_noches_reserva,cant_noches_estadia,estado_reserva,cantidad_huespedes FROM SQLECT.Reservas WHERE codigo_reserva='{0}' ", codigoReserva.Text);
                    DataTable tabla = Conexion.Instance.ejecutarQuery(sentence.ToString());

                    foreach (DataRow fila in tabla.Rows)
                    {
                        idReservaActual = Convert.ToInt32(fila[0].ToString());
                        fechaInicioActual = DateTime.Parse(fila[1].ToString());
                        cantNochesReserva = Convert.ToInt32(fila[2].ToString());
                        if (string.IsNullOrEmpty(fila[3].ToString()))
                            cantNochesEstadia = 0;
                        else
                        { cantNochesEstadia = Convert.ToInt32(fila[3].ToString()); }
                        
                        estadoReservaActual = Convert.ToInt32(fila[4].ToString());
                        cantHuespedes = Convert.ToInt32(fila[5].ToString());

                        MessageBox.Show(string.Format("id={0},fechaInicio={1},cantNochesReserva={2},cantNochesEstadia={3},cantHuespedes={4}", idReservaActual, fechaInicioActual, cantNochesReserva, cantNochesEstadia, cantHuespedes));
                        botonCheckIn.Visible = true;
                        botonCheckOut.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Numero inválido o no corresponde al hotel de la sesión");
                }

            }


            }

        

        }
    }


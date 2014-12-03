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

        AppModel_Estadias funcionesEstadias = new AppModel_Estadias();
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
        private DateTime fechaActual = DateTime.Now;


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

                        /* MessageBox.Show(string.Format("id={0},fechaInicio={1},cantNochesReserva={2},cantNochesEstadia={3},cantHuespedes={4}", idReservaActual, fechaInicioActual, cantNochesReserva, cantNochesEstadia, cantHuespedes)); */
                        botonCheckIn.Visible = true;
                        botonCheckOut.Visible = true;
                        botonAceptar.Enabled = false;
                        codigoReserva.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Numero inválido o no corresponde al hotel de la sesión");
                }

            }


            }

        private void botonCheckIn_Click(object sender, EventArgs e)
        {
            if (!funcionesEstadias.chequearRealizacionDeCheckIn(codigoReserva.Text))
            {

                if ((estadoReservaActual == 0) | (estadoReservaActual == 1))
                {
                    if (funcionesEstadias.chequearFechaDeIngreso(codigoReserva.Text))
                    {
                        funcionesEstadias.realizarCheckIn(codigoReserva.Text, usuarioDeSesionActual);

                        MessageBox.Show("Check-In realizado correctamente");
                        
                        if (cantHuespedes > 1)
                        {
                          MessageBox.Show(string.Format("Debe registrar a {0} huéspedes como clientes", cantHuespedes - 1));
                          FrbaHotel.ABM_de_Cliente.BaseAltaModificacion_Cliente formRegistrarClientes = new FrbaHotel.ABM_de_Cliente.BaseAltaModificacion_Cliente();
                          formRegistrarClientes.Show();
                            
                        }
                        this.Close();
                    }
                    else
                    {
                        funcionesEstadias.cancelarReservaPorNoShow(codigoReserva.Text);
                        MessageBox.Show("La reserva ha sido cancelada por no presentarse en fecha.");
                    }

                }
                else
                {
                    if ((estadoReservaActual == 2) | (estadoReservaActual == 3) | (estadoReservaActual == 4))

                        MessageBox.Show("La reserva está cancelada");
                    else
                        MessageBox.Show("La reserva se encuentra efectivizada");
                }

            }
            else            
             MessageBox.Show("Ya se ha realizado el Check-In");
        }

        private void botonCheckOut_Click(object sender, EventArgs e)
        {                        
            if(!funcionesEstadias.chequearRealizacionDeCheckOut(codigoReserva.Text))
           {
            if (estadoReservaActual == 5)
            {
                if (funcionesEstadias.chequearRealizacionDeCheckIn(codigoReserva.Text))
                { 
                  if(funcionesEstadias.chequearFechaDeEgreso(codigoReserva.Text))
                  {
                      funcionesEstadias.realizarCheckOut(codigoReserva.Text, usuarioDeSesionActual);
                      MessageBox.Show("Check-Out realizado correctamente");

                      FrbaHotel.Registrar_Consumible.Form1 formRegistrarConsumibles = new FrbaHotel.Registrar_Consumible.Form1(idHotelEnCuestion, codigoReserva.Text);
                      formRegistrarConsumibles.Show();
                      this.Close();
                  
                  }
                  else
                  {
                      if (fechaActual < fechaInicioActual)
                          MessageBox.Show(string.Format("Esta queriendo retirarse antes del inicio de la reserva que comienza el {0}",fechaInicioActual.ToShortDateString()));
                      else
                          MessageBox.Show("No se encuentra dentro del período de la reserva"); }
                                  
                  }
                else
                    MessageBox.Show("No puede retirarse antes de hacer el Check-In");  
                      
              }
        }
            else
            {


             if ((estadoReservaActual == 2) | (estadoReservaActual == 3) | (estadoReservaActual == 4))
                  MessageBox.Show("La reserva está cancelada");  
             else
                 MessageBox.Show("Ya se ha realizado el Check-Out");  
                          
            }
        
        }        

        }
    }


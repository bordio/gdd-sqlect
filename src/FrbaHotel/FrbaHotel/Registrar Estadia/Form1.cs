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
        private int fechaActual;
        //private DateTime fechaActual = DateTime.Now;


        private void Form1_Load(object sender, EventArgs e)
        {
            fechaActual = funcionesReservas.devolverFechaAppConfig();
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
                    }
                }
                else
                {
                    MessageBox.Show("Numero inválido o no corresponde al hotel de la sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            }

        private void botonCheckIn_Click(object sender, EventArgs e)
        {
            if (!funcionesEstadias.chequearRealizacionDeCheckIn(codigoReserva.Text))
            {

                if ((estadoReservaActual == 0) | (estadoReservaActual == 1))
                {
                    if (funcionesEstadias.chequearFechaDeIngreso(codigoReserva.Text,funcionesReservas.devolverFechaAppConfig()))
                    {
                        funcionesEstadias.realizarCheckIn(codigoReserva.Text, usuarioDeSesionActual,funcionesReservas.devolverFechaAppConfig());

                        
                        MessageBox.Show(string.Format("Debe registrar a {0} huésped/es como cliente/s", cantHuespedes - 1));
                        if (cantHuespedes > 1)
                        {
                            FrbaHotel.ABM_de_Cliente.ModificacionMain_Cliente formRegistrarHuespedes = new FrbaHotel.ABM_de_Cliente.ModificacionMain_Cliente(cantHuespedes-1, this);
                            formRegistrarHuespedes.ShowDialog();
                        }
                        else { TerminarCheckIn(); }
                    }
                    else
                    {
                        if (funcionesEstadias.faltaParaElCheckIn(fechaInicioActual))
                        { MessageBox.Show(string.Format("No puede ingresar antes la fecha de inicio de la reserva,que es el :{0}", fechaInicioActual.ToShortDateString())); }

                        else
                        {
                            funcionesEstadias.cancelarReservaPorNoShow(codigoReserva.Text, funcionesReservas.devolverFechaAppConfig());
                            MessageBox.Show("La reserva ha sido cancelada por no presentarse en fecha.");
                        }
                        botonCheckIn.Enabled = false;
                        botonCheckOut.Enabled = false;
                    }

                }
                else
                {
                    if ((estadoReservaActual == 2) | (estadoReservaActual == 3) | (estadoReservaActual == 4))
                    {
                        MessageBox.Show("La reserva está cancelada");
                        botonCheckOut.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("La reserva se encuentra efectivizada");
                    }
                }

            }
            else
            {
                MessageBox.Show("El Check-In no puede realizarse porque ya fue hecho con anterioridad");
                botonCheckIn.Enabled = false;
            }
        }

        private void botonCheckOut_Click(object sender, EventArgs e)
        {                        
            if(!funcionesEstadias.chequearRealizacionDeCheckOut(codigoReserva.Text))
           {
            if (estadoReservaActual == 5)
            {
                if (funcionesEstadias.chequearRealizacionDeCheckIn(codigoReserva.Text))
                { 
                  if(funcionesEstadias.chequearFechaDeEgreso(codigoReserva.Text,funcionesReservas.devolverFechaAppConfig()))
                  {
                      funcionesEstadias.realizarCheckOut(codigoReserva.Text, usuarioDeSesionActual,funcionesReservas.devolverFechaAppConfig());
                      MessageBox.Show("Check-Out realizado correctamente");

                      FrbaHotel.Registrar_Consumible.Form1 formRegistrarConsumibles = new FrbaHotel.Registrar_Consumible.Form1(idHotelEnCuestion, codigoReserva.Text);
                      formRegistrarConsumibles.ShowDialog();
                      this.Close();
                  
                  }
                  else
                  {
                      if (fechaActual < funcionesReservas.pasarDateTimeAInt(fechaInicioActual))
                          MessageBox.Show(string.Format("Esta queriendo retirarse antes del inicio de la reserva que comienza el {0}",fechaInicioActual.ToShortDateString()));
                      else
                          MessageBox.Show("Error","No se encuentra dentro del período de la reserva",MessageBoxButtons.OK,MessageBoxIcon.None); }
                                  
                  }
                else
                    MessageBox.Show("No puede retirarse antes de hacer el Check-In","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Stop);  
                      
              }
        }
            else
            {
             if ((estadoReservaActual == 2) | (estadoReservaActual == 3) | (estadoReservaActual == 4))
                  MessageBox.Show("La reserva está cancelada","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Stop);  
             else
                 MessageBox.Show("Ya se ha realizado el Check-Out","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);  
                          
            }
        
        }

        public void TerminarCheckIn() {
            Conexion.Instance.ejecutarQuery("COMMIT");
            MessageBox.Show("Check-In realizado correctamente");
            this.botonCheckIn.Visible = false;
            this.botonCheckOut.Visible = false;
            this.codigoReserva.Enabled = true;
            this.codigoReserva.Text = "";
            this.botonAceptar.Enabled = true;
        }

        }
    }


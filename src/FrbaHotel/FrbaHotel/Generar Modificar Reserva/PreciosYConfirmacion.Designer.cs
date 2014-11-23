namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class PreciosYConfirmacion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablaPreciosHabitaciones = new System.Windows.Forms.DataGridView();
            this.textoPresentacion = new System.Windows.Forms.Label();
            this.textoInformativo = new System.Windows.Forms.Label();
            this.botonElegirHabitaciones = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.textPrecioReserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPreciosHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaPreciosHabitaciones
            // 
            this.tablaPreciosHabitaciones.AllowUserToAddRows = false;
            this.tablaPreciosHabitaciones.AllowUserToDeleteRows = false;
            this.tablaPreciosHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPreciosHabitaciones.Location = new System.Drawing.Point(40, 58);
            this.tablaPreciosHabitaciones.Name = "tablaPreciosHabitaciones";
            this.tablaPreciosHabitaciones.ReadOnly = true;
            this.tablaPreciosHabitaciones.Size = new System.Drawing.Size(422, 209);
            this.tablaPreciosHabitaciones.TabIndex = 0;
            // 
            // textoPresentacion
            // 
            this.textoPresentacion.AutoSize = true;
            this.textoPresentacion.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoPresentacion.Location = new System.Drawing.Point(37, 25);
            this.textoPresentacion.Name = "textoPresentacion";
            this.textoPresentacion.Size = new System.Drawing.Size(295, 18);
            this.textoPresentacion.TabIndex = 1;
            this.textoPresentacion.Text = "Precios de cada habitacion para el régimen: ";
            // 
            // textoInformativo
            // 
            this.textoInformativo.AutoSize = true;
            this.textoInformativo.Location = new System.Drawing.Point(487, 109);
            this.textoInformativo.Name = "textoInformativo";
            this.textoInformativo.Size = new System.Drawing.Size(35, 13);
            this.textoInformativo.TabIndex = 2;
            this.textoInformativo.Text = "label1";
            // 
            // botonElegirHabitaciones
            // 
            this.botonElegirHabitaciones.Enabled = false;
            this.botonElegirHabitaciones.Location = new System.Drawing.Point(630, 287);
            this.botonElegirHabitaciones.Name = "botonElegirHabitaciones";
            this.botonElegirHabitaciones.Size = new System.Drawing.Size(132, 52);
            this.botonElegirHabitaciones.TabIndex = 3;
            this.botonElegirHabitaciones.Text = "Elegir habitaciones";
            this.botonElegirHabitaciones.UseVisualStyleBackColor = true;
            this.botonElegirHabitaciones.Click += new System.EventHandler(this.botonRealizarReserva_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(40, 287);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(132, 52);
            this.botonVolver.TabIndex = 4;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // textPrecioReserva
            // 
            this.textPrecioReserva.Enabled = false;
            this.textPrecioReserva.Location = new System.Drawing.Point(630, 177);
            this.textPrecioReserva.Name = "textPrecioReserva";
            this.textPrecioReserva.Size = new System.Drawing.Size(132, 20);
            this.textPrecioReserva.TabIndex = 5;
            this.textPrecioReserva.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Precio de la estadia:";
            // 
            // PreciosYConfirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 351);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPrecioReserva);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonElegirHabitaciones);
            this.Controls.Add(this.textoInformativo);
            this.Controls.Add(this.textoPresentacion);
            this.Controls.Add(this.tablaPreciosHabitaciones);
            this.Name = "PreciosYConfirmacion";
            this.Text = "PreciosYConfirmacion";
            this.Load += new System.EventHandler(this.PreciosYConfirmacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPreciosHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaPreciosHabitaciones;
        private System.Windows.Forms.Label textoPresentacion;
        private System.Windows.Forms.Label textoInformativo;
        private System.Windows.Forms.Button botonElegirHabitaciones;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.TextBox textPrecioReserva;
        private System.Windows.Forms.Label label1;
    }
}
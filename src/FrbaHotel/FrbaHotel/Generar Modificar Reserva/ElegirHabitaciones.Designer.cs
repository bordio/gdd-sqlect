namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ElegirHabitaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.tablaPruebaHabitaciones = new System.Windows.Forms.DataGridView();
            this.botonConfirmarReserva = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPruebaHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tilde la cantidad de habitaciones que acepto en el paso anterior";
            // 
            // tablaPruebaHabitaciones
            // 
            this.tablaPruebaHabitaciones.AllowUserToAddRows = false;
            this.tablaPruebaHabitaciones.AllowUserToDeleteRows = false;
            this.tablaPruebaHabitaciones.AllowUserToResizeColumns = false;
            this.tablaPruebaHabitaciones.AllowUserToResizeRows = false;
            this.tablaPruebaHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPruebaHabitaciones.Location = new System.Drawing.Point(30, 47);
            this.tablaPruebaHabitaciones.Name = "tablaPruebaHabitaciones";
            this.tablaPruebaHabitaciones.Size = new System.Drawing.Size(665, 223);
            this.tablaPruebaHabitaciones.TabIndex = 2;
            this.tablaPruebaHabitaciones.CurrentCellDirtyStateChanged += new System.EventHandler(this.tablaPruebaHabitaciones_CurrentCellDirtyStateChanged);
            this.tablaPruebaHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaPruebaHabitaciones_CellContentClick);
            // 
            // botonConfirmarReserva
            // 
            this.botonConfirmarReserva.Location = new System.Drawing.Point(576, 313);
            this.botonConfirmarReserva.Name = "botonConfirmarReserva";
            this.botonConfirmarReserva.Size = new System.Drawing.Size(119, 37);
            this.botonConfirmarReserva.TabIndex = 3;
            this.botonConfirmarReserva.Text = "Confirmar reserva";
            this.botonConfirmarReserva.UseVisualStyleBackColor = true;
            this.botonConfirmarReserva.Click += new System.EventHandler(this.botonConfirmarReserva_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(30, 313);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(119, 37);
            this.botonVolver.TabIndex = 4;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // ElegirHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 377);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonConfirmarReserva);
            this.Controls.Add(this.tablaPruebaHabitaciones);
            this.Controls.Add(this.label1);
            this.Name = "ElegirHabitaciones";
            this.Text = "ElegirHabitaciones";
            this.Load += new System.EventHandler(this.ElegirHabitaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPruebaHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tablaPruebaHabitaciones;
        private System.Windows.Forms.Button botonConfirmarReserva;
        private System.Windows.Forms.Button botonVolver;
    }
}
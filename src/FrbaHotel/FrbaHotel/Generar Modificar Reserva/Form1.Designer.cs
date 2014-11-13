namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.hotelDeSesion = new System.Windows.Forms.TextBox();
            this.listaHotelAElegir = new System.Windows.Forms.ComboBox();
            this.botonGenerarReserva = new System.Windows.Forms.Button();
            this.botonModificarReserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esta por realizar/modificar una reserva en el hotel:";
            // 
            // hotelDeSesion
            // 
            this.hotelDeSesion.Location = new System.Drawing.Point(297, 19);
            this.hotelDeSesion.Name = "hotelDeSesion";
            this.hotelDeSesion.Size = new System.Drawing.Size(105, 20);
            this.hotelDeSesion.TabIndex = 1;
            this.hotelDeSesion.Visible = false;
            // 
            // listaHotelAElegir
            // 
            this.listaHotelAElegir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaHotelAElegir.FormattingEnabled = true;
            this.listaHotelAElegir.Location = new System.Drawing.Point(411, 18);
            this.listaHotelAElegir.Name = "listaHotelAElegir";
            this.listaHotelAElegir.Size = new System.Drawing.Size(174, 21);
            this.listaHotelAElegir.TabIndex = 2;
            this.listaHotelAElegir.Visible = false;
            // 
            // botonGenerarReserva
            // 
            this.botonGenerarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGenerarReserva.Location = new System.Drawing.Point(297, 199);
            this.botonGenerarReserva.Name = "botonGenerarReserva";
            this.botonGenerarReserva.Size = new System.Drawing.Size(146, 54);
            this.botonGenerarReserva.TabIndex = 3;
            this.botonGenerarReserva.Text = "Realizar reserva";
            this.botonGenerarReserva.UseVisualStyleBackColor = true;
            this.botonGenerarReserva.Click += new System.EventHandler(this.botonGenerarReserva_Click);
            // 
            // botonModificarReserva
            // 
            this.botonModificarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonModificarReserva.Location = new System.Drawing.Point(538, 199);
            this.botonModificarReserva.Name = "botonModificarReserva";
            this.botonModificarReserva.Size = new System.Drawing.Size(146, 54);
            this.botonModificarReserva.TabIndex = 4;
            this.botonModificarReserva.Text = "Modificar reserva";
            this.botonModificarReserva.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 344);
            this.Controls.Add(this.botonModificarReserva);
            this.Controls.Add(this.botonGenerarReserva);
            this.Controls.Add(this.listaHotelAElegir);
            this.Controls.Add(this.hotelDeSesion);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Generar o Modificar Reserva";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hotelDeSesion;
        private System.Windows.Forms.ComboBox listaHotelAElegir;
        private System.Windows.Forms.Button botonGenerarReserva;
        private System.Windows.Forms.Button botonModificarReserva;

    }
}
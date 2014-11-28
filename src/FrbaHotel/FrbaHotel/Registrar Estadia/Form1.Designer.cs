namespace FrbaHotel.Registrar_Estadia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codigoReserva = new System.Windows.Forms.TextBox();
            this.botonCheckIn = new System.Windows.Forms.Button();
            this.botonCheckOut = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonAceptar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.codigoReserva);
            this.groupBox1.Controls.Add(this.botonCheckIn);
            this.groupBox1.Controls.Add(this.botonCheckOut);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estadía";
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(329, 105);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(89, 26);
            this.botonAceptar.TabIndex = 5;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingrese el numero de la reserva";
            // 
            // codigoReserva
            // 
            this.codigoReserva.Location = new System.Drawing.Point(45, 105);
            this.codigoReserva.Name = "codigoReserva";
            this.codigoReserva.Size = new System.Drawing.Size(195, 26);
            this.codigoReserva.TabIndex = 3;
            // 
            // botonCheckIn
            // 
            this.botonCheckIn.BackColor = System.Drawing.Color.Lime;
            this.botonCheckIn.Location = new System.Drawing.Point(45, 207);
            this.botonCheckIn.Name = "botonCheckIn";
            this.botonCheckIn.Size = new System.Drawing.Size(140, 50);
            this.botonCheckIn.TabIndex = 2;
            this.botonCheckIn.Text = "Check-In";
            this.botonCheckIn.UseVisualStyleBackColor = false;
            this.botonCheckIn.Visible = false;
            this.botonCheckIn.Click += new System.EventHandler(this.botonCheckIn_Click);
            // 
            // botonCheckOut
            // 
            this.botonCheckOut.BackColor = System.Drawing.Color.Tomato;
            this.botonCheckOut.Location = new System.Drawing.Point(317, 207);
            this.botonCheckOut.Name = "botonCheckOut";
            this.botonCheckOut.Size = new System.Drawing.Size(140, 50);
            this.botonCheckOut.TabIndex = 1;
            this.botonCheckOut.Text = "Check-Out";
            this.botonCheckOut.UseVisualStyleBackColor = false;
            this.botonCheckOut.Visible = false;
            this.botonCheckOut.Click += new System.EventHandler(this.botonCheckOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 340);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Registrar la Estadía";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonCheckOut;
        private System.Windows.Forms.Button botonCheckIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigoReserva;
        private System.Windows.Forms.Button botonAceptar;
    }
}
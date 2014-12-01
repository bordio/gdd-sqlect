namespace FrbaHotel.ABM_de_Hotel
{
    partial class Baja_Hotel
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
            this.Dar_baja = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.label845 = new System.Windows.Forms.Label();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.SeleccionarHasta = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Hasta = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.Ciudad = new System.Windows.Forms.TextBox();
            this.Pais = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SeleccionarDesde = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Desde = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dar_baja);
            this.groupBox1.Controls.Add(this.Volver);
            this.groupBox1.Controls.Add(this.label845);
            this.groupBox1.Controls.Add(this.monthCalendar2);
            this.groupBox1.Controls.Add(this.SeleccionarHasta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Hasta);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.SeleccionarDesde);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Desde);
            this.groupBox1.Controls.Add(this.txtMotivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Dar_baja
            // 
            this.Dar_baja.Location = new System.Drawing.Point(283, 396);
            this.Dar_baja.Name = "Dar_baja";
            this.Dar_baja.Size = new System.Drawing.Size(89, 30);
            this.Dar_baja.TabIndex = 30;
            this.Dar_baja.Text = "Dar de baja";
            this.Dar_baja.UseVisualStyleBackColor = true;
            this.Dar_baja.Click += new System.EventHandler(this.Dar_baja_Click);
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(395, 396);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(89, 30);
            this.Volver.TabIndex = 29;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // label845
            // 
            this.label845.AutoSize = true;
            this.label845.Location = new System.Drawing.Point(23, 242);
            this.label845.Name = "label845";
            this.label845.Size = new System.Drawing.Size(39, 13);
            this.label845.TabIndex = 27;
            this.label845.Text = "Motivo";
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(313, 203);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 25;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // SeleccionarHasta
            // 
            this.SeleccionarHasta.Location = new System.Drawing.Point(227, 203);
            this.SeleccionarHasta.Name = "SeleccionarHasta";
            this.SeleccionarHasta.Size = new System.Drawing.Size(75, 23);
            this.SeleccionarHasta.TabIndex = 26;
            this.SeleccionarHasta.Text = "Seleccionar";
            this.SeleccionarHasta.UseVisualStyleBackColor = true;
            this.SeleccionarHasta.Click += new System.EventHandler(this.SeleccionarHasta_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hasta";
            // 
            // Hasta
            // 
            this.Hasta.Location = new System.Drawing.Point(67, 205);
            this.Hasta.Name = "Hasta";
            this.Hasta.ReadOnly = true;
            this.Hasta.Size = new System.Drawing.Size(144, 20);
            this.Hasta.TabIndex = 24;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(313, 168);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 21;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Direccion);
            this.groupBox2.Controls.Add(this.Ciudad);
            this.groupBox2.Controls.Add(this.Pais);
            this.groupBox2.Controls.Add(this.Nombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 134);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos hotel";
            // 
            // Direccion
            // 
            this.Direccion.Enabled = false;
            this.Direccion.Location = new System.Drawing.Point(107, 96);
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Direccion.Size = new System.Drawing.Size(285, 20);
            this.Direccion.TabIndex = 7;
            this.Direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Ciudad
            // 
            this.Ciudad.Enabled = false;
            this.Ciudad.Location = new System.Drawing.Point(107, 71);
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            this.Ciudad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Ciudad.Size = new System.Drawing.Size(285, 20);
            this.Ciudad.TabIndex = 6;
            this.Ciudad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Pais
            // 
            this.Pais.Enabled = false;
            this.Pais.Location = new System.Drawing.Point(107, 45);
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            this.Pais.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Pais.Size = new System.Drawing.Size(285, 20);
            this.Pais.TabIndex = 5;
            this.Pais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Nombre
            // 
            this.Nombre.Enabled = false;
            this.Nombre.Location = new System.Drawing.Point(107, 19);
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nombre.Size = new System.Drawing.Size(285, 20);
            this.Nombre.TabIndex = 4;
            this.Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Direccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pais";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // SeleccionarDesde
            // 
            this.SeleccionarDesde.Location = new System.Drawing.Point(227, 168);
            this.SeleccionarDesde.Name = "SeleccionarDesde";
            this.SeleccionarDesde.Size = new System.Drawing.Size(75, 23);
            this.SeleccionarDesde.TabIndex = 22;
            this.SeleccionarDesde.Text = "Seleccionar";
            this.SeleccionarDesde.UseVisualStyleBackColor = true;
            this.SeleccionarDesde.Click += new System.EventHandler(this.SeleccionarDesde_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Desde";
            // 
            // Desde
            // 
            this.Desde.Location = new System.Drawing.Point(67, 170);
            this.Desde.Name = "Desde";
            this.Desde.ReadOnly = true;
            this.Desde.Size = new System.Drawing.Size(144, 20);
            this.Desde.TabIndex = 20;
            this.Desde.TextChanged += new System.EventHandler(this.Desde_TextChanged);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(22, 258);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMotivo.Size = new System.Drawing.Size(445, 128);
            this.txtMotivo.TabIndex = 28;
            this.txtMotivo.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // Baja_Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 461);
            this.Controls.Add(this.groupBox1);
            this.Name = "Baja_Hotel";
            this.Text = "Baja_Hotel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox Direccion;
        private System.Windows.Forms.TextBox Ciudad;
        private System.Windows.Forms.TextBox Pais;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button SeleccionarDesde;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Desde;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Button SeleccionarHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Hasta;
        private System.Windows.Forms.Button Dar_baja;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label845;
    }
}
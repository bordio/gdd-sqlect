namespace FrbaHotel.ABM_de_Hotel
{
    partial class Alta_Hotel
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
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroCalle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckMediaPension = new System.Windows.Forms.CheckBox();
            this.ckPensionCompleta = new System.Windows.Forms.CheckBox();
            this.ckAllInclusiveModerado = new System.Windows.Forms.CheckBox();
            this.ckAllInclusive = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFechaCreacion = new System.Windows.Forms.TextBox();
            this.btSeleccionarFecha = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCantEstrellas = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btAlta = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calle";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(111, 83);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(156, 20);
            this.txtCalle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nro de Calle";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.Location = new System.Drawing.Point(278, 83);
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(67, 20);
            this.txtNroCalle.TabIndex = 3;
            this.txtNroCalle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Direccion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Pais:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ciudad:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckMediaPension);
            this.groupBox1.Controls.Add(this.ckPensionCompleta);
            this.groupBox1.Controls.Add(this.ckAllInclusiveModerado);
            this.groupBox1.Controls.Add(this.ckAllInclusive);
            this.groupBox1.Location = new System.Drawing.Point(17, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regimenes";
            // 
            // ckMediaPension
            // 
            this.ckMediaPension.AutoSize = true;
            this.ckMediaPension.Location = new System.Drawing.Point(202, 44);
            this.ckMediaPension.Name = "ckMediaPension";
            this.ckMediaPension.Size = new System.Drawing.Size(95, 17);
            this.ckMediaPension.TabIndex = 3;
            this.ckMediaPension.Text = "Media pension";
            this.ckMediaPension.UseVisualStyleBackColor = true;
            // 
            // ckPensionCompleta
            // 
            this.ckPensionCompleta.AutoSize = true;
            this.ckPensionCompleta.Location = new System.Drawing.Point(202, 21);
            this.ckPensionCompleta.Name = "ckPensionCompleta";
            this.ckPensionCompleta.Size = new System.Drawing.Size(110, 17);
            this.ckPensionCompleta.TabIndex = 2;
            this.ckPensionCompleta.Text = "Pension completa";
            this.ckPensionCompleta.UseVisualStyleBackColor = true;
            // 
            // ckAllInclusiveModerado
            // 
            this.ckAllInclusiveModerado.AutoSize = true;
            this.ckAllInclusiveModerado.Location = new System.Drawing.Point(22, 44);
            this.ckAllInclusiveModerado.Name = "ckAllInclusiveModerado";
            this.ckAllInclusiveModerado.Size = new System.Drawing.Size(131, 17);
            this.ckAllInclusiveModerado.TabIndex = 1;
            this.ckAllInclusiveModerado.Text = "All inclusive moderado";
            this.ckAllInclusiveModerado.UseVisualStyleBackColor = true;
            // 
            // ckAllInclusive
            // 
            this.ckAllInclusive.AutoSize = true;
            this.ckAllInclusive.Location = new System.Drawing.Point(22, 21);
            this.ckAllInclusive.Name = "ckAllInclusive";
            this.ckAllInclusive.Size = new System.Drawing.Size(81, 17);
            this.ckAllInclusive.TabIndex = 0;
            this.ckAllInclusive.Text = "All inclusive";
            this.ckAllInclusive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Fecha de Creacion:";
            // 
            // txtFechaCreacion
            // 
            this.txtFechaCreacion.Location = new System.Drawing.Point(128, 89);
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.ReadOnly = true;
            this.txtFechaCreacion.Size = new System.Drawing.Size(98, 20);
            this.txtFechaCreacion.TabIndex = 12;
            // 
            // btSeleccionarFecha
            // 
            this.btSeleccionarFecha.Location = new System.Drawing.Point(232, 87);
            this.btSeleccionarFecha.Name = "btSeleccionarFecha";
            this.btSeleccionarFecha.Size = new System.Drawing.Size(75, 23);
            this.btSeleccionarFecha.TabIndex = 13;
            this.btSeleccionarFecha.Text = "Seleccionar";
            this.btSeleccionarFecha.UseVisualStyleBackColor = true;
            this.btSeleccionarFecha.Click += new System.EventHandler(this.btSeleccionarFecha_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(318, 87);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 14;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Cantidad de estrellas:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(128, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 16;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(128, 41);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(101, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // txtCantEstrellas
            // 
            this.txtCantEstrellas.Location = new System.Drawing.Point(128, 65);
            this.txtCantEstrellas.Name = "txtCantEstrellas";
            this.txtCantEstrellas.Size = new System.Drawing.Size(100, 20);
            this.txtCantEstrellas.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.monthCalendar1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCantEstrellas);
            this.groupBox2.Controls.Add(this.btSeleccionarFecha);
            this.groupBox2.Controls.Add(this.txtFechaCreacion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 339);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos generales";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCiudad);
            this.groupBox3.Controls.Add(this.txtPais);
            this.groupBox3.Controls.Add(this.txtCalle);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtNroCalle);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(17, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 118);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Locacion";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(111, 46);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(234, 20);
            this.txtCiudad.TabIndex = 21;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(111, 21);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(234, 20);
            this.txtPais.TabIndex = 20;
            // 
            // btAlta
            // 
            this.btAlta.Location = new System.Drawing.Point(285, 372);
            this.btAlta.Name = "btAlta";
            this.btAlta.Size = new System.Drawing.Size(115, 33);
            this.btAlta.TabIndex = 20;
            this.btAlta.Text = "Guardar";
            this.btAlta.UseVisualStyleBackColor = true;
            this.btAlta.Click += new System.EventHandler(this.btAlta_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(409, 372);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(115, 33);
            this.btVolver.TabIndex = 21;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 33);
            this.button1.TabIndex = 22;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Alta_Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 417);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btAlta);
            this.Controls.Add(this.groupBox2);
            this.Name = "Alta_Hotel";
            this.Text = "Alta_Hotel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroCalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckMediaPension;
        private System.Windows.Forms.CheckBox ckPensionCompleta;
        private System.Windows.Forms.CheckBox ckAllInclusiveModerado;
        private System.Windows.Forms.CheckBox ckAllInclusive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFechaCreacion;
        private System.Windows.Forms.Button btSeleccionarFecha;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCantEstrellas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Button btAlta;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button button1;

    }
}
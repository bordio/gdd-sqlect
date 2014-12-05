namespace FrbaHotel.ABM_de_Usuario
{
    partial class ModificacionUsuario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.radioAgregarRol = new System.Windows.Forms.RadioButton();
            this.radioQuitarRol = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboHoteles = new System.Windows.Forms.ComboBox();
            this.hotelAgregado = new System.Windows.Forms.Label();
            this.radioQuitar = new System.Windows.Forms.RadioButton();
            this.radioMantener = new System.Windows.Forms.RadioButton();
            this.hotelDondeTrabaja = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.comboTipoDNI = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.fechaNacimiento = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.TextBox();
            this.direccion = new System.Windows.Forms.TextBox();
            this.telefono = new System.Windows.Forms.TextBox();
            this.numeroDoc = new System.Windows.Forms.TextBox();
            this.apellido = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboRol);
            this.groupBox1.Controls.Add(this.radioAgregarRol);
            this.groupBox1.Controls.Add(this.radioQuitarRol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 553);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // comboRol
            // 
            this.comboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Location = new System.Drawing.Point(168, 525);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(243, 24);
            this.comboRol.TabIndex = 40;
            this.comboRol.SelectedValueChanged += new System.EventHandler(this.comboRol_SelectedValueChanged);
            // 
            // radioAgregarRol
            // 
            this.radioAgregarRol.AutoSize = true;
            this.radioAgregarRol.Location = new System.Drawing.Point(44, 525);
            this.radioAgregarRol.Name = "radioAgregarRol";
            this.radioAgregarRol.Size = new System.Drawing.Size(110, 20);
            this.radioAgregarRol.TabIndex = 39;
            this.radioAgregarRol.TabStop = true;
            this.radioAgregarRol.Text = "Agregar Rol";
            this.radioAgregarRol.UseVisualStyleBackColor = true;
            this.radioAgregarRol.CheckedChanged += new System.EventHandler(this.radioAgregarRol_CheckedChanged);
            // 
            // radioQuitarRol
            // 
            this.radioQuitarRol.AutoSize = true;
            this.radioQuitarRol.Location = new System.Drawing.Point(44, 489);
            this.radioQuitarRol.Name = "radioQuitarRol";
            this.radioQuitarRol.Size = new System.Drawing.Size(95, 20);
            this.radioQuitarRol.TabIndex = 38;
            this.radioQuitarRol.TabStop = true;
            this.radioQuitarRol.Text = "Quitar Rol";
            this.radioQuitarRol.UseVisualStyleBackColor = true;
            this.radioQuitarRol.CheckedChanged += new System.EventHandler(this.radioQuitarRol_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(558, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "(Nota: Eligiendo esta opción no podrá operar con los hoteles que tenga a cargo co" +
                "n este rol)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboHoteles);
            this.groupBox2.Controls.Add(this.hotelAgregado);
            this.groupBox2.Controls.Add(this.radioQuitar);
            this.groupBox2.Controls.Add(this.radioMantener);
            this.groupBox2.Controls.Add(this.hotelDondeTrabaja);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.monthCalendar);
            this.groupBox2.Controls.Add(this.comboTipoDNI);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.fechaNacimiento);
            this.groupBox2.Controls.Add(this.mail);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.telefono);
            this.groupBox2.Controls.Add(this.numeroDoc);
            this.groupBox2.Controls.Add(this.apellido);
            this.groupBox2.Controls.Add(this.nombre);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 419);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos identificatorios a la persona";
            // 
            // comboHoteles
            // 
            this.comboHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHoteles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboHoteles.FormattingEnabled = true;
            this.comboHoteles.Location = new System.Drawing.Point(219, 386);
            this.comboHoteles.Name = "comboHoteles";
            this.comboHoteles.Size = new System.Drawing.Size(182, 24);
            this.comboHoteles.TabIndex = 37;
            this.comboHoteles.SelectedValueChanged += new System.EventHandler(this.comboHoteles_SelectedValueChanged);
            // 
            // hotelAgregado
            // 
            this.hotelAgregado.AutoSize = true;
            this.hotelAgregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelAgregado.Location = new System.Drawing.Point(24, 386);
            this.hotelAgregado.Name = "hotelAgregado";
            this.hotelAgregado.Size = new System.Drawing.Size(129, 16);
            this.hotelAgregado.TabIndex = 36;
            this.hotelAgregado.Text = "Asignar Hotel nuevo";
            // 
            // radioQuitar
            // 
            this.radioQuitar.AutoSize = true;
            this.radioQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioQuitar.Location = new System.Drawing.Point(358, 358);
            this.radioQuitar.Name = "radioQuitar";
            this.radioQuitar.Size = new System.Drawing.Size(67, 20);
            this.radioQuitar.TabIndex = 35;
            this.radioQuitar.TabStop = true;
            this.radioQuitar.Text = "Quitar";
            this.radioQuitar.UseVisualStyleBackColor = true;
            this.radioQuitar.CheckedChanged += new System.EventHandler(this.radioQuitar_CheckedChanged);
            // 
            // radioMantener
            // 
            this.radioMantener.AutoSize = true;
            this.radioMantener.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMantener.Location = new System.Drawing.Point(219, 358);
            this.radioMantener.Name = "radioMantener";
            this.radioMantener.Size = new System.Drawing.Size(90, 20);
            this.radioMantener.TabIndex = 34;
            this.radioMantener.TabStop = true;
            this.radioMantener.Text = "Mantener";
            this.radioMantener.UseVisualStyleBackColor = true;
            this.radioMantener.CheckedChanged += new System.EventHandler(this.radioMantener_CheckedChanged);
            // 
            // hotelDondeTrabaja
            // 
            this.hotelDondeTrabaja.Enabled = false;
            this.hotelDondeTrabaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelDondeTrabaja.Location = new System.Drawing.Point(219, 324);
            this.hotelDondeTrabaja.Name = "hotelDondeTrabaja";
            this.hotelDondeTrabaja.Size = new System.Drawing.Size(100, 22);
            this.hotelDondeTrabaja.TabIndex = 33;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(336, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 25);
            this.button3.TabIndex = 32;
            this.button3.Text = "Seleccionar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(454, 178);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 31;
            this.monthCalendar.Visible = false;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // comboTipoDNI
            // 
            this.comboTipoDNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoDNI.FormattingEnabled = true;
            this.comboTipoDNI.Items.AddRange(new object[] {
            "DNI",
            "CI",
            "LC"});
            this.comboTipoDNI.Location = new System.Drawing.Point(219, 108);
            this.comboTipoDNI.Name = "comboTipoDNI";
            this.comboTipoDNI.Size = new System.Drawing.Size(100, 24);
            this.comboTipoDNI.TabIndex = 30;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(714, 284);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 15);
            this.label22.TabIndex = 29;
            this.label22.Text = "* Obligatorio";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(714, 331);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 15);
            this.label21.TabIndex = 28;
            this.label21.Text = "* Obligatorio";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(714, 215);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 15);
            this.label20.TabIndex = 27;
            this.label20.Text = "* Obligatorio";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(714, 248);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 15);
            this.label19.TabIndex = 26;
            this.label19.Text = "* Obligatorio";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(714, 143);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 15);
            this.label18.TabIndex = 25;
            this.label18.Text = "* Obligatorio";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(714, 173);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 15);
            this.label17.TabIndex = 24;
            this.label17.Text = "* Obligatorio";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(714, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "* Obligatorio";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(714, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 15);
            this.label15.TabIndex = 22;
            this.label15.Text = "* Obligatorio";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(714, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "* Obligatorio";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Enabled = false;
            this.fechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimiento.Location = new System.Drawing.Point(219, 284);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(100, 21);
            this.fechaNacimiento.TabIndex = 17;
            // 
            // mail
            // 
            this.mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail.Location = new System.Drawing.Point(219, 173);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(100, 21);
            this.mail.TabIndex = 16;
            // 
            // direccion
            // 
            this.direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion.Location = new System.Drawing.Point(219, 245);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(100, 21);
            this.direccion.TabIndex = 15;
            // 
            // telefono
            // 
            this.telefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono.Location = new System.Drawing.Point(219, 210);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 21);
            this.telefono.TabIndex = 14;
            // 
            // numeroDoc
            // 
            this.numeroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroDoc.Location = new System.Drawing.Point(219, 143);
            this.numeroDoc.Name = "numeroDoc";
            this.numeroDoc.Size = new System.Drawing.Size(100, 21);
            this.numeroDoc.TabIndex = 13;
            // 
            // apellido
            // 
            this.apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellido.Location = new System.Drawing.Point(219, 55);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 21);
            this.apellido.TabIndex = 11;
            // 
            // nombre
            // 
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(219, 25);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 21);
            this.nombre.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 324);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(176, 16);
            this.label13.TabIndex = 9;
            this.label13.Text = "Hotel donde se desempeña";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "Fecha de nacimiento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Dirección";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Teléfono";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Mail";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Número";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Documento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // username
            // 
            this.username.Enabled = false;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(103, 28);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(150, 21);
            this.username.TabIndex = 0;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(65, 560);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(128, 29);
            this.botonLimpiar.TabIndex = 2;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.Location = new System.Drawing.Point(695, 560);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(114, 29);
            this.botonConfirmar.TabIndex = 3;
            this.botonConfirmar.Text = "Confirmar cambios";
            this.botonConfirmar.UseVisualStyleBackColor = true;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click);
            // 
            // ModificacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 592);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificacionUsuario";
            this.Text = "Modificacion de Usuario";
            this.Load += new System.EventHandler(this.ModificacionUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.ComboBox comboTipoDNI;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox fechaNacimiento;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.TextBox numeroDoc;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.RadioButton radioQuitar;
        private System.Windows.Forms.RadioButton radioMantener;
        private System.Windows.Forms.TextBox hotelDondeTrabaja;
        private System.Windows.Forms.ComboBox comboHoteles;
        private System.Windows.Forms.Label hotelAgregado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioQuitarRol;
        private System.Windows.Forms.ComboBox comboRol;
        private System.Windows.Forms.RadioButton radioAgregarRol;
    }
}
namespace FrbaHotel.ABM_de_Cliente
{
    partial class ModificacionMain_Cliente
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
            this.Nombre = new System.Windows.Forms.TextBox();
            this.Apellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filtrosBusqueda = new System.Windows.Forms.GroupBox();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.TextBox();
            this.Nacionalidad = new System.Windows.Forms.TextBox();
            this.labelNumDoc = new System.Windows.Forms.Label();
            this.Documento = new System.Windows.Forms.TextBox();
            this.labelNacionalidad = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.gridClientes = new System.Windows.Forms.DataGridView();
            this.btModificar = new System.Windows.Forms.Button();
            this.btInhabilitar = new System.Windows.Forms.Button();
            this.btHabilitar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbHuespedes = new System.Windows.Forms.Label();
            this.HuespedesCant = new System.Windows.Forms.Label();
            this.btNuevo_Huesped = new System.Windows.Forms.Button();
            this.btQuitar_Huesped = new System.Windows.Forms.Button();
            this.btTerminarCheckIn = new System.Windows.Forms.Button();
            this.filtrosBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(76, 26);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(199, 20);
            this.Nombre.TabIndex = 1;
            // 
            // Apellido
            // 
            this.Apellido.Location = new System.Drawing.Point(76, 52);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(199, 20);
            this.Apellido.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // filtrosBusqueda
            // 
            this.filtrosBusqueda.Controls.Add(this.cbTipoDoc);
            this.filtrosBusqueda.Controls.Add(this.label3);
            this.filtrosBusqueda.Controls.Add(this.btLimpiar);
            this.filtrosBusqueda.Controls.Add(this.btBuscar);
            this.filtrosBusqueda.Controls.Add(this.Email);
            this.filtrosBusqueda.Controls.Add(this.Nacionalidad);
            this.filtrosBusqueda.Controls.Add(this.label2);
            this.filtrosBusqueda.Controls.Add(this.Apellido);
            this.filtrosBusqueda.Controls.Add(this.labelNumDoc);
            this.filtrosBusqueda.Controls.Add(this.Documento);
            this.filtrosBusqueda.Controls.Add(this.Nombre);
            this.filtrosBusqueda.Controls.Add(this.labelNacionalidad);
            this.filtrosBusqueda.Controls.Add(this.labelEmail);
            this.filtrosBusqueda.Controls.Add(this.label1);
            this.filtrosBusqueda.Location = new System.Drawing.Point(12, 40);
            this.filtrosBusqueda.Name = "filtrosBusqueda";
            this.filtrosBusqueda.Size = new System.Drawing.Size(789, 152);
            this.filtrosBusqueda.TabIndex = 0;
            this.filtrosBusqueda.TabStop = false;
            this.filtrosBusqueda.Text = "Filtros de Búsqueda";
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Location = new System.Drawing.Point(505, 53);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDoc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tipo Documento";
            // 
            // btLimpiar
            // 
            this.btLimpiar.Location = new System.Drawing.Point(368, 116);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(103, 23);
            this.btLimpiar.TabIndex = 8;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(242, 116);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(103, 23);
            this.btBuscar.TabIndex = 7;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(76, 80);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(199, 20);
            this.Email.TabIndex = 3;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.Location = new System.Drawing.Point(505, 29);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.Size = new System.Drawing.Size(199, 20);
            this.Nacionalidad.TabIndex = 4;
            // 
            // labelNumDoc
            // 
            this.labelNumDoc.AutoSize = true;
            this.labelNumDoc.Location = new System.Drawing.Point(397, 83);
            this.labelNumDoc.Name = "labelNumDoc";
            this.labelNumDoc.Size = new System.Drawing.Size(102, 13);
            this.labelNumDoc.TabIndex = 24;
            this.labelNumDoc.Text = "Número Documento";
            // 
            // Documento
            // 
            this.Documento.Location = new System.Drawing.Point(505, 80);
            this.Documento.Name = "Documento";
            this.Documento.Size = new System.Drawing.Size(199, 20);
            this.Documento.TabIndex = 6;
            // 
            // labelNacionalidad
            // 
            this.labelNacionalidad.AutoSize = true;
            this.labelNacionalidad.Location = new System.Drawing.Point(397, 29);
            this.labelNacionalidad.Name = "labelNacionalidad";
            this.labelNacionalidad.Size = new System.Drawing.Size(69, 13);
            this.labelNacionalidad.TabIndex = 22;
            this.labelNacionalidad.Text = "Nacionalidad";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(27, 83);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 9;
            this.labelEmail.Text = "Email";
            // 
            // gridClientes
            // 
            this.gridClientes.AllowUserToAddRows = false;
            this.gridClientes.AllowUserToDeleteRows = false;
            this.gridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridClientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClientes.Location = new System.Drawing.Point(12, 201);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.ReadOnly = true;
            this.gridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClientes.Size = new System.Drawing.Size(789, 150);
            this.gridClientes.TabIndex = 0;
            this.gridClientes.SelectionChanged += new System.EventHandler(this.gridClientes_CellContentClick);
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(41, 357);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(156, 23);
            this.btModificar.TabIndex = 9;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btInhabilitar
            // 
            this.btInhabilitar.Location = new System.Drawing.Point(404, 359);
            this.btInhabilitar.Name = "btInhabilitar";
            this.btInhabilitar.Size = new System.Drawing.Size(155, 23);
            this.btInhabilitar.TabIndex = 11;
            this.btInhabilitar.Text = "Inhabilitar";
            this.btInhabilitar.UseVisualStyleBackColor = true;
            this.btInhabilitar.Click += new System.EventHandler(this.btInhabilitar_Click);
            // 
            // btHabilitar
            // 
            this.btHabilitar.Location = new System.Drawing.Point(228, 357);
            this.btHabilitar.Name = "btHabilitar";
            this.btHabilitar.Size = new System.Drawing.Size(155, 23);
            this.btHabilitar.TabIndex = 10;
            this.btHabilitar.Text = "Habilitar";
            this.btHabilitar.UseVisualStyleBackColor = true;
            this.btHabilitar.Click += new System.EventHandler(this.btHabilitar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(588, 383);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(155, 23);
            this.btCancelar.TabIndex = 12;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbHuespedes
            // 
            this.lbHuespedes.AutoSize = true;
            this.lbHuespedes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbHuespedes.Location = new System.Drawing.Point(7, 13);
            this.lbHuespedes.Name = "lbHuespedes";
            this.lbHuespedes.Size = new System.Drawing.Size(113, 13);
            this.lbHuespedes.TabIndex = 13;
            this.lbHuespedes.Text = "Huespedes a registrar:";
            this.lbHuespedes.Visible = false;
            // 
            // HuespedesCant
            // 
            this.HuespedesCant.AutoSize = true;
            this.HuespedesCant.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.HuespedesCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HuespedesCant.Location = new System.Drawing.Point(122, 10);
            this.HuespedesCant.Name = "HuespedesCant";
            this.HuespedesCant.Size = new System.Drawing.Size(65, 18);
            this.HuespedesCant.TabIndex = 14;
            this.HuespedesCant.Text = "numero";
            this.HuespedesCant.Visible = false;
            // 
            // btNuevo_Huesped
            // 
            this.btNuevo_Huesped.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btNuevo_Huesped.Location = new System.Drawing.Point(403, 357);
            this.btNuevo_Huesped.Name = "btNuevo_Huesped";
            this.btNuevo_Huesped.Size = new System.Drawing.Size(156, 25);
            this.btNuevo_Huesped.TabIndex = 15;
            this.btNuevo_Huesped.Text = "Crear nuevo Cliente";
            this.btNuevo_Huesped.UseVisualStyleBackColor = false;
            this.btNuevo_Huesped.Visible = false;
            this.btNuevo_Huesped.Click += new System.EventHandler(this.btNuevo_Huesped_Click);
            // 
            // btQuitar_Huesped
            // 
            this.btQuitar_Huesped.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btQuitar_Huesped.Location = new System.Drawing.Point(228, 357);
            this.btQuitar_Huesped.Name = "btQuitar_Huesped";
            this.btQuitar_Huesped.Size = new System.Drawing.Size(155, 23);
            this.btQuitar_Huesped.TabIndex = 16;
            this.btQuitar_Huesped.Text = "Quitar Huesped";
            this.btQuitar_Huesped.UseVisualStyleBackColor = false;
            this.btQuitar_Huesped.Visible = false;
            this.btQuitar_Huesped.Click += new System.EventHandler(this.btQuitar_Huesped_Click);
            // 
            // btTerminarCheckIn
            // 
            this.btTerminarCheckIn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btTerminarCheckIn.Enabled = false;
            this.btTerminarCheckIn.Location = new System.Drawing.Point(588, 354);
            this.btTerminarCheckIn.Name = "btTerminarCheckIn";
            this.btTerminarCheckIn.Size = new System.Drawing.Size(155, 23);
            this.btTerminarCheckIn.TabIndex = 17;
            this.btTerminarCheckIn.Text = "TERMINAR CHECK-IN";
            this.btTerminarCheckIn.UseVisualStyleBackColor = false;
            this.btTerminarCheckIn.Visible = false;
            this.btTerminarCheckIn.Click += new System.EventHandler(this.btTerminarCheckIn_Click);
            // 
            // ModificacionMain_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 418);
            this.Controls.Add(this.btTerminarCheckIn);
            this.Controls.Add(this.btQuitar_Huesped);
            this.Controls.Add(this.btNuevo_Huesped);
            this.Controls.Add(this.HuespedesCant);
            this.Controls.Add(this.lbHuespedes);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btHabilitar);
            this.Controls.Add(this.btInhabilitar);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.gridClientes);
            this.Controls.Add(this.filtrosBusqueda);
            this.Name = "ModificacionMain_Cliente";
            this.Text = "Modificacion/Habilitacion Clientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModificacionMain_Cliente_FormClosed);
            this.filtrosBusqueda.ResumeLayout(false);
            this.filtrosBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox Apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox filtrosBusqueda;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Documento;
        private System.Windows.Forms.Label labelNacionalidad;
        private System.Windows.Forms.Label labelNumDoc;
        private System.Windows.Forms.TextBox Nacionalidad;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.DataGridView gridClientes;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btInhabilitar;
        private System.Windows.Forms.Button btHabilitar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.ComboBox cbTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbHuespedes;
        public System.Windows.Forms.Label HuespedesCant;
        private System.Windows.Forms.Button btNuevo_Huesped;
        public System.Windows.Forms.Button btQuitar_Huesped;
        private System.Windows.Forms.Button btTerminarCheckIn;
    }
}
namespace FrbaHotel.ABM_de_Cliente
{
    partial class Baja_Cliente
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
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.TextBox();
            this.Nacionalidad = new System.Windows.Forms.TextBox();
            this.labelNumPasap = new System.Windows.Forms.Label();
            this.Pasaporte = new System.Windows.Forms.TextBox();
            this.labelNacionalidad = new System.Windows.Forms.Label();
            this.labelFechaNaci = new System.Windows.Forms.Label();
            this.FechaNacimiento = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filtrosBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(57, 26);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(199, 20);
            this.Nombre.TabIndex = 1;
            // 
            // Apellido
            // 
            this.Apellido.Location = new System.Drawing.Point(57, 52);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(199, 20);
            this.Apellido.TabIndex = 3;
            this.Apellido.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // filtrosBusqueda
            // 
            this.filtrosBusqueda.Controls.Add(this.btLimpiar);
            this.filtrosBusqueda.Controls.Add(this.btBuscar);
            this.filtrosBusqueda.Controls.Add(this.Email);
            this.filtrosBusqueda.Controls.Add(this.Nacionalidad);
            this.filtrosBusqueda.Controls.Add(this.Apellido);
            this.filtrosBusqueda.Controls.Add(this.labelNumPasap);
            this.filtrosBusqueda.Controls.Add(this.Pasaporte);
            this.filtrosBusqueda.Controls.Add(this.Nombre);
            this.filtrosBusqueda.Controls.Add(this.labelNacionalidad);
            this.filtrosBusqueda.Controls.Add(this.labelFechaNaci);
            this.filtrosBusqueda.Controls.Add(this.FechaNacimiento);
            this.filtrosBusqueda.Controls.Add(this.labelEmail);
            this.filtrosBusqueda.Controls.Add(this.label1);
            this.filtrosBusqueda.Location = new System.Drawing.Point(12, 12);
            this.filtrosBusqueda.Name = "filtrosBusqueda";
            this.filtrosBusqueda.Size = new System.Drawing.Size(591, 152);
            this.filtrosBusqueda.TabIndex = 4;
            this.filtrosBusqueda.TabStop = false;
            this.filtrosBusqueda.Text = "Filtros de Búsqueda";
            this.filtrosBusqueda.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Location = new System.Drawing.Point(202, 116);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btLimpiar.TabIndex = 27;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(296, 116);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 26;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(57, 80);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(199, 20);
            this.Email.TabIndex = 5;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.Location = new System.Drawing.Point(377, 51);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.Size = new System.Drawing.Size(199, 20);
            this.Nacionalidad.TabIndex = 25;
            // 
            // labelNumPasap
            // 
            this.labelNumPasap.AutoSize = true;
            this.labelNumPasap.Location = new System.Drawing.Point(276, 83);
            this.labelNumPasap.Name = "labelNumPasap";
            this.labelNumPasap.Size = new System.Drawing.Size(95, 13);
            this.labelNumPasap.TabIndex = 24;
            this.labelNumPasap.Text = "Número Pasaporte";
            // 
            // Pasaporte
            // 
            this.Pasaporte.Location = new System.Drawing.Point(377, 80);
            this.Pasaporte.Name = "Pasaporte";
            this.Pasaporte.Size = new System.Drawing.Size(199, 20);
            this.Pasaporte.TabIndex = 6;
            // 
            // labelNacionalidad
            // 
            this.labelNacionalidad.AutoSize = true;
            this.labelNacionalidad.Location = new System.Drawing.Point(277, 54);
            this.labelNacionalidad.Name = "labelNacionalidad";
            this.labelNacionalidad.Size = new System.Drawing.Size(69, 13);
            this.labelNacionalidad.TabIndex = 22;
            this.labelNacionalidad.Text = "Nacionalidad";
            // 
            // labelFechaNaci
            // 
            this.labelFechaNaci.AutoSize = true;
            this.labelFechaNaci.Location = new System.Drawing.Point(278, 29);
            this.labelFechaNaci.Name = "labelFechaNaci";
            this.labelFechaNaci.Size = new System.Drawing.Size(93, 13);
            this.labelFechaNaci.TabIndex = 20;
            this.labelFechaNaci.Text = "Fecha Nacimiento";
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.Location = new System.Drawing.Point(377, 26);
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.Size = new System.Drawing.Size(199, 20);
            this.FechaNacimiento.TabIndex = 10;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(8, 83);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 9;
            this.labelEmail.Text = "Email";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(591, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // Listado_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 344);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filtrosBusqueda);
            this.Name = "Listado_Base";
            this.filtrosBusqueda.ResumeLayout(false);
            this.filtrosBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox FechaNacimiento;
        private System.Windows.Forms.Label labelFechaNaci;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Pasaporte;
        private System.Windows.Forms.Label labelNacionalidad;
        private System.Windows.Forms.Label labelNumPasap;
        private System.Windows.Forms.TextBox Nacionalidad;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
namespace FrbaHotel.ABM_de_Usuario
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
            this.label4 = new System.Windows.Forms.Label();
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.radioInhabilitado = new System.Windows.Forms.RadioButton();
            this.radioHabilitado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tablaDeUsuarios = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboRol);
            this.groupBox1.Controls.Add(this.radioInhabilitado);
            this.groupBox1.Controls.Add(this.radioHabilitado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(60, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(399, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rol:";
            // 
            // comboRol
            // 
            this.comboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Location = new System.Drawing.Point(485, 50);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(182, 21);
            this.comboRol.TabIndex = 5;
            // 
            // radioInhabilitado
            // 
            this.radioInhabilitado.AutoSize = true;
            this.radioInhabilitado.Location = new System.Drawing.Point(209, 117);
            this.radioInhabilitado.Name = "radioInhabilitado";
            this.radioInhabilitado.Size = new System.Drawing.Size(79, 17);
            this.radioInhabilitado.TabIndex = 4;
            this.radioInhabilitado.TabStop = true;
            this.radioInhabilitado.Text = "Inhabilitado";
            this.radioInhabilitado.UseVisualStyleBackColor = true;
            // 
            // radioHabilitado
            // 
            this.radioHabilitado.AutoSize = true;
            this.radioHabilitado.Location = new System.Drawing.Point(97, 117);
            this.radioHabilitado.Name = "radioHabilitado";
            this.radioHabilitado.Size = new System.Drawing.Size(72, 17);
            this.radioHabilitado.TabIndex = 3;
            this.radioHabilitado.TabStop = true;
            this.radioHabilitado.Text = "Habilitado";
            this.radioHabilitado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estado:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(97, 46);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(197, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuarios";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(684, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tablaDeUsuarios
            // 
            this.tablaDeUsuarios.AllowUserToAddRows = false;
            this.tablaDeUsuarios.AllowUserToDeleteRows = false;
            this.tablaDeUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaDeUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaDeUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeUsuarios.Location = new System.Drawing.Point(60, 313);
            this.tablaDeUsuarios.Name = "tablaDeUsuarios";
            this.tablaDeUsuarios.ReadOnly = true;
            this.tablaDeUsuarios.Size = new System.Drawing.Size(597, 213);
            this.tablaDeUsuarios.TabIndex = 4;
            this.tablaDeUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDeUsuarios_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(60, 581);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "Dar de Alta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Enabled = false;
            this.botonBaja.Location = new System.Drawing.Point(321, 581);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(95, 40);
            this.botonBaja.TabIndex = 6;
            this.botonBaja.Text = "Dar de Baja";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.button4_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Enabled = false;
            this.botonModificar.Location = new System.Drawing.Point(562, 581);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(95, 40);
            this.botonModificar.TabIndex = 7;
            this.botonModificar.Text = "Modificación";
            this.botonModificar.UseVisualStyleBackColor = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 745);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tablaDeUsuarios);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Main Usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioInhabilitado;
        private System.Windows.Forms.RadioButton radioHabilitado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView tablaDeUsuarios;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Button botonModificar;
    }
}
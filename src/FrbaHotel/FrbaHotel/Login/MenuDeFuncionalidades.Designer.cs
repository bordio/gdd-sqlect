namespace FrbaHotel.Login
{
    partial class MenuDeFuncionalidades
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
            this.tablaDeFuncionalidades = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listaHotelesHabilitados = new System.Windows.Forms.ComboBox();
            this.tareaARealizar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de funcionalidades disponibles";
            // 
            // tablaDeFuncionalidades
            // 
            this.tablaDeFuncionalidades.AllowUserToAddRows = false;
            this.tablaDeFuncionalidades.AllowUserToDeleteRows = false;
            this.tablaDeFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeFuncionalidades.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.tablaDeFuncionalidades.Location = new System.Drawing.Point(329, 51);
            this.tablaDeFuncionalidades.MultiSelect = false;
            this.tablaDeFuncionalidades.Name = "tablaDeFuncionalidades";
            this.tablaDeFuncionalidades.ReadOnly = true;
            this.tablaDeFuncionalidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tablaDeFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaDeFuncionalidades.Size = new System.Drawing.Size(540, 226);
            this.tablaDeFuncionalidades.TabIndex = 1;
            this.tablaDeFuncionalidades.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tablaDeFuncionalidades_CellMouseDoubleClick);
            this.tablaDeFuncionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDeFuncionalidades_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(38, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hoteles que puede gestionar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seleccione la tarea a realizar (doble click):";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(51, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Confirmar acceso";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listaHotelesHabilitados
            // 
            this.listaHotelesHabilitados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaHotelesHabilitados.FormattingEnabled = true;
            this.listaHotelesHabilitados.Location = new System.Drawing.Point(51, 111);
            this.listaHotelesHabilitados.Name = "listaHotelesHabilitados";
            this.listaHotelesHabilitados.Size = new System.Drawing.Size(121, 21);
            this.listaHotelesHabilitados.TabIndex = 6;
            // 
            // tareaARealizar
            // 
            this.tareaARealizar.Enabled = false;
            this.tareaARealizar.Location = new System.Drawing.Point(566, 305);
            this.tareaARealizar.Name = "tareaARealizar";
            this.tareaARealizar.Size = new System.Drawing.Size(168, 20);
            this.tareaARealizar.TabIndex = 7;
            // 
            // MenuDeFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 359);
            this.Controls.Add(this.tareaARealizar);
            this.Controls.Add(this.listaHotelesHabilitados);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablaDeFuncionalidades);
            this.Controls.Add(this.label1);
            this.Name = "MenuDeFuncionalidades";
            this.Text = "MenuDeFuncionalidades";
            this.Load += new System.EventHandler(this.MenuDeFuncionalidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tablaDeFuncionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox listaHotelesHabilitados;
        private System.Windows.Forms.TextBox tareaARealizar;


    }
}
namespace FrbaHotel.ABM_de_Rol
{
    partial class MainRol
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gridRoles = new System.Windows.Forms.DataGridView();
            this.bttnModificar = new System.Windows.Forms.Button();
            this.bttnNuevo = new System.Windows.Forms.Button();
            this.bttnEliminar = new System.Windows.Forms.Button();
            this.bttnVolver = new System.Windows.Forms.Button();
            this.gridFunciones = new System.Windows.Forms.DataGridView();
            this.lblFuncionalidades = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFunciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(55, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Roles";
            // 
            // gridRoles
            // 
            this.gridRoles.AllowUserToAddRows = false;
            this.gridRoles.AllowUserToDeleteRows = false;
            this.gridRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridRoles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridRoles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoles.Location = new System.Drawing.Point(12, 32);
            this.gridRoles.MultiSelect = false;
            this.gridRoles.Name = "gridRoles";
            this.gridRoles.ReadOnly = true;
            this.gridRoles.Size = new System.Drawing.Size(364, 248);
            this.gridRoles.TabIndex = 0;
            // 
            // bttnModificar
            // 
            this.bttnModificar.Enabled = false;
            this.bttnModificar.Location = new System.Drawing.Point(93, 286);
            this.bttnModificar.Name = "bttnModificar";
            this.bttnModificar.Size = new System.Drawing.Size(75, 23);
            this.bttnModificar.TabIndex = 2;
            this.bttnModificar.Text = "Modificar";
            this.bttnModificar.UseVisualStyleBackColor = true;
            // 
            // bttnNuevo
            // 
            this.bttnNuevo.Location = new System.Drawing.Point(12, 286);
            this.bttnNuevo.Name = "bttnNuevo";
            this.bttnNuevo.Size = new System.Drawing.Size(75, 23);
            this.bttnNuevo.TabIndex = 1;
            this.bttnNuevo.Text = "Nuevo";
            this.bttnNuevo.UseVisualStyleBackColor = true;
            this.bttnNuevo.Click += new System.EventHandler(this.bttnNuevo_Click);
            // 
            // bttnEliminar
            // 
            this.bttnEliminar.Enabled = false;
            this.bttnEliminar.Location = new System.Drawing.Point(174, 286);
            this.bttnEliminar.Name = "bttnEliminar";
            this.bttnEliminar.Size = new System.Drawing.Size(75, 23);
            this.bttnEliminar.TabIndex = 3;
            this.bttnEliminar.Text = "Eliminar";
            this.bttnEliminar.UseVisualStyleBackColor = true;
            // 
            // bttnVolver
            // 
            this.bttnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnVolver.Location = new System.Drawing.Point(519, 286);
            this.bttnVolver.Name = "bttnVolver";
            this.bttnVolver.Size = new System.Drawing.Size(75, 23);
            this.bttnVolver.TabIndex = 4;
            this.bttnVolver.Text = "Volver";
            this.bttnVolver.UseVisualStyleBackColor = true;
            // 
            // gridFunciones
            // 
            this.gridFunciones.AllowUserToAddRows = false;
            this.gridFunciones.AllowUserToDeleteRows = false;
            this.gridFunciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridFunciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridFunciones.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridFunciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFunciones.ColumnHeadersVisible = false;
            this.gridFunciones.Enabled = false;
            this.gridFunciones.Location = new System.Drawing.Point(383, 32);
            this.gridFunciones.MultiSelect = false;
            this.gridFunciones.Name = "gridFunciones";
            this.gridFunciones.ReadOnly = true;
            this.gridFunciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridFunciones.RowHeadersVisible = false;
            this.gridFunciones.Size = new System.Drawing.Size(211, 248);
            this.gridFunciones.TabIndex = 5;
            // 
            // lblFuncionalidades
            // 
            this.lblFuncionalidades.AutoSize = true;
            this.lblFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncionalidades.Location = new System.Drawing.Point(379, 9);
            this.lblFuncionalidades.Name = "lblFuncionalidades";
            this.lblFuncionalidades.Size = new System.Drawing.Size(140, 20);
            this.lblFuncionalidades.TabIndex = 6;
            this.lblFuncionalidades.Text = "Funcionalidades";
            // 
            // MainRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 313);
            this.Controls.Add(this.lblFuncionalidades);
            this.Controls.Add(this.gridFunciones);
            this.Controls.Add(this.bttnVolver);
            this.Controls.Add(this.bttnEliminar);
            this.Controls.Add(this.bttnNuevo);
            this.Controls.Add(this.bttnModificar);
            this.Controls.Add(this.gridRoles);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainRol";
            this.Text = "Gestión de Roles";
            this.Load += new System.EventHandler(this.MainRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFunciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView gridRoles;
        private System.Windows.Forms.Button bttnModificar;
        private System.Windows.Forms.Button bttnNuevo;
        private System.Windows.Forms.Button bttnEliminar;
        private System.Windows.Forms.Button bttnVolver;
        private System.Windows.Forms.DataGridView gridFunciones;
        private System.Windows.Forms.Label lblFuncionalidades;


    }
}
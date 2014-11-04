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
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
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
            this.tablaDeFuncionalidades.Location = new System.Drawing.Point(24, 54);
            this.tablaDeFuncionalidades.Name = "tablaDeFuncionalidades";
            this.tablaDeFuncionalidades.ReadOnly = true;
            this.tablaDeFuncionalidades.Size = new System.Drawing.Size(560, 280);
            this.tablaDeFuncionalidades.TabIndex = 1;
            // 
            // MenuDeFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 359);
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


    }
}
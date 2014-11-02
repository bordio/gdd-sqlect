namespace FrbaHotel.Listado_Estadistico
{
    partial class ListadoDelTOP5
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
            this.tablaDelTOP5 = new System.Windows.Forms.DataGridView();
            this.leyendaTOP5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDelTOP5)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDelTOP5
            // 
            this.tablaDelTOP5.AllowUserToAddRows = false;
            this.tablaDelTOP5.AllowUserToDeleteRows = false;
            this.tablaDelTOP5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaDelTOP5.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaDelTOP5.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tablaDelTOP5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDelTOP5.Location = new System.Drawing.Point(12, 41);
            this.tablaDelTOP5.Name = "tablaDelTOP5";
            this.tablaDelTOP5.Size = new System.Drawing.Size(655, 330);
            this.tablaDelTOP5.TabIndex = 0;
            // 
            // leyendaTOP5
            // 
            this.leyendaTOP5.AutoSize = true;
            this.leyendaTOP5.Location = new System.Drawing.Point(58, 13);
            this.leyendaTOP5.Name = "leyendaTOP5";
            this.leyendaTOP5.Size = new System.Drawing.Size(0, 13);
            this.leyendaTOP5.TabIndex = 1;
            this.leyendaTOP5.Visible = false;
            // 
            // ListadoDelTOP5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 383);
            this.Controls.Add(this.leyendaTOP5);
            this.Controls.Add(this.tablaDelTOP5);
            this.Name = "ListadoDelTOP5";
            this.Text = "Listado del TOP 5";
            this.Load += new System.EventHandler(this.ListadoDelTOP5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDelTOP5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDelTOP5;
        private System.Windows.Forms.Label leyendaTOP5;
    }
}
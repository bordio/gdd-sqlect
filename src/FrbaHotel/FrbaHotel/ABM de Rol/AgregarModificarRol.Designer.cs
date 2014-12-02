namespace FrbaHotel.ABM_de_Rol
{
    partial class AgregarModificarRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.bttnAceptar = new System.Windows.Forms.Button();
            this.bttnCancelar = new System.Windows.Forms.Button();
            this.chkBxGestRol = new System.Windows.Forms.CheckBox();
            this.chkBxGestUsr = new System.Windows.Forms.CheckBox();
            this.chkBxGestCli = new System.Windows.Forms.CheckBox();
            this.chkBxGestHotel = new System.Windows.Forms.CheckBox();
            this.chkBxGestHab = new System.Windows.Forms.CheckBox();
            this.chkBxGestRes = new System.Windows.Forms.CheckBox();
            this.chkBxCancelRes = new System.Windows.Forms.CheckBox();
            this.chkBxGestConsu = new System.Windows.Forms.CheckBox();
            this.chkBxGestEstad = new System.Windows.Forms.CheckBox();
            this.chkBxGestFactu = new System.Windows.Forms.CheckBox();
            this.chkBxListados = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(13, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(91, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Rol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descipción";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(127, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(127, 63);
            this.txtDescrip.Multiline = true;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(180, 60);
            this.txtDescrip.TabIndex = 1;
            // 
            // bttnAceptar
            // 
            this.bttnAceptar.Location = new System.Drawing.Point(158, 312);
            this.bttnAceptar.Name = "bttnAceptar";
            this.bttnAceptar.Size = new System.Drawing.Size(75, 23);
            this.bttnAceptar.TabIndex = 13;
            this.bttnAceptar.Text = "Aceptar";
            this.bttnAceptar.UseVisualStyleBackColor = true;
            this.bttnAceptar.Click += new System.EventHandler(this.bttnAceptar_Click);
            // 
            // bttnCancelar
            // 
            this.bttnCancelar.Location = new System.Drawing.Point(239, 312);
            this.bttnCancelar.Name = "bttnCancelar";
            this.bttnCancelar.Size = new System.Drawing.Size(75, 23);
            this.bttnCancelar.TabIndex = 14;
            this.bttnCancelar.Text = "Cancelar";
            this.bttnCancelar.UseVisualStyleBackColor = true;
            this.bttnCancelar.Click += new System.EventHandler(this.bttnCancelar_Click);
            // 
            // chkBxGestRol
            // 
            this.chkBxGestRol.AutoSize = true;
            this.chkBxGestRol.Location = new System.Drawing.Point(20, 171);
            this.chkBxGestRol.Name = "chkBxGestRol";
            this.chkBxGestRol.Size = new System.Drawing.Size(96, 17);
            this.chkBxGestRol.TabIndex = 2;
            this.chkBxGestRol.Text = "Gestionar roles";
            this.chkBxGestRol.UseVisualStyleBackColor = true;
            // 
            // chkBxGestUsr
            // 
            this.chkBxGestUsr.AutoSize = true;
            this.chkBxGestUsr.Location = new System.Drawing.Point(20, 194);
            this.chkBxGestUsr.Name = "chkBxGestUsr";
            this.chkBxGestUsr.Size = new System.Drawing.Size(113, 17);
            this.chkBxGestUsr.TabIndex = 3;
            this.chkBxGestUsr.Text = "Gestionar usuarios";
            this.chkBxGestUsr.UseVisualStyleBackColor = true;
            // 
            // chkBxGestCli
            // 
            this.chkBxGestCli.AutoSize = true;
            this.chkBxGestCli.Location = new System.Drawing.Point(20, 217);
            this.chkBxGestCli.Name = "chkBxGestCli";
            this.chkBxGestCli.Size = new System.Drawing.Size(110, 17);
            this.chkBxGestCli.TabIndex = 4;
            this.chkBxGestCli.Text = "Gestionar clientes";
            this.chkBxGestCli.UseVisualStyleBackColor = true;
            // 
            // chkBxGestHotel
            // 
            this.chkBxGestHotel.AutoSize = true;
            this.chkBxGestHotel.Location = new System.Drawing.Point(20, 240);
            this.chkBxGestHotel.Name = "chkBxGestHotel";
            this.chkBxGestHotel.Size = new System.Drawing.Size(108, 17);
            this.chkBxGestHotel.TabIndex = 5;
            this.chkBxGestHotel.Text = "Gestionar hoteles";
            this.chkBxGestHotel.UseVisualStyleBackColor = true;
            // 
            // chkBxGestHab
            // 
            this.chkBxGestHab.AutoSize = true;
            this.chkBxGestHab.Location = new System.Drawing.Point(20, 263);
            this.chkBxGestHab.Name = "chkBxGestHab";
            this.chkBxGestHab.Size = new System.Drawing.Size(134, 17);
            this.chkBxGestHab.TabIndex = 6;
            this.chkBxGestHab.Text = "Gestionar habitaciones";
            this.chkBxGestHab.UseVisualStyleBackColor = true;
            // 
            // chkBxGestRes
            // 
            this.chkBxGestRes.AutoSize = true;
            this.chkBxGestRes.Location = new System.Drawing.Point(20, 286);
            this.chkBxGestRes.Name = "chkBxGestRes";
            this.chkBxGestRes.Size = new System.Drawing.Size(154, 17);
            this.chkBxGestRes.TabIndex = 7;
            this.chkBxGestRes.Text = "Generar/modificar reservas";
            this.chkBxGestRes.UseVisualStyleBackColor = true;
            // 
            // chkBxCancelRes
            // 
            this.chkBxCancelRes.AutoSize = true;
            this.chkBxCancelRes.Location = new System.Drawing.Point(158, 171);
            this.chkBxCancelRes.Name = "chkBxCancelRes";
            this.chkBxCancelRes.Size = new System.Drawing.Size(111, 17);
            this.chkBxCancelRes.TabIndex = 8;
            this.chkBxCancelRes.Text = "Cancelar reservas";
            this.chkBxCancelRes.UseVisualStyleBackColor = true;
            // 
            // chkBxGestConsu
            // 
            this.chkBxGestConsu.AutoSize = true;
            this.chkBxGestConsu.Location = new System.Drawing.Point(158, 194);
            this.chkBxGestConsu.Name = "chkBxGestConsu";
            this.chkBxGestConsu.Size = new System.Drawing.Size(132, 17);
            this.chkBxGestConsu.TabIndex = 9;
            this.chkBxGestConsu.Text = "Gestionar consumibles";
            this.chkBxGestConsu.UseVisualStyleBackColor = true;
            // 
            // chkBxGestEstad
            // 
            this.chkBxGestEstad.AutoSize = true;
            this.chkBxGestEstad.Location = new System.Drawing.Point(158, 217);
            this.chkBxGestEstad.Name = "chkBxGestEstad";
            this.chkBxGestEstad.Size = new System.Drawing.Size(115, 17);
            this.chkBxGestEstad.TabIndex = 10;
            this.chkBxGestEstad.Text = "Gestionar estadías";
            this.chkBxGestEstad.UseVisualStyleBackColor = true;
            // 
            // chkBxGestFactu
            // 
            this.chkBxGestFactu.AutoSize = true;
            this.chkBxGestFactu.Location = new System.Drawing.Point(158, 240);
            this.chkBxGestFactu.Name = "chkBxGestFactu";
            this.chkBxGestFactu.Size = new System.Drawing.Size(82, 17);
            this.chkBxGestFactu.TabIndex = 11;
            this.chkBxGestFactu.Text = "Facturación";
            this.chkBxGestFactu.UseVisualStyleBackColor = true;
            // 
            // chkBxListados
            // 
            this.chkBxListados.AutoSize = true;
            this.chkBxListados.Location = new System.Drawing.Point(158, 263);
            this.chkBxListados.Name = "chkBxListados";
            this.chkBxListados.Size = new System.Drawing.Size(115, 17);
            this.chkBxListados.TabIndex = 12;
            this.chkBxListados.Text = "Listado estadístico";
            this.chkBxListados.UseVisualStyleBackColor = true;
            // 
            // AgregarModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 347);
            this.Controls.Add(this.chkBxListados);
            this.Controls.Add(this.chkBxGestFactu);
            this.Controls.Add(this.chkBxGestEstad);
            this.Controls.Add(this.chkBxGestConsu);
            this.Controls.Add(this.chkBxCancelRes);
            this.Controls.Add(this.chkBxGestRes);
            this.Controls.Add(this.chkBxGestHab);
            this.Controls.Add(this.chkBxGestHotel);
            this.Controls.Add(this.chkBxGestCli);
            this.Controls.Add(this.chkBxGestUsr);
            this.Controls.Add(this.chkBxGestRol);
            this.Controls.Add(this.bttnCancelar);
            this.Controls.Add(this.bttnAceptar);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "AgregarModificarRol";
            this.Text = "AgregarModificarRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.Button bttnAceptar;
        private System.Windows.Forms.Button bttnCancelar;
        private System.Windows.Forms.CheckBox chkBxGestRol;
        private System.Windows.Forms.CheckBox chkBxGestUsr;
        private System.Windows.Forms.CheckBox chkBxGestCli;
        private System.Windows.Forms.CheckBox chkBxGestHotel;
        private System.Windows.Forms.CheckBox chkBxGestHab;
        private System.Windows.Forms.CheckBox chkBxGestRes;
        private System.Windows.Forms.CheckBox chkBxCancelRes;
        private System.Windows.Forms.CheckBox chkBxGestConsu;
        private System.Windows.Forms.CheckBox chkBxGestEstad;
        private System.Windows.Forms.CheckBox chkBxGestFactu;
        private System.Windows.Forms.CheckBox chkBxListados;

    }
}
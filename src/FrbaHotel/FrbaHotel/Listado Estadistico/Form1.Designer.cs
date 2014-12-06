namespace FrbaHotel.Listado_Estadistico
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
            this.comboAño = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.top5HotReserCanc = new System.Windows.Forms.Button();
            this.comboTrimestre = new System.Windows.Forms.ComboBox();
            this.top5HotConsFact = new System.Windows.Forms.Button();
            this.top5HotFueraServ = new System.Windows.Forms.Button();
            this.top5HabMasOcup = new System.Windows.Forms.Button();
            this.top5CliMejPunt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboAño
            // 
            this.comboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAño.FormattingEnabled = true;
            this.comboAño.Location = new System.Drawing.Point(164, 85);
            this.comboAño.Name = "comboAño";
            this.comboAño.Size = new System.Drawing.Size(121, 21);
            this.comboAño.Sorted = true;
            this.comboAño.TabIndex = 0;
            this.comboAño.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre";
            // 
            // top5HotReserCanc
            // 
            this.top5HotReserCanc.Location = new System.Drawing.Point(12, 261);
            this.top5HotReserCanc.Name = "top5HotReserCanc";
            this.top5HotReserCanc.Size = new System.Drawing.Size(129, 57);
            this.top5HotReserCanc.TabIndex = 6;
            this.top5HotReserCanc.Text = "Hoteles con mayor cantidad de reservas canceladas";
            this.top5HotReserCanc.UseVisualStyleBackColor = true;
            this.top5HotReserCanc.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboTrimestre.Location = new System.Drawing.Point(164, 143);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(121, 21);
            this.comboTrimestre.Sorted = true;
            this.comboTrimestre.TabIndex = 8;
            // 
            // top5HotConsFact
            // 
            this.top5HotConsFact.Location = new System.Drawing.Point(156, 261);
            this.top5HotConsFact.Name = "top5HotConsFact";
            this.top5HotConsFact.Size = new System.Drawing.Size(129, 57);
            this.top5HotConsFact.TabIndex = 9;
            this.top5HotConsFact.Text = "Hoteles con mayor cantidad de consumibles facturados";
            this.top5HotConsFact.UseVisualStyleBackColor = true;
            this.top5HotConsFact.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // top5HotFueraServ
            // 
            this.top5HotFueraServ.Location = new System.Drawing.Point(303, 261);
            this.top5HotFueraServ.Name = "top5HotFueraServ";
            this.top5HotFueraServ.Size = new System.Drawing.Size(129, 57);
            this.top5HotFueraServ.TabIndex = 10;
            this.top5HotFueraServ.Text = "Hoteles con mayor cantidad de días fuera de servicio";
            this.top5HotFueraServ.UseVisualStyleBackColor = true;
            this.top5HotFueraServ.Click += new System.EventHandler(this.top5HotFueraServ_Click);
            // 
            // top5HabMasOcup
            // 
            this.top5HabMasOcup.Location = new System.Drawing.Point(451, 261);
            this.top5HabMasOcup.Name = "top5HabMasOcup";
            this.top5HabMasOcup.Size = new System.Drawing.Size(129, 57);
            this.top5HabMasOcup.TabIndex = 11;
            this.top5HabMasOcup.Text = "Habitaciones que mas se ocuparon";
            this.top5HabMasOcup.UseVisualStyleBackColor = true;
            this.top5HabMasOcup.Click += new System.EventHandler(this.top5HabMasOcup_Click);
            // 
            // top5CliMejPunt
            // 
            this.top5CliMejPunt.Location = new System.Drawing.Point(598, 261);
            this.top5CliMejPunt.Name = "top5CliMejPunt";
            this.top5CliMejPunt.Size = new System.Drawing.Size(129, 57);
            this.top5CliMejPunt.TabIndex = 12;
            this.top5CliMejPunt.Text = "Clientes mejores puntuados";
            this.top5CliMejPunt.UseVisualStyleBackColor = true;
            this.top5CliMejPunt.Click += new System.EventHandler(this.top5CliMejPunt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(21, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ingrese el Año y el Trimestre que desea consultar";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "TOP 5 de:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(107, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "número";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 365);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.top5CliMejPunt);
            this.Controls.Add(this.top5HabMasOcup);
            this.Controls.Add(this.top5HotFueraServ);
            this.Controls.Add(this.top5HotConsFact);
            this.Controls.Add(this.comboTrimestre);
            this.Controls.Add(this.top5HotReserCanc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAño);
            this.Name = "Form1";
            this.Text = "Listados estadísticos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button top5HotReserCanc;
        private System.Windows.Forms.ComboBox comboTrimestre;
        private System.Windows.Forms.Button top5HotConsFact;
        private System.Windows.Forms.Button top5HotFueraServ;
        private System.Windows.Forms.Button top5HabMasOcup;
        private System.Windows.Forms.Button top5CliMejPunt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
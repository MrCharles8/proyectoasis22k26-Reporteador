namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    partial class FrmTransporteInterno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransporteInterno));
            this.LogisticaNavTransporteInterno = new CapaVista_Navegador.Navegador();
            this.LogisticaLblTituloGestionViajes = new System.Windows.Forms.Label();
            this.LogisticaLblDescripcionTransporteInterno = new System.Windows.Forms.Label();
            this.LogisticaBtnConsultaTransporte = new System.Windows.Forms.Button();
            this.LogisticaBtnControlTransporte = new System.Windows.Forms.Button();
            this.LogisticaBtnTransporte = new System.Windows.Forms.Button();
            this.LogisticaBtnGestionViajes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogisticaNavTransporteInterno
            // 
            this.LogisticaNavTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavTransporteInterno.Location = new System.Drawing.Point(20, 123);
            this.LogisticaNavTransporteInterno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogisticaNavTransporteInterno.Name = "LogisticaNavTransporteInterno";
            this.LogisticaNavTransporteInterno.Size = new System.Drawing.Size(1078, 90);
            this.LogisticaNavTransporteInterno.TabIndex = 0;
            // 
            // LogisticaLblTituloGestionViajes
            // 
            this.LogisticaLblTituloGestionViajes.AutoSize = true;
            this.LogisticaLblTituloGestionViajes.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloGestionViajes.Font = new System.Drawing.Font("Lucida Fax", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblTituloGestionViajes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloGestionViajes.Location = new System.Drawing.Point(25, 13);
            this.LogisticaLblTituloGestionViajes.Name = "LogisticaLblTituloGestionViajes";
            this.LogisticaLblTituloGestionViajes.Size = new System.Drawing.Size(291, 32);
            this.LogisticaLblTituloGestionViajes.TabIndex = 4;
            this.LogisticaLblTituloGestionViajes.Text = "Transporte Interno";
            // 
            // LogisticaLblDescripcionTransporteInterno
            // 
            this.LogisticaLblDescripcionTransporteInterno.AutoSize = true;
            this.LogisticaLblDescripcionTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblDescripcionTransporteInterno.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblDescripcionTransporteInterno.Location = new System.Drawing.Point(27, 55);
            this.LogisticaLblDescripcionTransporteInterno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LogisticaLblDescripcionTransporteInterno.Name = "LogisticaLblDescripcionTransporteInterno";
            this.LogisticaLblDescripcionTransporteInterno.Size = new System.Drawing.Size(1080, 44);
            this.LogisticaLblDescripcionTransporteInterno.TabIndex = 5;
            this.LogisticaLblDescripcionTransporteInterno.Text = resources.GetString("LogisticaLblDescripcionTransporteInterno.Text");
            // 
            // LogisticaBtnConsultaTransporte
            // 
            this.LogisticaBtnConsultaTransporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnConsultaTransporte.Location = new System.Drawing.Point(713, 18);
            this.LogisticaBtnConsultaTransporte.Name = "LogisticaBtnConsultaTransporte";
            this.LogisticaBtnConsultaTransporte.Size = new System.Drawing.Size(75, 30);
            this.LogisticaBtnConsultaTransporte.TabIndex = 6;
            this.LogisticaBtnConsultaTransporte.Text = "Consulta";
            this.LogisticaBtnConsultaTransporte.UseVisualStyleBackColor = false;
            this.LogisticaBtnConsultaTransporte.Click += new System.EventHandler(this.LogisticaBtnConsultaTransporte_Click);
            // 
            // LogisticaBtnControlTransporte
            // 
            this.LogisticaBtnControlTransporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnControlTransporte.Location = new System.Drawing.Point(804, 18);
            this.LogisticaBtnControlTransporte.Name = "LogisticaBtnControlTransporte";
            this.LogisticaBtnControlTransporte.Size = new System.Drawing.Size(75, 30);
            this.LogisticaBtnControlTransporte.TabIndex = 7;
            this.LogisticaBtnControlTransporte.Text = "Control";
            this.LogisticaBtnControlTransporte.UseVisualStyleBackColor = false;
            this.LogisticaBtnControlTransporte.Click += new System.EventHandler(this.LogisticaBtnControlTransporte_Click);
            // 
            // LogisticaBtnTransporte
            // 
            this.LogisticaBtnTransporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnTransporte.Location = new System.Drawing.Point(896, 18);
            this.LogisticaBtnTransporte.Name = "LogisticaBtnTransporte";
            this.LogisticaBtnTransporte.Size = new System.Drawing.Size(75, 30);
            this.LogisticaBtnTransporte.TabIndex = 8;
            this.LogisticaBtnTransporte.Text = "Transporte";
            this.LogisticaBtnTransporte.UseVisualStyleBackColor = false;
            // 
            // LogisticaBtnGestionViajes
            // 
            this.LogisticaBtnGestionViajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnGestionViajes.Location = new System.Drawing.Point(987, 18);
            this.LogisticaBtnGestionViajes.Name = "LogisticaBtnGestionViajes";
            this.LogisticaBtnGestionViajes.Size = new System.Drawing.Size(102, 30);
            this.LogisticaBtnGestionViajes.TabIndex = 9;
            this.LogisticaBtnGestionViajes.Text = "Gestion Viajes";
            this.LogisticaBtnGestionViajes.UseVisualStyleBackColor = false;
            this.LogisticaBtnGestionViajes.Click += new System.EventHandler(this.LogisticaBtnGestionViajes_Click);
            // 
            // FrmTransporteInterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1144, 741);
            this.Controls.Add(this.LogisticaBtnGestionViajes);
            this.Controls.Add(this.LogisticaBtnTransporte);
            this.Controls.Add(this.LogisticaBtnControlTransporte);
            this.Controls.Add(this.LogisticaBtnConsultaTransporte);
            this.Controls.Add(this.LogisticaLblDescripcionTransporteInterno);
            this.Controls.Add(this.LogisticaLblTituloGestionViajes);
            this.Controls.Add(this.LogisticaNavTransporteInterno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmTransporteInterno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5013-Transporte Interno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavTransporteInterno;
        private System.Windows.Forms.Label LogisticaLblTituloGestionViajes;
        private System.Windows.Forms.Label LogisticaLblDescripcionTransporteInterno;
        private System.Windows.Forms.Button LogisticaBtnConsultaTransporte;
        private System.Windows.Forms.Button LogisticaBtnControlTransporte;
        private System.Windows.Forms.Button LogisticaBtnTransporte;
        private System.Windows.Forms.Button LogisticaBtnGestionViajes;
    }
}
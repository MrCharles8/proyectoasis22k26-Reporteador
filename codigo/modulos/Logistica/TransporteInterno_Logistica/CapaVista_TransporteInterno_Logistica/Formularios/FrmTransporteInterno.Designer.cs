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
            this.ogisticaLblDescripcionTransporteInterno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogisticaNavTransporteInterno
            // 
            this.LogisticaNavTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavTransporteInterno.Location = new System.Drawing.Point(27, 116);
            this.LogisticaNavTransporteInterno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaNavTransporteInterno.Name = "LogisticaNavTransporteInterno";
            this.LogisticaNavTransporteInterno.Size = new System.Drawing.Size(1438, 111);
            this.LogisticaNavTransporteInterno.TabIndex = 0;
            // 
            // LogisticaLblTituloGestionViajes
            // 
            this.LogisticaLblTituloGestionViajes.AutoSize = true;
            this.LogisticaLblTituloGestionViajes.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloGestionViajes.Font = new System.Drawing.Font("Lucida Fax", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblTituloGestionViajes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloGestionViajes.Location = new System.Drawing.Point(49, 16);
            this.LogisticaLblTituloGestionViajes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogisticaLblTituloGestionViajes.Name = "LogisticaLblTituloGestionViajes";
            this.LogisticaLblTituloGestionViajes.Size = new System.Drawing.Size(360, 40);
            this.LogisticaLblTituloGestionViajes.TabIndex = 4;
            this.LogisticaLblTituloGestionViajes.Text = "Transporte Interno";
            // 
            // ogisticaLblDescripcionTransporteInterno
            // 
            this.ogisticaLblDescripcionTransporteInterno.AutoSize = true;
            this.ogisticaLblDescripcionTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.ogisticaLblDescripcionTransporteInterno.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ogisticaLblDescripcionTransporteInterno.Location = new System.Drawing.Point(53, 70);
            this.ogisticaLblDescripcionTransporteInterno.Name = "ogisticaLblDescripcionTransporteInterno";
            this.ogisticaLblDescripcionTransporteInterno.Size = new System.Drawing.Size(2405, 28);
            this.ogisticaLblDescripcionTransporteInterno.TabIndex = 5;
            this.ogisticaLblDescripcionTransporteInterno.Text = resources.GetString("ogisticaLblDescripcionTransporteInterno.Text");
            // 
            // FrmTransporteInterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1525, 912);
            this.Controls.Add(this.ogisticaLblDescripcionTransporteInterno);
            this.Controls.Add(this.LogisticaLblTituloGestionViajes);
            this.Controls.Add(this.LogisticaNavTransporteInterno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label ogisticaLblDescripcionTransporteInterno;
    }
}
namespace CapaVista_TransporteInterno_Logistica.Formas
{
    partial class FrmConsultaTransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaTransporte));
            this.label2 = new System.Windows.Forms.Label();
            this.LogisticaLblTituloTransporteInterno = new System.Windows.Forms.Label();
            this.LogisticaPnlConsultaTransporte = new System.Windows.Forms.Panel();
            this.LogisticaNavTransporteInterno = new CapaVista_Navegador.Navegador();
            this.LogisticaPnlConsultaTransporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.75F);
            this.label2.Location = new System.Drawing.Point(37, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(530, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Consulta el historial de viajes y genera reportes de transporte interno.";
            // 
            // LogisticaLblTituloTransporteInterno
            // 
            this.LogisticaLblTituloTransporteInterno.AutoSize = true;
            this.LogisticaLblTituloTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloTransporteInterno.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Bold);
            this.LogisticaLblTituloTransporteInterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloTransporteInterno.Location = new System.Drawing.Point(35, 9);
            this.LogisticaLblTituloTransporteInterno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LogisticaLblTituloTransporteInterno.Name = "LogisticaLblTituloTransporteInterno";
            this.LogisticaLblTituloTransporteInterno.Size = new System.Drawing.Size(447, 32);
            this.LogisticaLblTituloTransporteInterno.TabIndex = 9;
            this.LogisticaLblTituloTransporteInterno.Text = "Consulta de Viajes y Reportes";
            // 
            // LogisticaPnlConsultaTransporte
            // 
            this.LogisticaPnlConsultaTransporte.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaPnlConsultaTransporte.BackgroundImage = global::CapaVista_TransporteInterno_Logistica.Properties.Resources.FondoLogica2;
            this.LogisticaPnlConsultaTransporte.Controls.Add(this.LogisticaLblTituloTransporteInterno);
            this.LogisticaPnlConsultaTransporte.Controls.Add(this.label2);
            this.LogisticaPnlConsultaTransporte.Controls.Add(this.LogisticaNavTransporteInterno);
            this.LogisticaPnlConsultaTransporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogisticaPnlConsultaTransporte.Location = new System.Drawing.Point(0, 0);
            this.LogisticaPnlConsultaTransporte.Name = "LogisticaPnlConsultaTransporte";
            this.LogisticaPnlConsultaTransporte.Size = new System.Drawing.Size(1144, 741);
            this.LogisticaPnlConsultaTransporte.TabIndex = 13;
            // 
            // LogisticaNavTransporteInterno
            // 
            this.LogisticaNavTransporteInterno.Location = new System.Drawing.Point(30, 85);
            this.LogisticaNavTransporteInterno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogisticaNavTransporteInterno.Name = "LogisticaNavTransporteInterno";
            this.LogisticaNavTransporteInterno.Size = new System.Drawing.Size(1078, 90);
            this.LogisticaNavTransporteInterno.TabIndex = 0;
            // 
            // FrmConsultaTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1144, 741);
            this.Controls.Add(this.LogisticaPnlConsultaTransporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmConsultaTransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5014-Consultas de Transporte";
            this.LogisticaPnlConsultaTransporte.ResumeLayout(false);
            this.LogisticaPnlConsultaTransporte.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LogisticaLblTituloTransporteInterno;
        private System.Windows.Forms.Panel LogisticaPnlConsultaTransporte;
        private CapaVista_Navegador.Navegador LogisticaNavTransporteInterno;
    }
}
namespace CapaVista_TransporteInterno_Logistica.Formas
{
    partial class FrmControlTransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlTransporte));
            this.LogisticaLblDescripcionControl = new System.Windows.Forms.Label();
            this.LogisticaLblTituloTransporteInterno = new System.Windows.Forms.Label();
            this.LogisticaPnlControlTransporte = new System.Windows.Forms.Panel();
            this.LogisticaNavTransporteInterno = new CapaVista_Navegador.Navegador();
            this.LogisticaPnlControlTransporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogisticaLblDescripcionControl
            // 
            this.LogisticaLblDescripcionControl.AutoSize = true;
            this.LogisticaLblDescripcionControl.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblDescripcionControl.Font = new System.Drawing.Font("Tahoma", 12.75F);
            this.LogisticaLblDescripcionControl.Location = new System.Drawing.Point(36, 64);
            this.LogisticaLblDescripcionControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LogisticaLblDescripcionControl.Name = "LogisticaLblDescripcionControl";
            this.LogisticaLblDescripcionControl.Size = new System.Drawing.Size(716, 21);
            this.LogisticaLblDescripcionControl.TabIndex = 8;
            this.LogisticaLblDescripcionControl.Text = "Verifica la condición del vehiculo, registra la salida, monitorea el viaje y docu" +
    "menta incidencias.";
            // 
            // LogisticaLblTituloTransporteInterno
            // 
            this.LogisticaLblTituloTransporteInterno.AutoSize = true;
            this.LogisticaLblTituloTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloTransporteInterno.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Bold);
            this.LogisticaLblTituloTransporteInterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloTransporteInterno.Location = new System.Drawing.Point(23, 19);
            this.LogisticaLblTituloTransporteInterno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LogisticaLblTituloTransporteInterno.Name = "LogisticaLblTituloTransporteInterno";
            this.LogisticaLblTituloTransporteInterno.Size = new System.Drawing.Size(552, 32);
            this.LogisticaLblTituloTransporteInterno.TabIndex = 7;
            this.LogisticaLblTituloTransporteInterno.Text = "Control y Seguimiento de Transporte";
            // 
            // LogisticaPnlControlTransporte
            // 
            this.LogisticaPnlControlTransporte.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaPnlControlTransporte.BackgroundImage = global::CapaVista_TransporteInterno_Logistica.Properties.Resources.FondoLogica2;
            this.LogisticaPnlControlTransporte.Controls.Add(this.LogisticaNavTransporteInterno);
            this.LogisticaPnlControlTransporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogisticaPnlControlTransporte.Location = new System.Drawing.Point(0, 0);
            this.LogisticaPnlControlTransporte.Name = "LogisticaPnlControlTransporte";
            this.LogisticaPnlControlTransporte.Size = new System.Drawing.Size(1144, 741);
            this.LogisticaPnlControlTransporte.TabIndex = 11;
            // 
            // LogisticaNavTransporteInterno
            // 
            this.LogisticaNavTransporteInterno.Location = new System.Drawing.Point(29, 101);
            this.LogisticaNavTransporteInterno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogisticaNavTransporteInterno.Name = "LogisticaNavTransporteInterno";
            this.LogisticaNavTransporteInterno.Size = new System.Drawing.Size(1078, 90);
            this.LogisticaNavTransporteInterno.TabIndex = 0;
            // 
            // FrmControlTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1144, 741);
            this.Controls.Add(this.LogisticaLblDescripcionControl);
            this.Controls.Add(this.LogisticaLblTituloTransporteInterno);
            this.Controls.Add(this.LogisticaPnlControlTransporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmControlTransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5015-Control de Transporte ";
            this.Load += new System.EventHandler(this.FrmControlTransporte_Load);
            this.LogisticaPnlControlTransporte.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LogisticaLblDescripcionControl;
        private System.Windows.Forms.Label LogisticaLblTituloTransporteInterno;
        private System.Windows.Forms.Panel LogisticaPnlControlTransporte;
        private CapaVista_Navegador.Navegador LogisticaNavTransporteInterno;
    }
}
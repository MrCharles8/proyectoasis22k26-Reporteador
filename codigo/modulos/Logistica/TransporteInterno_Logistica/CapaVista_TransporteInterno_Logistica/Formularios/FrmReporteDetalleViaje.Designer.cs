namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    partial class FrmReporteDetalleViaje
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
            this.LogisticaRvReporteDetalleViaje = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // LogisticaRvReporteDetalleViaje
            // 
            this.LogisticaRvReporteDetalleViaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogisticaRvReporteDetalleViaje.Location = new System.Drawing.Point(0, 0);
            this.LogisticaRvReporteDetalleViaje.Name = "LogisticaRvReporteDetalleViaje";
            this.LogisticaRvReporteDetalleViaje.ServerReport.BearerToken = null;
            this.LogisticaRvReporteDetalleViaje.Size = new System.Drawing.Size(1471, 973);
            this.LogisticaRvReporteDetalleViaje.TabIndex = 0;
            // 
            // FrmReporteDetalleViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 973);
            this.Controls.Add(this.LogisticaRvReporteDetalleViaje);
            this.MaximizeBox = false;
            this.Name = "FrmReporteDetalleViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5027-Reporte Detalle Viaje";
            this.Load += new System.EventHandler(this.FrmReporteDetalleViaje_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer LogisticaRvReporteDetalleViaje;
    }
}
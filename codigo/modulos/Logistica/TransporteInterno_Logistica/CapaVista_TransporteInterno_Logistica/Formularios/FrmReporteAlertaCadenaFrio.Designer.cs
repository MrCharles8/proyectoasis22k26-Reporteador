namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    partial class FrmReporteAlertaCadenaFrio
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
            this.LogisticaRvReporteAlertaCadenaFrio = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // LogisticaRvReporteAlertaCadenaFrio
            // 
            this.LogisticaRvReporteAlertaCadenaFrio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogisticaRvReporteAlertaCadenaFrio.Location = new System.Drawing.Point(0, 0);
            this.LogisticaRvReporteAlertaCadenaFrio.Name = "LogisticaRvReporteAlertaCadenaFrio";
            this.LogisticaRvReporteAlertaCadenaFrio.ServerReport.BearerToken = null;
            this.LogisticaRvReporteAlertaCadenaFrio.Size = new System.Drawing.Size(1471, 973);
            this.LogisticaRvReporteAlertaCadenaFrio.TabIndex = 0;
            // 
            // FrmReporteAlertaCadenaFrio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 973);
            this.Controls.Add(this.LogisticaRvReporteAlertaCadenaFrio);
            this.MaximizeBox = false;
            this.Name = "FrmReporteAlertaCadenaFrio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5033-Reporte Alerta Cadena Frio";
            this.Load += new System.EventHandler(this.FrmReporteAlertaCadenaFrio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer LogisticaRvReporteAlertaCadenaFrio;
    }
}
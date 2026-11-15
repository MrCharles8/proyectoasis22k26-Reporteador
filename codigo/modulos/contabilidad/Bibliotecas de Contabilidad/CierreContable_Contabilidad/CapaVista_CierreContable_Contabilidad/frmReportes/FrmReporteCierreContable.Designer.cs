/* Área: Contabilidad. Autor: Gabriel André Guillén Pocón. Carné: 0901-23-1998.
 * Fecha: 14/11/2026. Propósito: presentación del filtro y del visor del reporte de cierre contable. */
namespace CapaVista_Contabilidad
{
    partial class FrmReporteCierreContable
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool Disposing)
        {
            if (Disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(Disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ContabilidadTtpBotones = new System.Windows.Forms.ToolTip(this.components);
            this.ContabilidadPnlFiltros = new CapaVista_Contabilidad.Componentes.ClsPanelRedondeadoContabilidad();
            this.ContabilidadLblTitulo = new System.Windows.Forms.Label();
            this.ContabilidadLblResultado = new System.Windows.Forms.Label();
            this.ContabilidadLblPeriodo = new System.Windows.Forms.Label();
            this.ContabilidadDtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.ContabilidadBtnGenerar = new System.Windows.Forms.Button();
            this.ContabilidadRpvReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ContabilidadPnlFiltros.SuspendLayout();
            this.SuspendLayout();
            this.ContabilidadPnlFiltros.BackColor = System.Drawing.Color.Transparent;
            this.ContabilidadPnlFiltros.Controls.Add(this.ContabilidadLblTitulo);
            this.ContabilidadPnlFiltros.Controls.Add(this.ContabilidadLblResultado);
            this.ContabilidadPnlFiltros.Controls.Add(this.ContabilidadLblPeriodo);
            this.ContabilidadPnlFiltros.Controls.Add(this.ContabilidadDtpPeriodo);
            this.ContabilidadPnlFiltros.Controls.Add(this.ContabilidadBtnGenerar);
            this.ContabilidadPnlFiltros.Location = new System.Drawing.Point(24, 16);
            this.ContabilidadPnlFiltros.Name = "ContabilidadPnlFiltros";
            this.ContabilidadPnlFiltros.Size = new System.Drawing.Size(1132, 132);
            this.ContabilidadPnlFiltros.TabIndex = 0;
            this.ContabilidadLblTitulo.BackColor = System.Drawing.Color.White;
            this.ContabilidadLblTitulo.Font = new System.Drawing.Font("Lucida Fax", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ContabilidadLblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(61)))));
            this.ContabilidadLblTitulo.Location = new System.Drawing.Point(20, 12);
            this.ContabilidadLblTitulo.Name = "ContabilidadLblTitulo";
            this.ContabilidadLblTitulo.Size = new System.Drawing.Size(520, 34);
            this.ContabilidadLblTitulo.TabIndex = 0;
            this.ContabilidadLblTitulo.Text = "Reporte de cierre contable";
            this.ContabilidadLblResultado.BackColor = System.Drawing.Color.White;
            this.ContabilidadLblResultado.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ContabilidadLblResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(104)))), ((int)(((byte)(125)))));
            this.ContabilidadLblResultado.Location = new System.Drawing.Point(560, 18);
            this.ContabilidadLblResultado.Name = "ContabilidadLblResultado";
            this.ContabilidadLblResultado.Size = new System.Drawing.Size(470, 24);
            this.ContabilidadLblResultado.TabIndex = 0;
            this.ContabilidadLblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ContabilidadLblPeriodo.BackColor = System.Drawing.Color.White;
            this.ContabilidadLblPeriodo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ContabilidadLblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(50)))), ((int)(((byte)(61)))));
            this.ContabilidadLblPeriodo.Location = new System.Drawing.Point(20, 52);
            this.ContabilidadLblPeriodo.Name = "ContabilidadLblPeriodo";
            this.ContabilidadLblPeriodo.Size = new System.Drawing.Size(150, 22);
            this.ContabilidadLblPeriodo.TabIndex = 0;
            this.ContabilidadLblPeriodo.Text = "Período";
            this.ContabilidadDtpPeriodo.CustomFormat = "MM/yyyy";
            this.ContabilidadDtpPeriodo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ContabilidadDtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ContabilidadDtpPeriodo.Location = new System.Drawing.Point(20, 76);
            this.ContabilidadDtpPeriodo.Name = "ContabilidadDtpPeriodo";
            this.ContabilidadDtpPeriodo.ShowUpDown = true;
            this.ContabilidadDtpPeriodo.Size = new System.Drawing.Size(150, 30);
            this.ContabilidadDtpPeriodo.TabIndex = 1;
            this.ContabilidadBtnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.ContabilidadBtnGenerar.BackgroundImage = global::CapaVista_Contabilidad.Properties.Resources.btn_revisarPeriodo;
            this.ContabilidadBtnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContabilidadBtnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContabilidadBtnGenerar.FlatAppearance.BorderSize = 0;
            this.ContabilidadBtnGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ContabilidadBtnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ContabilidadBtnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContabilidadBtnGenerar.Location = new System.Drawing.Point(1052, 50);
            this.ContabilidadBtnGenerar.Name = "ContabilidadBtnGenerar";
            this.ContabilidadBtnGenerar.Size = new System.Drawing.Size(60, 60);
            this.ContabilidadBtnGenerar.TabIndex = 2;
            this.ContabilidadBtnGenerar.UseVisualStyleBackColor = false;
            this.ContabilidadRpvReporte.Location = new System.Drawing.Point(24, 160);
            this.ContabilidadRpvReporte.Name = "ContabilidadRpvReporte";
            this.ContabilidadRpvReporte.ServerReport.BearerToken = null;
            this.ContabilidadRpvReporte.Size = new System.Drawing.Size(1132, 588);
            this.ContabilidadRpvReporte.TabIndex = 3;
            this.AcceptButton = this.ContabilidadBtnGenerar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1180, 768);
            this.Controls.Add(this.ContabilidadPnlFiltros);
            this.Controls.Add(this.ContabilidadRpvReporte);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::CapaVista_Contabilidad.Properties.Resources.Icono_Contabilidad;
            this.MaximizeBox = false;
            this.Name = "FrmReporteCierreContable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "10004 - ReporteCierreContable";
            this.ContabilidadPnlFiltros.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip ContabilidadTtpBotones;
        private Componentes.ClsPanelRedondeadoContabilidad ContabilidadPnlFiltros;
        private System.Windows.Forms.Label ContabilidadLblTitulo;
        private System.Windows.Forms.Label ContabilidadLblResultado;
        private System.Windows.Forms.Label ContabilidadLblPeriodo;
        private System.Windows.Forms.DateTimePicker ContabilidadDtpPeriodo;
        private System.Windows.Forms.Button ContabilidadBtnGenerar;
        private Microsoft.Reporting.WinForms.ReportViewer ContabilidadRpvReporte;
    }
}

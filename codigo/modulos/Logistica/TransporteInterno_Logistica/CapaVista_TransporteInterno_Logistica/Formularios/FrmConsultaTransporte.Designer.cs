namespace CapaVista_TransporteInterno_Logistica.Formularios
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
            this.LogisticaNavConsultaTransporte = new CapaVista_Navegador.Navegador();
            this.LogisticaLblTituloConsultaTransporte = new System.Windows.Forms.Label();
            this.ogisticaLblDescripcionConsultaTransporte = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogisticaNavConsultaTransporte
            // 
            this.LogisticaNavConsultaTransporte.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavConsultaTransporte.Location = new System.Drawing.Point(20, 94);
            this.LogisticaNavConsultaTransporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogisticaNavConsultaTransporte.Name = "LogisticaNavConsultaTransporte";
            this.LogisticaNavConsultaTransporte.Size = new System.Drawing.Size(1078, 90);
            this.LogisticaNavConsultaTransporte.TabIndex = 0;
            // 
            // LogisticaLblTituloConsultaTransporte
            // 
            this.LogisticaLblTituloConsultaTransporte.AutoSize = true;
            this.LogisticaLblTituloConsultaTransporte.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloConsultaTransporte.Font = new System.Drawing.Font("Lucida Fax", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblTituloConsultaTransporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloConsultaTransporte.Location = new System.Drawing.Point(37, 13);
            this.LogisticaLblTituloConsultaTransporte.Name = "LogisticaLblTituloConsultaTransporte";
            this.LogisticaLblTituloConsultaTransporte.Size = new System.Drawing.Size(357, 32);
            this.LogisticaLblTituloConsultaTransporte.TabIndex = 1;
            this.LogisticaLblTituloConsultaTransporte.Text = "Consulta de Transporte";
            // 
            // ogisticaLblDescripcionConsultaTransporte
            // 
            this.ogisticaLblDescripcionConsultaTransporte.AutoSize = true;
            this.ogisticaLblDescripcionConsultaTransporte.BackColor = System.Drawing.Color.Transparent;
            this.ogisticaLblDescripcionConsultaTransporte.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ogisticaLblDescripcionConsultaTransporte.Location = new System.Drawing.Point(40, 57);
            this.ogisticaLblDescripcionConsultaTransporte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ogisticaLblDescripcionConsultaTransporte.Name = "ogisticaLblDescripcionConsultaTransporte";
            this.ogisticaLblDescripcionConsultaTransporte.Size = new System.Drawing.Size(560, 22);
            this.ogisticaLblDescripcionConsultaTransporte.TabIndex = 8;
            this.ogisticaLblDescripcionConsultaTransporte.Text = "Consulta el historial de viajes y genera reportes de transporte interno.";
            // 
            // FrmConsultaTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1144, 741);
            this.Controls.Add(this.ogisticaLblDescripcionConsultaTransporte);
            this.Controls.Add(this.LogisticaLblTituloConsultaTransporte);
            this.Controls.Add(this.LogisticaNavConsultaTransporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FrmConsultaTransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5014-Consultas de Transporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavConsultaTransporte;
        private System.Windows.Forms.Label LogisticaLblTituloConsultaTransporte;
        private System.Windows.Forms.Label ogisticaLblDescripcionConsultaTransporte;
    }
}
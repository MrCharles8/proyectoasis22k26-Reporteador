namespace CapaVista_TransporteInterno_Logistica.Formularios
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
            this.LogisticaNavControlTransporte = new CapaVista_Navegador.Navegador();
            this.LogisticaLblTituloControlTransporte = new System.Windows.Forms.Label();
            this.ogisticaLblDescripcionControlTransporte = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogisticaNavControlTransporte
            // 
            this.LogisticaNavControlTransporte.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavControlTransporte.Location = new System.Drawing.Point(27, 116);
            this.LogisticaNavControlTransporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaNavControlTransporte.Name = "LogisticaNavControlTransporte";
            this.LogisticaNavControlTransporte.Size = new System.Drawing.Size(1438, 111);
            this.LogisticaNavControlTransporte.TabIndex = 0;
            // 
            // LogisticaLblTituloControlTransporte
            // 
            this.LogisticaLblTituloControlTransporte.AutoSize = true;
            this.LogisticaLblTituloControlTransporte.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloControlTransporte.Font = new System.Drawing.Font("Lucida Fax", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblTituloControlTransporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloControlTransporte.Location = new System.Drawing.Point(49, 16);
            this.LogisticaLblTituloControlTransporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogisticaLblTituloControlTransporte.Name = "LogisticaLblTituloControlTransporte";
            this.LogisticaLblTituloControlTransporte.Size = new System.Drawing.Size(417, 40);
            this.LogisticaLblTituloControlTransporte.TabIndex = 2;
            this.LogisticaLblTituloControlTransporte.Text = "Control de Transporte";
            // 
            // ogisticaLblDescripcionControlTransporte
            // 
            this.ogisticaLblDescripcionControlTransporte.AutoSize = true;
            this.ogisticaLblDescripcionControlTransporte.BackColor = System.Drawing.Color.Transparent;
            this.ogisticaLblDescripcionControlTransporte.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ogisticaLblDescripcionControlTransporte.Location = new System.Drawing.Point(53, 70);
            this.ogisticaLblDescripcionControlTransporte.Name = "ogisticaLblDescripcionControlTransporte";
            this.ogisticaLblDescripcionControlTransporte.Size = new System.Drawing.Size(970, 28);
            this.ogisticaLblDescripcionControlTransporte.TabIndex = 7;
            this.ogisticaLblDescripcionControlTransporte.Text = "Verifica la condición del vehículo, registra la salida, monitorea el viaje y docu" +
    "menta incidencias.";
            // 
            // FrmControlTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1525, 912);
            this.Controls.Add(this.ogisticaLblDescripcionControlTransporte);
            this.Controls.Add(this.LogisticaLblTituloControlTransporte);
            this.Controls.Add(this.LogisticaNavControlTransporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmControlTransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5015-Control de Transporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavControlTransporte;
        private System.Windows.Forms.Label LogisticaLblTituloControlTransporte;
        private System.Windows.Forms.Label ogisticaLblDescripcionControlTransporte;
    }
}
namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    partial class FrmMantenimientoTransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantenimientoTransporte));
            this.LogisticaNavTransporteInterno = new CapaVista_Navegador.Navegador();
            this.LogisticaLblTituloTransporteInterno = new System.Windows.Forms.Label();
            this.LogisticaLblDescripcionTransporteInterno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogisticaNavTransporteInterno
            // 
            this.LogisticaNavTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavTransporteInterno.Location = new System.Drawing.Point(29, 119);
            this.LogisticaNavTransporteInterno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaNavTransporteInterno.Name = "LogisticaNavTransporteInterno";
            this.LogisticaNavTransporteInterno.Size = new System.Drawing.Size(1437, 111);
            this.LogisticaNavTransporteInterno.TabIndex = 0;
            // 
            // LogisticaLblTituloTransporteInterno
            // 
            this.LogisticaLblTituloTransporteInterno.AutoSize = true;
            this.LogisticaLblTituloTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloTransporteInterno.Font = new System.Drawing.Font("Lucida Fax", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblTituloTransporteInterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloTransporteInterno.Location = new System.Drawing.Point(33, 16);
            this.LogisticaLblTituloTransporteInterno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogisticaLblTituloTransporteInterno.Name = "LogisticaLblTituloTransporteInterno";
            this.LogisticaLblTituloTransporteInterno.Size = new System.Drawing.Size(353, 38);
            this.LogisticaLblTituloTransporteInterno.TabIndex = 4;
            this.LogisticaLblTituloTransporteInterno.Text = "Transporte Interno";
            // 
            // LogisticaLblDescripcionTransporteInterno
            // 
            this.LogisticaLblDescripcionTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblDescripcionTransporteInterno.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblDescripcionTransporteInterno.Location = new System.Drawing.Point(36, 68);
            this.LogisticaLblDescripcionTransporteInterno.Name = "LogisticaLblDescripcionTransporteInterno";
            this.LogisticaLblDescripcionTransporteInterno.Size = new System.Drawing.Size(1784, 70);
            this.LogisticaLblDescripcionTransporteInterno.TabIndex = 5;
            this.LogisticaLblDescripcionTransporteInterno.Text = "Administra la información de los vehículos utilizados en el transporte interno, i" +
    "ncluyendo placas, marcas, modelos, años, tipos de transporte.";
            // 
            // FrmMantenimientoTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1525, 912);
            this.Controls.Add(this.LogisticaLblDescripcionTransporteInterno);
            this.Controls.Add(this.LogisticaLblTituloTransporteInterno);
            this.Controls.Add(this.LogisticaNavTransporteInterno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmMantenimientoTransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5013-Transporte Interno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavTransporteInterno;
        private System.Windows.Forms.Label LogisticaLblTituloTransporteInterno;
        private System.Windows.Forms.Label LogisticaLblDescripcionTransporteInterno;
    }
}
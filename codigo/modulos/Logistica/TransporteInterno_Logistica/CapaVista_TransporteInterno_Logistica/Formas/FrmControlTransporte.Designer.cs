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
            this.LogisticaNavTransporteInterno = new CapaVista_Navegador.Navegador();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescripcionControl = new System.Windows.Forms.Label();
            this.LogisticaLblTituloTransporteInterno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LogisticaNavTransporteInterno
            // 
            this.LogisticaNavTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavTransporteInterno.Location = new System.Drawing.Point(-12, -12);
            this.LogisticaNavTransporteInterno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaNavTransporteInterno.Name = "LogisticaNavTransporteInterno";
            this.LogisticaNavTransporteInterno.Size = new System.Drawing.Size(1437, 111);
            this.LogisticaNavTransporteInterno.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaVista_TransporteInterno_Logistica.Properties.Resources._7;
            this.pictureBox1.Location = new System.Drawing.Point(1091, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 322);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescripcionControl
            // 
            this.lblDescripcionControl.AutoSize = true;
            this.lblDescripcionControl.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcionControl.Font = new System.Drawing.Font("Tahoma", 12.75F);
            this.lblDescripcionControl.Location = new System.Drawing.Point(7, 141);
            this.lblDescripcionControl.Name = "lblDescripcionControl";
            this.lblDescripcionControl.Size = new System.Drawing.Size(942, 27);
            this.lblDescripcionControl.TabIndex = 8;
            this.lblDescripcionControl.Text = "Verifica la condición del vehiculo, registra la salida, monitorea el viaje y docu" +
    "menta incidencias.";
            // 
            // LogisticaLblTituloTransporteInterno
            // 
            this.LogisticaLblTituloTransporteInterno.AutoSize = true;
            this.LogisticaLblTituloTransporteInterno.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloTransporteInterno.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Bold);
            this.LogisticaLblTituloTransporteInterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloTransporteInterno.Location = new System.Drawing.Point(9, 101);
            this.LogisticaLblTituloTransporteInterno.Name = "LogisticaLblTituloTransporteInterno";
            this.LogisticaLblTituloTransporteInterno.Size = new System.Drawing.Size(681, 40);
            this.LogisticaLblTituloTransporteInterno.TabIndex = 7;
            this.LogisticaLblTituloTransporteInterno.Text = "Control y Seguimiento de Transporte";
            // 
            // FrmControlTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaVista_TransporteInterno_Logistica.Properties.Resources.FondoLogistica;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.LogisticaNavTransporteInterno);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDescripcionControl);
            this.Controls.Add(this.LogisticaLblTituloTransporteInterno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmControlTransporte";
            this.Text = "5015-Control de Transporte ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavTransporteInterno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescripcionControl;
        private System.Windows.Forms.Label LogisticaLblTituloTransporteInterno;
    }
}
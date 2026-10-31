namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    partial class LogisticaNavGestionViajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogisticaNavGestionViajes));
            this.LogisticaNavGestiondeViajes = new CapaVista_Navegador.Navegador();
            this.LogisticaLblTituloGestionViajes = new System.Windows.Forms.Label();
            this.ogisticaLblDescripcionGestionViajes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogisticaNavGestiondeViajes
            // 
            this.LogisticaNavGestiondeViajes.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaNavGestiondeViajes.Location = new System.Drawing.Point(27, 116);
            this.LogisticaNavGestiondeViajes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaNavGestiondeViajes.Name = "LogisticaNavGestiondeViajes";
            this.LogisticaNavGestiondeViajes.Size = new System.Drawing.Size(1438, 111);
            this.LogisticaNavGestiondeViajes.TabIndex = 0;
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
            this.LogisticaLblTituloGestionViajes.Size = new System.Drawing.Size(327, 40);
            this.LogisticaLblTituloGestionViajes.TabIndex = 3;
            this.LogisticaLblTituloGestionViajes.Text = "Gestión de Viajes";
            // 
            // ogisticaLblDescripcionGestionViajes
            // 
            this.ogisticaLblDescripcionGestionViajes.AutoSize = true;
            this.ogisticaLblDescripcionGestionViajes.BackColor = System.Drawing.Color.Transparent;
            this.ogisticaLblDescripcionGestionViajes.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ogisticaLblDescripcionGestionViajes.Location = new System.Drawing.Point(53, 70);
            this.ogisticaLblDescripcionGestionViajes.Name = "ogisticaLblDescripcionGestionViajes";
            this.ogisticaLblDescripcionGestionViajes.Size = new System.Drawing.Size(716, 28);
            this.ogisticaLblDescripcionGestionViajes.TabIndex = 6;
            this.ogisticaLblDescripcionGestionViajes.Text = "Registra, asigna y controla cada etapa del viaje de transporte interno.";
            // 
            // LogisticaNavGestionViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1525, 912);
            this.Controls.Add(this.ogisticaLblDescripcionGestionViajes);
            this.Controls.Add(this.LogisticaLblTituloGestionViajes);
            this.Controls.Add(this.LogisticaNavGestiondeViajes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogisticaNavGestionViajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5016-Gestion de Viajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavGestiondeViajes;
        private System.Windows.Forms.Label LogisticaLblTituloGestionViajes;
        private System.Windows.Forms.Label ogisticaLblDescripcionGestionViajes;
    }
}
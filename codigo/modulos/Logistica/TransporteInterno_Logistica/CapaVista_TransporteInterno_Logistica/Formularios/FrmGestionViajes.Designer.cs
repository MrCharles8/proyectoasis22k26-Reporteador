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
            this.SuspendLayout();
            // 
            // LogisticaNavGestiondeViajes
            // 
            this.LogisticaNavGestiondeViajes.Location = new System.Drawing.Point(-15, 85);
            this.LogisticaNavGestiondeViajes.Name = "LogisticaNavGestiondeViajes";
            this.LogisticaNavGestiondeViajes.Size = new System.Drawing.Size(1438, 111);
            this.LogisticaNavGestiondeViajes.TabIndex = 0;
            // 
            // LogisticaNavGestionViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1525, 912);
            this.Controls.Add(this.LogisticaNavGestiondeViajes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogisticaNavGestionViajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5016-Gestion de Viajes";
            this.ResumeLayout(false);

        }

        #endregion

        private CapaVista_Navegador.Navegador LogisticaNavGestiondeViajes;
    }
}
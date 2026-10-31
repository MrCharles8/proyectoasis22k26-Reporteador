namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    partial class FrmTipoTraslado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipoTraslado));
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.grpTipoTraslado = new System.Windows.Forms.GroupBox();
            this.rdbInterno = new System.Windows.Forms.RadioButton();
            this.rdbExterno = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblInterno = new System.Windows.Forms.Label();
            this.lblExterno = new System.Windows.Forms.Label();
            this.pnlEncabezado.SuspendLayout();
            this.grpTipoTraslado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(655, 90);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(25, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(244, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tipo de Traslado";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 53);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(354, 23);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Seleccione el tipo de traslado para continuar.";
            // 
            // grpTipoTraslado
            // 
            this.grpTipoTraslado.Controls.Add(this.lblExterno);
            this.grpTipoTraslado.Controls.Add(this.lblInterno);
            this.grpTipoTraslado.Controls.Add(this.rdbExterno);
            this.grpTipoTraslado.Controls.Add(this.rdbInterno);
            this.grpTipoTraslado.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTipoTraslado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.grpTipoTraslado.Location = new System.Drawing.Point(25, 115);
            this.grpTipoTraslado.Name = "grpTipoTraslado";
            this.grpTipoTraslado.Size = new System.Drawing.Size(530, 160);
            this.grpTipoTraslado.TabIndex = 1;
            this.grpTipoTraslado.TabStop = false;
            this.grpTipoTraslado.Text = "Tipo de traslado";
            // 
            // rdbInterno
            // 
            this.rdbInterno.AutoSize = true;
            this.rdbInterno.Checked = true;
            this.rdbInterno.Location = new System.Drawing.Point(25, 40);
            this.rdbInterno.Name = "rdbInterno";
            this.rdbInterno.Size = new System.Drawing.Size(172, 29);
            this.rdbInterno.TabIndex = 0;
            this.rdbInterno.TabStop = true;
            this.rdbInterno.Text = "Traslado interno";
            this.rdbInterno.UseVisualStyleBackColor = true;
            // 
            // rdbExterno
            // 
            this.rdbExterno.AutoSize = true;
            this.rdbExterno.Location = new System.Drawing.Point(275, 40);
            this.rdbExterno.Name = "rdbExterno";
            this.rdbExterno.Size = new System.Drawing.Size(176, 29);
            this.rdbExterno.TabIndex = 1;
            this.rdbExterno.TabStop = true;
            this.rdbExterno.Text = "Traslado externo";
            this.rdbExterno.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(285, 310);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 42);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "✔ Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.btnCancelar.Location = new System.Drawing.Point(425, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 42);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "✕ Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblInterno
            // 
            this.lblInterno.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterno.Location = new System.Drawing.Point(48, 72);
            this.lblInterno.Name = "lblInterno";
            this.lblInterno.Size = new System.Drawing.Size(210, 55);
            this.lblInterno.TabIndex = 2;
            this.lblInterno.Text = "Entre bodegas o áreas de producción.";
            // 
            // lblExterno
            // 
            this.lblExterno.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExterno.Location = new System.Drawing.Point(297, 72);
            this.lblExterno.Name = "lblExterno";
            this.lblExterno.Size = new System.Drawing.Size(210, 55);
            this.lblExterno.TabIndex = 3;
            this.lblExterno.Text = "Entre sucursales o instalaciones externas.";
            this.lblExterno.Click += new System.EventHandler(this.lblExterno_Click);
            // 
            // FrmTipoTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(655, 522);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grpTipoTraslado);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTipoTraslado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "\tSelección de Tipo de Traslado";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.grpTipoTraslado.ResumeLayout(false);
            this.grpTipoTraslado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.GroupBox grpTipoTraslado;
        private System.Windows.Forms.RadioButton rdbExterno;
        private System.Windows.Forms.RadioButton rdbInterno;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblExterno;
        private System.Windows.Forms.Label lblInterno;
        private System.Windows.Forms.Button btnCancelar;
    }
}
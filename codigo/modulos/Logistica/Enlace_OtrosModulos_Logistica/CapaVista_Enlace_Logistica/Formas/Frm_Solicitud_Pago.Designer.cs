namespace CapaVista_Enlace_Logistica.Formas
{
    partial class Frm_Solicitud_Pago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Solicitud_Pago));
            this.pnlFondoSolicitudPago = new System.Windows.Forms.Panel();
            this.lblDescripcionSolicitudPago = new System.Windows.Forms.Label();
            this.lblTituloSolicitudPago = new System.Windows.Forms.Label();
            this.picChef = new System.Windows.Forms.PictureBox();
            this.pnlSeleccionServicio = new System.Windows.Forms.Panel();
            this.lblNumeroSeccionServicio = new System.Windows.Forms.Label();
            this.lblTituloSeleccionServicio = new System.Windows.Forms.Label();
            this.lblServicioTransporte = new System.Windows.Forms.Label();
            this.cboServicioTransporte = new System.Windows.Forms.ComboBox();
            this.lblNumeroServicio = new System.Windows.Forms.Label();
            this.txtNumeroServicio = new System.Windows.Forms.TextBox();
            this.lblNumeroGuia = new System.Windows.Forms.Label();
            this.txtNumeroGuia = new System.Windows.Forms.TextBox();
            this.lblFechaServicio = new System.Windows.Forms.Label();
            this.txtFechaServicio = new System.Windows.Forms.TextBox();
            this.pnlFondoSolicitudPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChef)).BeginInit();
            this.pnlSeleccionServicio.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondoSolicitudPago
            // 
            this.pnlFondoSolicitudPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlFondoSolicitudPago.BackgroundImage")));
            this.pnlFondoSolicitudPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFondoSolicitudPago.Controls.Add(this.pnlSeleccionServicio);
            this.pnlFondoSolicitudPago.Controls.Add(this.lblDescripcionSolicitudPago);
            this.pnlFondoSolicitudPago.Controls.Add(this.lblTituloSolicitudPago);
            this.pnlFondoSolicitudPago.Controls.Add(this.picChef);
            this.pnlFondoSolicitudPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFondoSolicitudPago.Location = new System.Drawing.Point(0, 0);
            this.pnlFondoSolicitudPago.Name = "pnlFondoSolicitudPago";
            this.pnlFondoSolicitudPago.Size = new System.Drawing.Size(1525, 912);
            this.pnlFondoSolicitudPago.TabIndex = 0;
            this.pnlFondoSolicitudPago.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFondoSolicitudPago_Paint);
            // 
            // lblDescripcionSolicitudPago
            // 
            this.lblDescripcionSolicitudPago.AutoSize = true;
            this.lblDescripcionSolicitudPago.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcionSolicitudPago.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionSolicitudPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDescripcionSolicitudPago.Location = new System.Drawing.Point(187, 70);
            this.lblDescripcionSolicitudPago.Name = "lblDescripcionSolicitudPago";
            this.lblDescripcionSolicitudPago.Size = new System.Drawing.Size(883, 22);
            this.lblDescripcionSolicitudPago.TabIndex = 2;
            this.lblDescripcionSolicitudPago.Text = "Seleccione un servicio de transporte externo para generar y enviar su solicitud d" +
    "e pago directamente a Bancos.";
            // 
            // lblTituloSolicitudPago
            // 
            this.lblTituloSolicitudPago.AutoSize = true;
            this.lblTituloSolicitudPago.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloSolicitudPago.Font = new System.Drawing.Font("Lucida Bright", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSolicitudPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.lblTituloSolicitudPago.Location = new System.Drawing.Point(239, 20);
            this.lblTituloSolicitudPago.Name = "lblTituloSolicitudPago";
            this.lblTituloSolicitudPago.Size = new System.Drawing.Size(730, 50);
            this.lblTituloSolicitudPago.TabIndex = 1;
            this.lblTituloSolicitudPago.Text = "Generación de Solicitud de Pago";
            // 
            // picChef
            // 
            this.picChef.BackColor = System.Drawing.Color.Transparent;
            this.picChef.Image = global::CapaVista_Enlace_Logistica.Properties.Resources._7;
            this.picChef.Location = new System.Drawing.Point(1171, 3);
            this.picChef.Name = "picChef";
            this.picChef.Size = new System.Drawing.Size(275, 333);
            this.picChef.TabIndex = 0;
            this.picChef.TabStop = false;
            this.picChef.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlSeleccionServicio
            // 
            this.pnlSeleccionServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.pnlSeleccionServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeleccionServicio.Controls.Add(this.txtFechaServicio);
            this.pnlSeleccionServicio.Controls.Add(this.lblFechaServicio);
            this.pnlSeleccionServicio.Controls.Add(this.txtNumeroGuia);
            this.pnlSeleccionServicio.Controls.Add(this.lblNumeroGuia);
            this.pnlSeleccionServicio.Controls.Add(this.txtNumeroServicio);
            this.pnlSeleccionServicio.Controls.Add(this.lblNumeroServicio);
            this.pnlSeleccionServicio.Controls.Add(this.cboServicioTransporte);
            this.pnlSeleccionServicio.Controls.Add(this.lblServicioTransporte);
            this.pnlSeleccionServicio.Controls.Add(this.lblTituloSeleccionServicio);
            this.pnlSeleccionServicio.Controls.Add(this.lblNumeroSeccionServicio);
            this.pnlSeleccionServicio.Location = new System.Drawing.Point(44, 123);
            this.pnlSeleccionServicio.Name = "pnlSeleccionServicio";
            this.pnlSeleccionServicio.Size = new System.Drawing.Size(1048, 161);
            this.pnlSeleccionServicio.TabIndex = 3;
            // 
            // lblNumeroSeccionServicio
            // 
            this.lblNumeroSeccionServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblNumeroSeccionServicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroSeccionServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(242)))));
            this.lblNumeroSeccionServicio.Location = new System.Drawing.Point(30, 15);
            this.lblNumeroSeccionServicio.Name = "lblNumeroSeccionServicio";
            this.lblNumeroSeccionServicio.Size = new System.Drawing.Size(35, 35);
            this.lblNumeroSeccionServicio.TabIndex = 0;
            this.lblNumeroSeccionServicio.Text = "1";
            this.lblNumeroSeccionServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloSeleccionServicio
            // 
            this.lblTituloSeleccionServicio.AutoSize = true;
            this.lblTituloSeleccionServicio.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloSeleccionServicio.Font = new System.Drawing.Font("Lucida Bright", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSeleccionServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.lblTituloSeleccionServicio.Location = new System.Drawing.Point(68, 20);
            this.lblTituloSeleccionServicio.Name = "lblTituloSeleccionServicio";
            this.lblTituloSeleccionServicio.Size = new System.Drawing.Size(426, 26);
            this.lblTituloSeleccionServicio.TabIndex = 1;
            this.lblTituloSeleccionServicio.Text = "Selección del servicio de transporte";
            // 
            // lblServicioTransporte
            // 
            this.lblServicioTransporte.AutoSize = true;
            this.lblServicioTransporte.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioTransporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.lblServicioTransporte.Location = new System.Drawing.Point(32, 61);
            this.lblServicioTransporte.Name = "lblServicioTransporte";
            this.lblServicioTransporte.Size = new System.Drawing.Size(215, 21);
            this.lblServicioTransporte.TabIndex = 2;
            this.lblServicioTransporte.Text = "Servicio de transporte *";
            // 
            // cboServicioTransporte
            // 
            this.cboServicioTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicioTransporte.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServicioTransporte.FormattingEnabled = true;
            this.cboServicioTransporte.Location = new System.Drawing.Point(36, 85);
            this.cboServicioTransporte.Name = "cboServicioTransporte";
            this.cboServicioTransporte.Size = new System.Drawing.Size(450, 31);
            this.cboServicioTransporte.TabIndex = 0;
            // 
            // lblNumeroServicio
            // 
            this.lblNumeroServicio.AutoSize = true;
            this.lblNumeroServicio.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.lblNumeroServicio.Location = new System.Drawing.Point(504, 63);
            this.lblNumeroServicio.Name = "lblNumeroServicio";
            this.lblNumeroServicio.Size = new System.Drawing.Size(138, 21);
            this.lblNumeroServicio.TabIndex = 3;
            this.lblNumeroServicio.Text = "No. de Servicio";
            // 
            // txtNumeroServicio
            // 
            this.txtNumeroServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNumeroServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroServicio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroServicio.Location = new System.Drawing.Point(507, 87);
            this.txtNumeroServicio.Name = "txtNumeroServicio";
            this.txtNumeroServicio.ReadOnly = true;
            this.txtNumeroServicio.Size = new System.Drawing.Size(145, 30);
            this.txtNumeroServicio.TabIndex = 4;
            this.txtNumeroServicio.TabStop = false;
            // 
            // lblNumeroGuia
            // 
            this.lblNumeroGuia.AutoSize = true;
            this.lblNumeroGuia.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroGuia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.lblNumeroGuia.Location = new System.Drawing.Point(670, 62);
            this.lblNumeroGuia.Name = "lblNumeroGuia";
            this.lblNumeroGuia.Size = new System.Drawing.Size(109, 21);
            this.lblNumeroGuia.TabIndex = 5;
            this.lblNumeroGuia.Text = "No. de Guía";
            // 
            // txtNumeroGuia
            // 
            this.txtNumeroGuia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtNumeroGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroGuia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroGuia.Location = new System.Drawing.Point(672, 87);
            this.txtNumeroGuia.Name = "txtNumeroGuia";
            this.txtNumeroGuia.Size = new System.Drawing.Size(135, 30);
            this.txtNumeroGuia.TabIndex = 6;
            this.txtNumeroGuia.TabStop = false;
            // 
            // lblFechaServicio
            // 
            this.lblFechaServicio.AutoSize = true;
            this.lblFechaServicio.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(44)))), ((int)(((byte)(18)))));
            this.lblFechaServicio.Location = new System.Drawing.Point(822, 61);
            this.lblFechaServicio.Name = "lblFechaServicio";
            this.lblFechaServicio.Size = new System.Drawing.Size(159, 21);
            this.lblFechaServicio.TabIndex = 7;
            this.lblFechaServicio.Text = "Fecha de Servicio";
            // 
            // txtFechaServicio
            // 
            this.txtFechaServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFechaServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaServicio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaServicio.Location = new System.Drawing.Point(827, 87);
            this.txtFechaServicio.Name = "txtFechaServicio";
            this.txtFechaServicio.Size = new System.Drawing.Size(135, 30);
            this.txtFechaServicio.TabIndex = 8;
            this.txtFechaServicio.TabStop = false;
            // 
            // Frm_Solicitud_Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 912);
            this.Controls.Add(this.pnlFondoSolicitudPago);
            this.MaximizeBox = false;
            this.Name = "Frm_Solicitud_Pago";
            this.Text = "Frm_Solicitud_Pago";
            this.pnlFondoSolicitudPago.ResumeLayout(false);
            this.pnlFondoSolicitudPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChef)).EndInit();
            this.pnlSeleccionServicio.ResumeLayout(false);
            this.pnlSeleccionServicio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondoSolicitudPago;
        private System.Windows.Forms.PictureBox picChef;
        private System.Windows.Forms.Label lblTituloSolicitudPago;
        private System.Windows.Forms.Label lblDescripcionSolicitudPago;
        private System.Windows.Forms.Panel pnlSeleccionServicio;
        private System.Windows.Forms.Label lblNumeroSeccionServicio;
        private System.Windows.Forms.Label lblTituloSeleccionServicio;
        private System.Windows.Forms.ComboBox cboServicioTransporte;
        private System.Windows.Forms.Label lblServicioTransporte;
        private System.Windows.Forms.TextBox txtNumeroGuia;
        private System.Windows.Forms.Label lblNumeroGuia;
        private System.Windows.Forms.TextBox txtNumeroServicio;
        private System.Windows.Forms.Label lblNumeroServicio;
        private System.Windows.Forms.TextBox txtFechaServicio;
        private System.Windows.Forms.Label lblFechaServicio;
    }
}
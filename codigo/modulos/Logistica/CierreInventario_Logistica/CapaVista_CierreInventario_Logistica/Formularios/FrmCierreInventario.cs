/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA
 * FORMULARIO: FrmCierreInventario
 *
 * DESCRIPCIÓN:
 * Formulario que abordad la interfaz para las consultas del cierre de inventario
 *
 * RESPONSABLE: Nills Berducido Gómez
 * CARNÉ: 0901 23 14275
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_CierreInventario_Logistica.Formularios
{
    public partial class FrmCierreInventario : Form
    {
        public FrmCierreInventario()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FrmConsultaCierres frmConsulta = new FrmConsultaCierres();
            frmConsulta.Show();
            this.Hide(); // Oculta FrmCierreInventario
        
    }
    }
}

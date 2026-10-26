using System;
using System.Collections.Generic;
using System.ComponentModel;
// ============================================================================
// MÓDULO: LOGÍSTICA - TRANSPORTE INTERNO
// FORMULARIO: FrmTransporteInterno
// DESCRIPCIÓN:
// Formulario principal del submódulo de Transporte Interno, encargado de
// administrar el acceso a las funcionalidades de gestión de viajes,
// control de transporte y consultas de transporte interno.
//
// Permite navegar entre los diferentes formularios del submódulo,
// facilitando la organización y el seguimiento de las operaciones
// relacionadas con el traslado de productos y materiales.
//
// RESPONSABLE: BRIAN ANDREE DE LA CRUZ SOSA 0901-23-6124
// ============================================================================

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_TransporteInterno_Logistica.Formas
{
    public partial class FrmTransporteInterno : Form
    {
        public FrmTransporteInterno()
        {
            InitializeComponent();
            LogisticaNavTransporteInterno.NavegadorMetConfigurar("tblTransporte", 4, 6);
        }

        private void LogisticaBtnGestionViajes_Click(object sender, EventArgs e)
        {
            FrmGestionViajes frmGestionViajes = new FrmGestionViajes();
            frmGestionViajes.ShowDialog();
        }

        private void LogisticaBtnControlTransporte_Click(object sender, EventArgs e)
        {
            FrmControlTransporte frmControlTransporte = new FrmControlTransporte();
            frmControlTransporte.ShowDialog();
        }

        private void LogisticaBtnConsultasTransporte_Click(object sender, EventArgs e)
        {
            FrmConsultaTransporte frmConsultasTransporte = new FrmConsultaTransporte();
            frmConsultasTransporte.ShowDialog();
        }

        private void FrmTransporteInterno_Load(object sender, EventArgs e)
        {

        }
    }
}

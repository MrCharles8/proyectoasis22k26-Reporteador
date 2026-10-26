// ============================================================================
// MÓDULO: LOGÍSTICA - TRANSPORTE INTERNO
// FORMULARIO: FrmControlTransporte
// DESCRIPCIÓN:
// Formulario encargado del control y seguimiento de las operaciones de
// transporte interno, permitiendo supervisar las condiciones de los
// vehículos y monitorear el desarrollo de los viajes registrados.
//
// Facilita el registro y consulta de información relacionada con las
// condiciones del transporte, el seguimiento de los recorridos y las
// incidencias que puedan presentarse durante su ejecución.
//
// Integra el componente Navegador para administrar los registros
// relacionados con el control del transporte.
//
// RESPONSABLE: BRIAN ANDREE DE LA CRUZ SOSA 0901-23-6124
// ============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_TransporteInterno_Logistica.Formas
{
    public partial class FrmControlTransporte : Form
    {
        public FrmControlTransporte()
        {
            InitializeComponent();

            LogisticaNavTransporteInterno.NavegadorMetConfigurar("tblTelemetriaTemperatura", 4, 6);
        }

        private void txtObservacionesInspeccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogisticaNavTransporteInterno_Load(object sender, EventArgs e)
        {

        }

        private void FrmControlTransporte_Load(object sender, EventArgs e)
        {

        }
    }
}

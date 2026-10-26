// ============================================================================
// MÓDULO: LOGÍSTICA - TRANSPORTE INTERNO
// FORMULARIO: FrmConsultaTransporte
// DESCRIPCIÓN:
// Formulario encargado de consultar y visualizar la información histórica
// de los viajes realizados dentro del submódulo de Transporte Interno.
//
// Permite acceder a los registros de transporte, consultar el estado
// de los viajes y facilitar la generación de reportes relacionados
// con las operaciones de traslado de productos y materiales.
//
// Integra las funcionalidades de consulta y reporte para apoyar
// el seguimiento y la trazabilidad de las operaciones de transporte.
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
    public partial class FrmConsultaTransporte : Form
    {
        public FrmConsultaTransporte()
        {
            InitializeComponent();

            LogisticaNavTransporteInterno.NavegadorMetConfigurar("tblEncabezadoViaje", 4, 6);
        }

    }
}

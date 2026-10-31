
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - TRANSPORTE INTERNO
 * FORMULARIO: FrmTransporteInterno
 *
 * DESCRIPCIÓN:
 * Formulario principal del submódulo de Transporte Interno, encargado de
 * administrar el acceso a las funcionalidades de gestión de viajes,
 * control de transporte y consultas de transporte interno.
 *
 * RESPONSABLE: BRIAN ANDREE DE LA CRUZ SOSA
 * CARNÉ: 0901-23-6124
 * ============================================================================
 */

using System;
using System.Windows.Forms;

namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    public partial class FrmTransporteInterno : Form
    {
        // ============================================
        // CONSTRUCTOR PRINCIPAL
        // ============================================

        public FrmTransporteInterno()
        {
            InitializeComponent();
        }

        // ============================================
        // MÉTODO PARA ABRIR FORMULARIOS
        // ============================================

        private void LogisticaMetAbrirFormulario(Form Formulario)
        {
            using (Formulario)
            {
                Formulario.StartPosition =
                    FormStartPosition.CenterParent;

                Formulario.ShowDialog(this);
            }
        }

        // ============================================
        // CONSULTA DE TRANSPORTE
        // ============================================

        private void LogisticaBtnConsultaTransporte_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmConsultaTransporte());
        }

        // ============================================
        // CONTROL DE TRANSPORTE
        // ============================================

        private void LogisticaBtnControlTransporte_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmControlTransporte());
        }

        // ============================================
        // BOTÓN 3 - TIPO DE TRASLADO
        // ============================================

        private void LogisticaBtnTransporte_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmTipoTraslado());
        }

        // ============================================
        // GESTIÓN DE VIAJES
        // ============================================

        private void LogisticaBtnGestionViajes_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmGestionViajes());
        }
    }
}

// ============================================================================
// MÓDULO: LOGÍSTICA - TRANSPORTE INTERNO
// FORMULARIO: FrmMantenimientoTransporte
// DESCRIPCIÓN:
// Formulario encargado de administrar la información de los vehículos
// utilizados en las operaciones de Transporte Interno.
//
// Permite registrar, consultar, modificar y eliminar los datos de los
// vehículos, incluyendo placas, marcas, modelos, años de fabricación,
// características de refrigeración, tipos y estados operativos.
//
// Integra el componente Navegador para gestionar los registros de la
// tabla tblTransporte y facilitar el control de los vehículos disponibles.
//
// RESPONSABLE: BRIAN ANDREE DE LA CRUZ SOSA 0901-23-6124
// ============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using CapaControlador_TransporteInterno_Logistica.Modelos_de_Controladores;

namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    public partial class FrmMantenimientoTransporte : Form
    {


        private readonly ClsModeloTransporte
    _DatosTransporte =
        new ClsModeloTransporte();

        // =====================================================
        // FUENTE DE DATOS PARA EL REPORTE
        // =====================================================

        private readonly Dictionary<string, object>
            _FuentesReporteTransporte =
                new Dictionary<string, object>();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public FrmMantenimientoTransporte()
        {
            InitializeComponent();

            List<ClsModeloTransporte> ListaTransportes =
                _DatosTransporte.LogisticaMetObtenerTodos();

            _FuentesReporteTransporte.Add(
                "DsReporteTransporte",
                ListaTransportes);

            LogisticaNavTransporteInterno.NavegadorMetConfigurar(
                "tblTransporte",
                5000,
                5013,
                _FuentesReporteTransporte);
        }




    }
}

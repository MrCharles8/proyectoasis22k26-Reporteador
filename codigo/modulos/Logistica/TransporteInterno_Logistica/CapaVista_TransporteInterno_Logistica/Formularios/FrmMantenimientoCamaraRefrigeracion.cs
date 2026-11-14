// ============================================================================
// MÓDULO: LOGÍSTICA - TRANSPORTE INTERNO
// FORMULARIO: FrmMantenimientoCamaraRefrigeracion
// DESCRIPCIÓN:
// Formulario encargado de administrar los equipos de refrigeración
// instalados en los vehículos utilizados para el transporte de productos.
//
// Permite registrar, consultar, modificar y eliminar la información
// relacionada con las cámaras de refrigeración, incluyendo equipos,
// rangos de temperatura y condiciones de funcionamiento.
//
// Integra el componente Navegador para gestionar los registros de la
// tabla tblCamaraRefrigeracion y apoyar el control de la cadena de frío.
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

using CapaControlador_TransporteInterno_Logistica.Modelos_de_Controladores;

namespace CapaVista_TransporteInterno_Logistica.Formularios
{
    public partial class FrmMantenimientoCamaraRefrigeracion : Form
    {

        private readonly ClsModeloCamaraRefrigeracion
    _DatosCamara =
        new ClsModeloCamaraRefrigeracion();

        // =====================================================
        // FUENTE DE DATOS PARA EL REPORTE
        // =====================================================

        private readonly Dictionary<string, object>
            _FuentesReporteCamaraRefrigeracion =
                new Dictionary<string, object>();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public FrmMantenimientoCamaraRefrigeracion()
        {
            InitializeComponent();

            // Obtener los registros de las cámaras.
            List<ClsModeloCamaraRefrigeracion> ListaCamaras =
                _DatosCamara.LogisticaMetObtenerTodos();

            // Asignar registros al DataSet.
            _FuentesReporteCamaraRefrigeracion.Add(
                "DsReporteCamaraRefrigeracion",
                ListaCamaras);

            // Configurar el Navegador.
            LogisticaNavCamarasRefrigeracion.NavegadorMetConfigurar(
                "tblCamaraRefrigeracion",
                5000,
                5028,
                _FuentesReporteCamaraRefrigeracion);
        }

    }
}

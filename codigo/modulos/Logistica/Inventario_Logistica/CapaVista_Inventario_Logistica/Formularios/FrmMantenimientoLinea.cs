
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: FrmMantenimientoLinea.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Formulario de mantenimiento de líneas de productos.
 *
 * Permite gestionar los registros mediante el componente
 * Navegador, incluyendo las operaciones de ingreso,
 * consulta, modificación y eliminación.
 *
 * Integra la consulta de las líneas registradas
 * para proporcionar la información al reporte RDLC
 * RpReporteLinea.rdlc mediante DsReporteLinea.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CapaControlador_Inventario_Logistica;
using CapaControlador_Inventario_Logistica.Modelos_de_Controladores;

namespace CapaVista_Inventario_Logistica.Formularios
{
    public partial class FrmMantenimientoLinea : Form
    {
        // ========================================================
        // MODELO DEL CONTROLADOR
        // ========================================================

        private readonly ClsModeloLinea _DatosLinea =
            new ClsModeloLinea();

        // ========================================================
        // FUENTE DE DATOS PARA EL REPORTE
        // ========================================================

        private readonly Dictionary<string, object>
            _FuentesReporteLinea =
                new Dictionary<string, object>();

        // ========================================================
        // CONSTRUCTOR
        // ========================================================

        public FrmMantenimientoLinea()
        {
            InitializeComponent();

            // ====================================================
            // OBTENER LOS REGISTROS DE LÍNEAS
            // ====================================================

            List<ClsModeloLinea> ListaLineas =
                _DatosLinea.LogisticaMetObtenerTodos();

            // ====================================================
            // ASIGNAR LOS DATOS AL DATASET
            // ====================================================

            _FuentesReporteLinea.Add(
                "DsReporteLinea",
                ListaLineas);

            // ====================================================
            // CONFIGURAR EL NAVEGADOR
            // ====================================================

            LogisticaNavLinea.NavegadorMetConfigurar(
                "tblLinea",
                5000,
                5004,
                _FuentesReporteLinea);
        }
    }
}

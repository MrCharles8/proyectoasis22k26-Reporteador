
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: FrmMantenimientoSucursales.cs
 *
 * REALIZADO POR: VELVETH SARAÍ CHÁVEZ MEJÍA
 * CARNÉ: 0901 23 6269
 *
 * DESCRIPCIÓN:
 * Formulario de mantenimiento de sucursales.
 * Integra el Navegador y la generación de reportes.
 *
 * Incluye una verificación temporal para identificar
 * la ubicación del archivo RDLC.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CapaControlador_Inventario_Logistica;
using CapaControlador_Inventario_Logistica.Modelos_de_Controladores;

namespace CapaVista_Inventario_Logistica.Formularios
{
    public partial class FrmMantenimientoSucursales : Form
    {
        private readonly ClsModeloSucursal _DatosSucursal =
            new ClsModeloSucursal();

        private readonly Dictionary<string, object> _FuentesReporteSucursal =
            new Dictionary<string, object>();

        public FrmMantenimientoSucursales()
        {
            InitializeComponent();

            // =====================================================
            // OBTENER LOS REGISTROS DE SUCURSALES
            // =====================================================

            List<ClsModeloSucursal> ListaSucursales =
                _DatosSucursal.LogisticaMetObtenerTodosInforme();

            // =====================================================
            // ENTREGAR DATOS AL NAVEGADOR
            // =====================================================

            _FuentesReporteSucursal.Add(
                "DsReporteSucursal",
                ListaSucursales
            );

            // =====================================================
            // CONFIGURAR NAVEGADOR
            // =====================================================

            LogisticaNavSucursales.NavegadorMetConfigurar(
                "tblSucursal",
                5000,
                5001,
                _FuentesReporteSucursal
            );
        }
    }
}

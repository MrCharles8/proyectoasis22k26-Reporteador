
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: FrmMantenimientoCategoria.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 26/10/2026
 *
 * DESCRIPCIÓN:
 * Formulario de mantenimiento de categorías de productos.
 * Permite ingresar, guardar, modificar, eliminar y consultar
 * categorías mediante el componente Navegador.
 *
 * Integra la consulta de categorías desde el controlador
 * para proporcionar la información al reporte RDLC
 * RpReporteCategoria.rdlc mediante DsReporteCategoria.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CapaControlador_Inventario_Logistica;
using CapaControlador_Inventario_Logistica.Modelos_de_Controladores;

namespace CapaVista_Inventario_Logistica.Formularios
{
    public partial class FrmMantenimientoCategoria : Form
    {
        // ========================================================
        // MODELO DEL CONTROLADOR
        // ========================================================

        private readonly ClsModeloCategoria _DatosCategoria =
            new ClsModeloCategoria();

        // ========================================================
        // FUENTE DE DATOS DEL REPORTE
        // ========================================================

        private readonly Dictionary<string, object>
            _FuentesReporteCategoria =
                new Dictionary<string, object>();

        // ========================================================
        // CONSTRUCTOR DEL FORMULARIO
        // ========================================================

        public FrmMantenimientoCategoria()
        {
            InitializeComponent();

            // ====================================================
            // OBTENER LOS REGISTROS DE CATEGORÍAS
            // ====================================================

            List<ClsDatosCategoria> ListaCategorias =
                _DatosCategoria.LogisticaFuncObtenerTodos();

            // ====================================================
            // ASIGNAR LOS DATOS AL DATASET DEL REPORTE
            // ====================================================

            _FuentesReporteCategoria.Add(
                "DsReporteCategoria",
                ListaCategorias);

            // ====================================================
            // CONFIGURAR EL NAVEGADOR
            // ====================================================

            LogisticaNavCategoria.NavegadorMetConfigurar(
                "tblCategoria",
                4,
                6,
                _FuentesReporteCategoria);
        }
    }
}

/*
 * ==================================================================
 * Área : Contabilidad
 * Autor : Gabriel André Guillén Pocón
 * Carné : 0901-23-1998
 * Fecha : 14/11/2026
 * ==================================================================
 * Propósito :
 *  Reporte del cierre contable: estado del período, resumen y
 *  pólizas del mes en un ReportViewer.
 * ===================================================================
*/

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CapaControlador_Contabilidad;
using CapaVista_Contabilidad.Componentes;

namespace CapaVista_Contabilidad
{
    // ventana del reporte de cierre
    public partial class FrmReporteCierreContable : Form
    {
        // nombre del RDLC embebido
        public const string RecursoReporte = "CapaVista_Contabilidad.Reportes.RpReporteCierreContable.rdlc";

        // permisos de la pantalla
        private readonly ClsModeloPermisosPantallaContabilidad _Permisos;
        // reglas del cierre
        private readonly ClsControladorCierreContabilidad _Controlador = new ClsControladorCierreContabilidad();
        // pólizas mostradas
        private DataTable _Polizas;

        // abre con todos los permisos
        public FrmReporteCierreContable() : this(ClsModeloPermisosPantallaContabilidad.Total)
        {
        }

        // abre con los permisos del MDI
        public FrmReporteCierreContable(ClsModeloPermisosPantallaContabilidad Permisos)
        {
            _Permisos = Permisos ?? ClsModeloPermisosPantallaContabilidad.Ninguno;
            InitializeComponent();
            ClsPresentacionContabilidad.ContabilidadMetPrepararVentana(this, "Reporte de cierre contable", new Size(1180, 768));
            ContabilidadRpvReporte.ShowPrintButton = _Permisos.PuedeImprimir;
            ContabilidadRpvReporte.ShowExportButton = _Permisos.PuedeImprimir;
            ContabilidadRpvReporte.ShowBackButton = false;
            ContabilidadRpvReporte.ShowRefreshButton = false;
            ContabilidadRpvReporte.ShowStopButton = false;
            ContabilidadDtpPeriodo.Value = DateTime.Today;
            ContabilidadTtpBotones.SetToolTip(ContabilidadBtnGenerar, "Generar reporte");
            ContabilidadBtnGenerar.Click += (Remitente, Argumentos) => ContabilidadMetGenerar();
            Load += (Remitente, Argumentos) => ContabilidadMetGenerar();
            Disposed += (Remitente, Argumentos) => _Polizas?.Dispose();
        }

        // carga el RDLC con sus datos
        public static void ContabilidadMetPrepararReporte(LocalReport Reporte, DataTable Polizas, ReportParameter[] Parametros)
        {
            using (Stream Definicion = typeof(FrmReporteCierreContable).Assembly.GetManifestResourceStream(RecursoReporte))
                Reporte.LoadReportDefinition(Definicion);
            Reporte.DataSources.Clear();
            Reporte.DataSources.Add(new ReportDataSource("DsPolizasCierre", Polizas));
            Reporte.SetParameters(Parametros);
        }

        // arma los parámetros del encabezado
        public static ReportParameter[] ContabilidadFuncParametros(DateTime Periodo, string Estado, string Diagnostico, ClsModeloResumenCierreContabilidad Resumen)
        {
            return new[]
            {
                new ReportParameter("Periodo", Periodo.ToString("MM/yyyy")),
                new ReportParameter("EstadoPeriodo", string.IsNullOrEmpty(Estado) ? "SIN SALDOS" : Estado),
                new ReportParameter("Diagnostico", string.IsNullOrEmpty(Diagnostico) ? "El período cumple las condiciones para cerrarse." : Diagnostico),
                new ReportParameter("Aplicadas", Resumen.Aplicadas.ToString()),
                new ReportParameter("Borradores", Resumen.Borradores.ToString()),
                new ReportParameter("TotalDebe", Resumen.Debe.ToString("N2")),
                new ReportParameter("TotalHaber", Resumen.Haber.ToString("N2"))
            };
        }

        // pide los datos y muestra el reporte
        private void ContabilidadMetGenerar()
        {
            DateTime Periodo = new DateTime(ContabilidadDtpPeriodo.Value.Year, ContabilidadDtpPeriodo.Value.Month, 1);
            Cursor = Cursors.WaitCursor;
            try
            {
                DataTable Polizas = _Controlador.ContabilidadFuncPolizas(Periodo);
                ReportParameter[] Parametros = ContabilidadFuncParametros(Periodo, _Controlador.ContabilidadFuncEstadoPeriodo(Periodo),
                    _Controlador.ContabilidadFuncValidarCierre(Polizas), _Controlador.ContabilidadFuncResumenCierre(Polizas));
                ContabilidadMetPrepararReporte(ContabilidadRpvReporte.LocalReport, Polizas, Parametros);
                _Polizas?.Dispose();
                _Polizas = Polizas;
                ContabilidadRpvReporte.SetDisplayMode(DisplayMode.PrintLayout);
                ContabilidadRpvReporte.ZoomMode = ZoomMode.PageWidth;
                ContabilidadRpvReporte.RefreshReport();
                ContabilidadLblResultado.Text = Polizas.Rows.Count + " póliza(s) en " + Periodo.ToString("MM/yyyy");
            }
            catch (Exception Excepcion)
            {
                ClsDialogosContabilidad.ContabilidadMetError(this, "No se pudo generar el reporte: " + Excepcion.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}

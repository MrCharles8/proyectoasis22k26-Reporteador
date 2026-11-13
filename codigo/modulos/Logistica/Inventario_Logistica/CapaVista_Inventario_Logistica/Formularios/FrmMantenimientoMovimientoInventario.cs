
/*
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: FrmMantenimientoMovimientoInventario.cs
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Administra encabezados de movimientos de inventario
 * pendientes mediante MVC. Incluye consultas, edición,
 * eliminación, navegación, catálogos e impresión RDLC.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CapaControlador_Inventario_Logistica.Modelos_de_Controladores;

namespace CapaVista_Inventario_Logistica.Formularios
{
    public partial class FrmMantenimientoMovimientoInventario : Form
    {
        private readonly ClsModeloMovimientoInventario _Modelo =
            new ClsModeloMovimientoInventario();

        private List<ClsModeloMovimientoInventario> _Registros =
            new List<ClsModeloMovimientoInventario>();

        private int _Indice = -1;
        private bool _Cargando;

        private enum Modo
        {
            Consulta,
            Ingresar,
            Modificar
        }

        private Modo _Modo = Modo.Consulta;

        // ========================================================
        // CONSTRUCTOR
        // ========================================================

        public FrmMantenimientoMovimientoInventario()
        {
            InitializeComponent();
            LogisticaProcConfigurarTabla();
            LogisticaProcVincularEventos();

            Load += FrmMantenimientoMovimientoInventario_Load;
        }

        // ========================================================
        // EVENTOS DE LOS BOTONES Y CONTROLES
        // ========================================================

        private void LogisticaProcVincularEventos()
        {
            LogisticaBtnIngresarMovimientoInventario.Click += (s, e) =>
            {
                LogisticaProcLimpiar();
                LogisticaProcCambiarModo(Modo.Ingresar);
            };

            LogisticaBtnConsultarMovimientoInventario.Click +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    LogisticaProcCambiarModo(Modo.Consulta);
                    LogisticaProcConsultar();
                });

            LogisticaBtnModificarMovimientoInventario.Click +=
                (s, e) => LogisticaProcModificar();

            LogisticaBtnGuardarMovimientoInventario.Click +=
                (s, e) => LogisticaProcGuardar();

            LogistiaBtnEliminarMovimientoInventario.Click +=
                (s, e) => LogisticaProcEliminar();

            LogisticaBtnCancelarMovimientoInventario.Click +=
                (s, e) => LogisticaProcCancelar();

            LogisticaBtnRefrescarMovimientoInventario.Click +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    LogisticaProcCargarCatalogos();
                    LogisticaProcCambiarModo(Modo.Consulta);
                    LogisticaProcConsultar();
                });

            LogisticaBtnImprimirMovimientoInventario.Click +=
                (s, e) => LogisticaProcEjecutar(
                    LogisticaProcImprimir);

            LogisticaBtnAyudaMovimientoInventario.Click +=
                (s, e) => MessageBox.Show(
                    "Ingrese un movimiento y seleccione el tipo " +
                    "y la bodega correspondiente.\n\n" +
                    "Guardar crea un encabezado PENDIENTE; " +
                    "no modifica existencias.\n\n" +
                    "Solo pueden modificarse o eliminarse " +
                    "movimientos pendientes sin detalles.",
                    "Ayuda - Movimientos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            LogisticaBtnInicioMovimientoInventario.Click +=
                (s, e) => LogisticaProcSeleccionar(0);

            LogisticaBtnAnteriorMovimientoInventario.Click +=
                (s, e) => LogisticaProcSeleccionar(_Indice - 1);

            LogisticaBtnSiguienteStock.Click +=
                (s, e) => LogisticaProcSeleccionar(_Indice + 1);

            LogisticaBtnFinMovimientoInventario.Click +=
                (s, e) => LogisticaProcSeleccionar(
                    _Registros.Count - 1);

            LogisticaBtnSalirMovimientoInventario.Click +=
                (s, e) => Close();

            LogisticaCboIdSucursalOrigen.SelectedIndexChanged +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    if (!_Cargando)
                    {
                        LogisticaProcCargarBodegas(
                            LogisticaCboBodegaOrigen,
                            LogisticaFuncId(
                                LogisticaCboIdSucursalOrigen));
                    }
                });

            LogisticaCboIdSucursalDestino.SelectedIndexChanged +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    if (!_Cargando)
                    {
                        LogisticaProcCargarBodegas(
                            LogisticaCboBodegaDestino,
                            LogisticaFuncId(
                                LogisticaCboIdSucursalDestino));
                    }
                });

            LogisticaCboIdMovimiento.SelectedIndexChanged +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    if (!_Cargando && _Modo != Modo.Consulta)
                    {
                        LogisticaProcAplicarTipo(true);
                    }
                });

            LogisticaDgvListadoMovimientoInventario.CellClick +=
                (s, e) =>
                {
                    if (e.RowIndex >= 0 &&
                        _Modo == Modo.Consulta)
                    {
                        LogisticaProcSeleccionar(e.RowIndex);
                    }
                };
        }

        // ========================================================
        // CARGA INICIAL
        // ========================================================

        private void FrmMantenimientoMovimientoInventario_Load(
            object Sender,
            EventArgs E)
        {
            LogisticaProcEjecutar(() =>
            {
                LogisticaProcCargarCatalogos();
                LogisticaProcCambiarModo(Modo.Consulta);
                LogisticaProcConsultar();
            });
        }

        // ========================================================
        // CONFIGURAR DATAGRIDVIEW
        // ========================================================

        private void LogisticaProcConfigurarTabla()
        {
            DataGridView Tabla =
                LogisticaDgvListadoMovimientoInventario;

            Tabla.AutoGenerateColumns = false;
            Tabla.Columns.Clear();
            Tabla.ReadOnly = true;
            Tabla.AllowUserToAddRows = false;
            Tabla.MultiSelect = false;
            Tabla.RowHeadersVisible = false;

            Tabla.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            Tabla.EnableHeadersVisualStyles = false;

            Tabla.BackgroundColor =
                Color.FromArgb(251, 246, 242);

            Tabla.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(106, 44, 18);

            Tabla.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            Tabla.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 99, 46);

            Tabla.DefaultCellStyle.SelectionForeColor =
                Color.White;

            string[,] Columnas =
            {
                { "IdMovimientoInventario", "ID" },
                { "NombreTipoMovimiento", "Tipo" },
                { "SignoTipoMovimiento", "Signo" },
                { "NombreSucursalOrigen", "Sucursal origen" },
                { "NombreBodegaOrigen", "Bodega origen" },
                { "NombreSucursalDestino", "Sucursal destino" },
                { "NombreBodegaDestino", "Bodega destino" },
                { "NombreTransporte", "Transporte" },
                { "FechaMovimientoInventario", "Fecha" },
                { "EstadoMovimientoInventario", "Estado" },
                { "ObservacionesMovimientoInventario", "Observaciones" }
            };

            for (int I = 0; I < Columnas.GetLength(0); I++)
            {
                DataGridViewTextBoxColumn Columna =
                    new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = Columnas[I, 0],
                        HeaderText = Columnas[I, 1],
                        Width = I == 10 ? 200 : 135,
                        SortMode =
                            DataGridViewColumnSortMode.NotSortable
                    };

                if (Columnas[I, 0] ==
                    "FechaMovimientoInventario")
                {
                    Columna.DefaultCellStyle.Format =
                        "dd/MM/yyyy HH:mm";
                }

                Tabla.Columns.Add(Columna);
            }
        }

        // ========================================================
        // CARGAR COMBOBOX
        // ========================================================

        private void LogisticaProcCargarCombo(
            ComboBox Combo,
            List<ClsOpcionCatalogo> Datos)
        {
            bool Anterior = _Cargando;
            _Cargando = true;

            try
            {
                Combo.DataSource = null;
                Combo.DisplayMember = "Nombre";
                Combo.ValueMember = "Id";
                Combo.DataSource = Datos;
                Combo.SelectedIndex = -1;
            }
            finally
            {
                _Cargando = Anterior;
            }
        }

        private void LogisticaProcCargarCatalogos()
        {
            LogisticaProcCargarCombo(
                LogisticaCboIdMovimiento,
                _Modelo.LogisticaFuncTipos());

            LogisticaProcCargarCombo(
                LogisticaCboTransporte,
                _Modelo.LogisticaFuncTransportes());

            LogisticaProcCargarCombo(
                LogisticaCboIdSucursalOrigen,
                _Modelo.LogisticaFuncSucursales());

            LogisticaProcCargarCombo(
                LogisticaCboIdSucursalDestino,
                _Modelo.LogisticaFuncSucursales());

            LogisticaProcCargarBodegas(
                LogisticaCboBodegaOrigen, null);

            LogisticaProcCargarBodegas(
                LogisticaCboBodegaDestino, null);
        }

        private void LogisticaProcCargarBodegas(
            ComboBox Combo,
            int? Sucursal,
            int? Bodega = null)
        {
            LogisticaProcCargarCombo(
                Combo,
                Sucursal.HasValue
                    ? _Modelo.LogisticaFuncBodegas(
                        Sucursal.Value)
                    : new List<ClsOpcionCatalogo>());

            if (Bodega.HasValue)
            {
                Combo.SelectedValue = Bodega.Value;
            }
        }

        private static int? LogisticaFuncId(ComboBox Combo)
        {
            int Id;

            return Combo.SelectedValue != null &&
                int.TryParse(
                    Convert.ToString(Combo.SelectedValue),
                    out Id) &&
                Id > 0
                    ? (int?)Id
                    : null;
        }

        // ========================================================
        // APLICAR TIPO DE MOVIMIENTO
        // ========================================================

        private void LogisticaProcAplicarTipo(bool Limpiar)
        {
            int? Id =
                LogisticaFuncId(LogisticaCboIdMovimiento);

            Tuple<string, string> Tipo = Id.HasValue
                ? _Modelo.LogisticaFuncObtenerTipo(Id.Value)
                : null;

            bool Traslado = Tipo != null &&
                Tipo.Item1.IndexOf(
                    "TRASLADO",
                    StringComparison.OrdinalIgnoreCase) >= 0;

            bool Origen = Tipo == null ||
                Traslado || Tipo.Item2 == "-";

            bool Destino = Tipo == null ||
                Traslado || Tipo.Item2 == "+";

            LogisticaCboIdSucursalOrigen.Enabled = Origen;
            LogisticaCboBodegaOrigen.Enabled = Origen;

            LogisticaCboIdSucursalDestino.Enabled = Destino;
            LogisticaCboBodegaDestino.Enabled = Destino;

            if (!Limpiar)
            {
                return;
            }

            bool Anterior = _Cargando;
            _Cargando = true;

            try
            {
                if (!Origen)
                {
                    LogisticaCboIdSucursalOrigen.SelectedIndex = -1;

                    LogisticaProcCargarBodegas(
                        LogisticaCboBodegaOrigen, null);
                }

                if (!Destino)
                {
                    LogisticaCboIdSucursalDestino.SelectedIndex = -1;

                    LogisticaProcCargarBodegas(
                        LogisticaCboBodegaDestino, null);
                }
            }
            finally
            {
                _Cargando = Anterior;
            }
        }

        // ========================================================
        // CONSULTAR Y SELECCIONAR REGISTROS
        // ========================================================

        private void LogisticaProcConsultar()
        {
            _Registros = _Modelo.LogisticaMetObtenerTodos();
            _Indice = -1;

            LogisticaDgvListadoMovimientoInventario.DataSource =
                null;

            LogisticaDgvListadoMovimientoInventario.DataSource =
                _Registros;

            if (_Registros.Count > 0)
            {
                LogisticaProcSeleccionar(0);
            }
            else
            {
                LogisticaProcLimpiar();
            }
        }

        private void LogisticaProcSeleccionar(int Indice)
        {
            if (_Modo != Modo.Consulta ||
                Indice < 0 ||
                Indice >= _Registros.Count)
            {
                return;
            }

            _Indice = Indice;

            DataGridView Tabla =
                LogisticaDgvListadoMovimientoInventario;

            Tabla.ClearSelection();

            if (Indice < Tabla.Rows.Count)
            {
                Tabla.Rows[Indice].Selected = true;
            }

            LogisticaProcMostrar(_Registros[Indice]);
        }

        private void LogisticaProcMostrar(
            ClsModeloMovimientoInventario D)
        {
            _Cargando = true;

            try
            {
                LogisticaCboIdMovimiento.SelectedValue =
                    D.FkTipoMovimientoCodigo;

                LogisticaCboTransporte.SelectedIndex = -1;

                if (D.FkTransporteCodigo.HasValue)
                {
                    LogisticaCboTransporte.SelectedValue =
                        D.FkTransporteCodigo.Value;
                }

                LogisticaCboIdSucursalOrigen.SelectedIndex = -1;

                if (D.FkSucursalOrigenCodigo.HasValue)
                {
                    LogisticaCboIdSucursalOrigen.SelectedValue =
                        D.FkSucursalOrigenCodigo.Value;
                }

                LogisticaProcCargarBodegas(
                    LogisticaCboBodegaOrigen,
                    D.FkSucursalOrigenCodigo,
                    D.FkBodegaOrigenCodigo);

                LogisticaCboIdSucursalDestino.SelectedIndex = -1;

                if (D.FkSucursalDestinoCodigo.HasValue)
                {
                    LogisticaCboIdSucursalDestino.SelectedValue =
                        D.FkSucursalDestinoCodigo.Value;
                }

                LogisticaProcCargarBodegas(
                    LogisticaCboBodegaDestino,
                    D.FkSucursalDestinoCodigo,
                    D.FkBodegaDestinoCodigo);

                LogisticaDtpFechaMovimiento.Value =
                    D.FechaMovimientoInventario;

                LogisticaTxtObservacionMovimientoInventario.Text =
                    D.ObservacionesMovimientoInventario;
            }
            finally
            {
                _Cargando = false;
            }
        }

        // ========================================================
        // LIMPIAR CAMPOS
        // ========================================================

        private void LogisticaProcLimpiar()
        {
            _Cargando = true;

            try
            {
                LogisticaCboIdMovimiento.SelectedIndex = -1;
                LogisticaCboTransporte.SelectedIndex = -1;

                LogisticaCboIdSucursalOrigen.SelectedIndex = -1;
                LogisticaCboIdSucursalDestino.SelectedIndex = -1;

                LogisticaProcCargarBodegas(
                    LogisticaCboBodegaOrigen, null);

                LogisticaProcCargarBodegas(
                    LogisticaCboBodegaDestino, null);

                LogisticaDtpFechaMovimiento.Value =
                    DateTime.Now;

                LogisticaTxtObservacionMovimientoInventario.Clear();
            }
            finally
            {
                _Cargando = false;
            }
        }

        // ========================================================
        // CAMBIAR MODO DEL FORMULARIO
        // ========================================================

        private void LogisticaProcCambiarModo(Modo Nuevo)
        {
            _Modo = Nuevo;

            bool Editar = Nuevo != Modo.Consulta;

            LogistinaPnlDatosMovimiento.Enabled = Editar;

            LogisticaBtnGuardarMovimientoInventario.Enabled = Editar;
            LogisticaBtnCancelarMovimientoInventario.Enabled = Editar;

            LogisticaBtnIngresarMovimientoInventario.Enabled = !Editar;
            LogisticaBtnConsultarMovimientoInventario.Enabled = !Editar;
            LogisticaBtnModificarMovimientoInventario.Enabled = !Editar;
            LogistiaBtnEliminarMovimientoInventario.Enabled = !Editar;
            LogisticaBtnRefrescarMovimientoInventario.Enabled = !Editar;

            LogisticaDgvListadoMovimientoInventario.Enabled = !Editar;
            LogisticaBtnInicioMovimientoInventario.Enabled = !Editar;
            LogisticaBtnAnteriorMovimientoInventario.Enabled = !Editar;
            LogisticaBtnSiguienteStock.Enabled = !Editar;
            LogisticaBtnFinMovimientoInventario.Enabled = !Editar;

            if (Editar)
            {
                LogisticaProcAplicarTipo(false);
            }
        }

        // ========================================================
        // LEER LOS DATOS DEL FORMULARIO
        // ========================================================

        private ClsModeloMovimientoInventario
            LogisticaFuncLeerFormulario()
        {
            int? Tipo =
                LogisticaFuncId(LogisticaCboIdMovimiento);

            if (!Tipo.HasValue)
            {
                throw new InvalidOperationException(
                    "Seleccione el tipo de movimiento.");
            }

            return new ClsModeloMovimientoInventario
            {
                IdMovimientoInventario =
                    _Modo == Modo.Modificar && _Indice >= 0
                        ? _Registros[_Indice].IdMovimientoInventario
                        : 0,

                FkTipoMovimientoCodigo = Tipo.Value,

                FkSucursalOrigenCodigo =
                    LogisticaFuncId(
                        LogisticaCboIdSucursalOrigen),

                FkBodegaOrigenCodigo =
                    LogisticaFuncId(
                        LogisticaCboBodegaOrigen),

                FkSucursalDestinoCodigo =
                    LogisticaFuncId(
                        LogisticaCboIdSucursalDestino),

                FkBodegaDestinoCodigo =
                    LogisticaFuncId(
                        LogisticaCboBodegaDestino),

                FkTransporteCodigo =
                    LogisticaFuncId(
                        LogisticaCboTransporte),

                FechaMovimientoInventario =
                    LogisticaDtpFechaMovimiento.Value,

                ObservacionesMovimientoInventario =
                    LogisticaTxtObservacionMovimientoInventario
                        .Text.Trim(),

                EstadoMovimientoInventario = "PENDIENTE"
            };
        }

        // ========================================================
        // MODIFICAR
        // ========================================================

        private void LogisticaProcModificar()
        {
            if (_Indice < 0 || _Modo != Modo.Consulta)
            {
                LogisticaProcError(
                    "Seleccione un movimiento del listado.");
                return;
            }

            if (!string.Equals(
                _Registros[_Indice].EstadoMovimientoInventario,
                "PENDIENTE",
                StringComparison.OrdinalIgnoreCase))
            {
                LogisticaProcError(
                    "Solo puede modificar movimientos pendientes.");
                return;
            }

            LogisticaProcEjecutar(() =>
            {
                LogisticaProcCambiarModo(Modo.Modificar);
                LogisticaProcMostrar(_Registros[_Indice]);
                LogisticaProcAplicarTipo(false);
            });
        }

        // ========================================================
        // GUARDAR
        // ========================================================

        private void LogisticaProcGuardar()
        {
            if (_Modo == Modo.Consulta)
            {
                return;
            }

            LogisticaProcEjecutar(() =>
            {
                ClsModeloMovimientoInventario D =
                    LogisticaFuncLeerFormulario();

                string Mensaje = _Modo == Modo.Ingresar
                    ? _Modelo.LogisticaFuncAgregar(D)
                    : _Modelo.LogisticaFuncEditar(D);

                MessageBox.Show(
                    Mensaje,
                    "Logística",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaProcCambiarModo(Modo.Consulta);
                LogisticaProcConsultar();
            });
        }

        // ========================================================
        // ELIMINAR
        // ========================================================

        private void LogisticaProcEliminar()
        {
            if (_Indice < 0 || _Modo != Modo.Consulta)
            {
                LogisticaProcError(
                    "Seleccione un movimiento del listado.");
                return;
            }

            int Id =
                _Registros[_Indice].IdMovimientoInventario;

            if (MessageBox.Show(
                "¿Eliminar el movimiento " + Id + "?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            LogisticaProcEjecutar(() =>
            {
                MessageBox.Show(
                    _Modelo.LogisticaFuncEliminar(Id),
                    "Logística");

                LogisticaProcConsultar();
            });
        }

        // ========================================================
        // CANCELAR
        // ========================================================

        private void LogisticaProcCancelar()
        {
            LogisticaProcCambiarModo(Modo.Consulta);

            if (_Indice >= 0)
            {
                LogisticaProcSeleccionar(_Indice);
            }
            else
            {
                LogisticaProcLimpiar();
            }
        }

        // ========================================================
        // IMPRIMIR REPORTE RDLC
        // ========================================================

        private void LogisticaProcImprimir()
        {
            List<ClsModeloMovimientoInventario> Datos =
                _Modelo.LogisticaMetObtenerTodos();

            if (Datos.Count == 0)
            {
                MessageBox.Show(
                    "No hay movimientos para imprimir.");
                return;
            }

            System.Reflection.Assembly Ensamblado =
                GetType().Assembly;

            string Recurso = Array.Find(
                Ensamblado.GetManifestResourceNames(),
                N => N.EndsWith(
                    ".RpReporteMovimientoInventario.rdlc",
                    StringComparison.OrdinalIgnoreCase));

            if (Recurso == null)
            {
                throw new InvalidOperationException(
                    "RpReporteMovimientoInventario.rdlc " +
                    "debe tener Acción de compilación: " +
                    "Recurso incrustado.");
            }

            using (Form Ventana = new Form())
            using (ReportViewer Visor = new ReportViewer())
            {
                Ventana.Text =
                    "Reporte de Movimiento de Inventario";

                Ventana.StartPosition =
                    FormStartPosition.CenterParent;

                Ventana.WindowState =
                    FormWindowState.Maximized;

                Visor.Dock = DockStyle.Fill;

                Visor.ProcessingMode =
                    ProcessingMode.Local;

                Ventana.Controls.Add(Visor);

                using (Stream Archivo =
                    Ensamblado.GetManifestResourceStream(
                        Recurso))
                {
                    Visor.LocalReport.LoadReportDefinition(
                        Archivo);
                }

                Visor.LocalReport.DataSources.Clear();

                Visor.LocalReport.DataSources.Add(
                    new ReportDataSource(
                        "DsReporteMovimientoInventario",
                        Datos));

                Visor.RefreshReport();
                Ventana.ShowDialog(this);
            }
        }

        // ========================================================
        // MANEJO DE ERRORES
        // ========================================================

        private void LogisticaProcEjecutar(Action Accion)
        {
            try
            {
                Accion();
            }
            catch (Exception Ex)
            {
                LogisticaProcError(Ex.Message);
            }
        }

        private void LogisticaProcError(string Mensaje)
        {
            MessageBox.Show(
                Mensaje,
                "Logística - Movimiento de Inventario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}

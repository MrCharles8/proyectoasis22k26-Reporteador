
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: FrmMantenimientoMovimientoInventario.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Formulario de mantenimiento de movimientos de inventario.
 * Permite ingresar, consultar, modificar y eliminar encabezados,
 * navegar entre registros y generar reportes RDLC.
 *
 * Las sucursales y bodegas de origen y destino pueden
 * seleccionarse según las necesidades del movimiento.
 * ============================================================================
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
        // VINCULAR EVENTOS
        // ========================================================

        private void LogisticaProcVincularEventos()
        {
            LogisticaBtnIngresarMovimientoInventario.Click += (s, e) =>
            {
                LogisticaProcLimpiar();
                LogisticaProcCambiarModo(Modo.Ingresar);
                LogisticaCboIdMovimiento.Focus();
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
                    "1. Ingresar: crea un movimiento pendiente.\n" +
                    "2. Consultar: muestra los registros.\n" +
                    "3. Modificar: edita un movimiento pendiente.\n" +
                    "4. Guardar: registra los datos.\n" +
                    "5. Eliminar: elimina pendientes sin detalles.\n" +
                    "6. Cancelar: descarta los cambios.\n" +
                    "7. Imprimir: genera el reporte RDLC.\n\n" +
                    "Las sucursales y bodegas deben seleccionarse " +
                    "en pares. Este formulario no actualiza stock.",
                    "Ayuda - Movimiento de Inventario",
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

            // Cargar bodegas según la sucursal seleccionada.
            LogisticaCboIdSucursalOrigen.SelectedIndexChanged +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    if (!_Cargando)
                        LogisticaProcCargarBodegas(
                            LogisticaCboBodegaOrigen,
                            LogisticaFuncId(
                                LogisticaCboIdSucursalOrigen));
                });

            LogisticaCboIdSucursalDestino.SelectedIndexChanged +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    if (!_Cargando)
                        LogisticaProcCargarBodegas(
                            LogisticaCboBodegaDestino,
                            LogisticaFuncId(
                                LogisticaCboIdSucursalDestino));
                });

            LogisticaCboIdMovimiento.SelectedIndexChanged +=
                (s, e) => LogisticaProcEjecutar(() =>
                {
                    if (!_Cargando && _Modo != Modo.Consulta)
                        LogisticaProcAplicarTipo();
                });

            LogisticaDgvListadoMovimientoInventario.CellClick +=
                (s, e) =>
                {
                    if (e.RowIndex >= 0 && _Modo == Modo.Consulta)
                        LogisticaProcSeleccionar(e.RowIndex);
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
            Tabla.AllowUserToDeleteRows = false;
            Tabla.MultiSelect = false;
            Tabla.RowHeadersVisible = false;

            Tabla.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            Tabla.ScrollBars = ScrollBars.Both;
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
                { "NombreTipoMovimiento", "Tipo de movimiento" },
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
                        Width = I == 10 ? 220 : 145,
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
                Combo.DropDownStyle = ComboBoxStyle.DropDownList;
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

        // ========================================================
        // CARGAR BODEGAS POR SUCURSAL
        // ========================================================

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
                Combo.SelectedValue = Bodega.Value;
        }

        private static int? LogisticaFuncId(ComboBox Combo)
        {
            int Id;

            if (Combo.SelectedValue != null &&
                int.TryParse(
                    Convert.ToString(Combo.SelectedValue),
                    out Id) && Id > 0)
            {
                return Id;
            }

            return null;
        }

        // ========================================================
        // HABILITAR ORIGEN Y DESTINO
        // ========================================================

        private void LogisticaProcAplicarTipo()
        {
            // El tipo define cuáles campos son obligatorios,
            // pero no bloquea las ubicaciones opcionales.

            bool Editando = _Modo != Modo.Consulta;

            LogisticaCboIdSucursalOrigen.Enabled = Editando;
            LogisticaCboBodegaOrigen.Enabled = Editando;

            LogisticaCboIdSucursalDestino.Enabled = Editando;
            LogisticaCboBodegaDestino.Enabled = Editando;

            int? Id = LogisticaFuncId(LogisticaCboIdMovimiento);

            Tuple<string, string> Tipo = Id.HasValue
                ? _Modelo.LogisticaFuncObtenerTipo(Id.Value)
                : null;

            bool Traslado = Tipo != null &&
                Tipo.Item1.IndexOf(
                    "Traslado",
                    StringComparison.OrdinalIgnoreCase) >= 0;

            bool OrigenObligatorio = Tipo != null &&
                (Traslado || Tipo.Item2 == "-");

            bool DestinoObligatorio = Tipo != null &&
                (Traslado || Tipo.Item2 == "+");

            LogisticaLblSucursalOrigen.Text =
                "Sucursal origen:" +
                (OrigenObligatorio ? " *" : "");

            LogisticaLblBodegaorigen.Text =
                "Bodega origen:" +
                (OrigenObligatorio ? " *" : "");

            LogisticaLblSucursalDestino.Text =
                "Sucursal destino:" +
                (DestinoObligatorio ? " *" : "");

            LogisticaLblBodegaDestino.Text =
                "Bodega destino:" +
                (DestinoObligatorio ? " *" : "");

            LogisticaLblTransporte.Text = "Transporte:";
        }

        // ========================================================
        // CONSULTAR REGISTROS
        // ========================================================

        private void LogisticaProcConsultar()
        {
            _Registros = _Modelo.LogisticaMetObtenerTodos();
            _Indice = -1;

            LogisticaDgvListadoMovimientoInventario.DataSource = null;
            LogisticaDgvListadoMovimientoInventario.DataSource =
                _Registros;

            if (_Registros.Count > 0)
                LogisticaProcSeleccionar(0);
            else
                LogisticaProcLimpiar();
        }

        // ========================================================
        // SELECCIONAR REGISTRO
        // ========================================================

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

                if (Tabla.Rows[Indice].Visible)
                {
                    Tabla.FirstDisplayedScrollingRowIndex = Indice;
                }
            }

            LogisticaProcMostrar(_Registros[Indice]);
        }

        // ========================================================
        // MOSTRAR DATOS DEL MOVIMIENTO
        // ========================================================

        private void LogisticaProcMostrar(
            ClsModeloMovimientoInventario D)
        {
            bool Anterior = _Cargando;
            _Cargando = true;

            try
            {
                LogisticaCboIdMovimiento.SelectedValue =
                    D.FkTipoMovimientoCodigo;

                LogisticaCboTransporte.SelectedIndex = -1;

                if (D.FkTransporteCodigo.HasValue)
                    LogisticaCboTransporte.SelectedValue =
                        D.FkTransporteCodigo.Value;

                LogisticaCboIdSucursalOrigen.SelectedIndex = -1;

                if (D.FkSucursalOrigenCodigo.HasValue)
                    LogisticaCboIdSucursalOrigen.SelectedValue =
                        D.FkSucursalOrigenCodigo.Value;

                LogisticaProcCargarBodegas(
                    LogisticaCboBodegaOrigen,
                    D.FkSucursalOrigenCodigo,
                    D.FkBodegaOrigenCodigo);

                LogisticaCboIdSucursalDestino.SelectedIndex = -1;

                if (D.FkSucursalDestinoCodigo.HasValue)
                    LogisticaCboIdSucursalDestino.SelectedValue =
                        D.FkSucursalDestinoCodigo.Value;

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
                _Cargando = Anterior;
            }
        }

        // ========================================================
        // LIMPIAR CONTROLES
        // ========================================================

        private void LogisticaProcLimpiar()
        {
            bool Anterior = _Cargando;
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

                LogisticaDtpFechaMovimiento.Value = DateTime.Now;

                LogisticaTxtObservacionMovimientoInventario.Clear();
            }
            finally
            {
                _Cargando = Anterior;
            }
        }

        // ========================================================
        // CAMBIAR MODO
        // ========================================================

        private void LogisticaProcCambiarModo(Modo Nuevo)
        {
            _Modo = Nuevo;

            bool Editando = Nuevo != Modo.Consulta;

            LogistinaPnlDatosMovimiento.Enabled = Editando;

            LogisticaBtnGuardarMovimientoInventario.Enabled =
                Editando;

            LogisticaBtnCancelarMovimientoInventario.Enabled =
                Editando;

            LogisticaBtnIngresarMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnConsultarMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnModificarMovimientoInventario.Enabled =
                !Editando;

            LogistiaBtnEliminarMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnRefrescarMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnImprimirMovimientoInventario.Enabled =
                !Editando;

            LogisticaDgvListadoMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnInicioMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnAnteriorMovimientoInventario.Enabled =
                !Editando;

            LogisticaBtnSiguienteStock.Enabled = !Editando;

            LogisticaBtnFinMovimientoInventario.Enabled =
                !Editando;

            LogisticaProcAplicarTipo();
        }

        // ========================================================
        // LEER DATOS DEL FORMULARIO
        // ========================================================

        private ClsModeloMovimientoInventario
            LogisticaFuncLeerFormulario()
        {
            int? Tipo = LogisticaFuncId(
                LogisticaCboIdMovimiento);

            if (!Tipo.HasValue)
                throw new ArgumentException(
                    "Seleccione un tipo de movimiento.");

            return new ClsModeloMovimientoInventario
            {
                IdMovimientoInventario =
                    _Modo == Modo.Modificar && _Indice >= 0
                        ? _Registros[_Indice].IdMovimientoInventario
                        : 0,

                FkTipoMovimientoCodigo = Tipo.Value,

                FkSucursalOrigenCodigo = LogisticaFuncId(
                    LogisticaCboIdSucursalOrigen),

                FkBodegaOrigenCodigo = LogisticaFuncId(
                    LogisticaCboBodegaOrigen),

                FkSucursalDestinoCodigo = LogisticaFuncId(
                    LogisticaCboIdSucursalDestino),

                FkBodegaDestinoCodigo = LogisticaFuncId(
                    LogisticaCboBodegaDestino),

                FkTransporteCodigo = LogisticaFuncId(
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
                    "Seleccione un movimiento para modificar.");
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
                LogisticaProcAplicarTipo();
            });
        }

        // ========================================================
        // GUARDAR
        // ========================================================

        private void LogisticaProcGuardar()
        {
            if (_Modo == Modo.Consulta)
                return;

            LogisticaProcEjecutar(() =>
            {
                ClsModeloMovimientoInventario D =
                    LogisticaFuncLeerFormulario();

                string Mensaje = _Modo == Modo.Ingresar
                    ? _Modelo.LogisticaFuncAgregar(D)
                    : _Modelo.LogisticaFuncEditar(D);

                MessageBox.Show(
                    Mensaje,
                    "Logística - Movimiento de Inventario",
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
                    "Seleccione un movimiento para eliminar.");
                return;
            }

            int Id = _Registros[_Indice].IdMovimientoInventario;

            if (MessageBox.Show(
                "¿Desea eliminar el movimiento " + Id + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            LogisticaProcEjecutar(() =>
            {
                string Mensaje = _Modelo.LogisticaFuncEliminar(Id);

                MessageBox.Show(
                    Mensaje,
                    "Logística",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaProcConsultar();
            });
        }

        // ========================================================
        // CANCELAR
        // ========================================================

        private void LogisticaProcCancelar()
        {
            LogisticaProcCambiarModo(Modo.Consulta);

            if (_Indice >= 0 && _Indice < _Registros.Count)
                LogisticaProcSeleccionar(_Indice);
            else
                LogisticaProcLimpiar();
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
                    "No existen movimientos para imprimir.");
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
                throw new InvalidOperationException(
                    "No se encontró RpReporteMovimientoInventario.rdlc. " +
                    "Configure su Acción de compilación como " +
                    "Recurso incrustado.");

            using (Form Ventana = new Form())
            {
                ReportViewer Visor = new ReportViewer();

                Ventana.Text =
                    "Reporte de Movimiento de Inventario";

                Ventana.StartPosition =
                    FormStartPosition.CenterParent;

                Ventana.WindowState =
                    FormWindowState.Maximized;

                Visor.Dock = DockStyle.Fill;
                Visor.ProcessingMode = ProcessingMode.Local;

                Ventana.Controls.Add(Visor);

                using (Stream Archivo =
                    Ensamblado.GetManifestResourceStream(Recurso))
                {
                    if (Archivo == null)
                        throw new InvalidOperationException(
                            "No se pudo abrir el archivo RDLC.");

                    Visor.LocalReport.LoadReportDefinition(Archivo);
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
        // MANEJAR ERRORES
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

        private void LogisticaProcMostrarAyuda(object sender, EventArgs e)
        {
            DirectoryInfo DirectorioActual =
                new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (DirectorioActual != null)
            {
                string RutaAyuda = Path.Combine(
                    DirectorioActual.FullName,
                    "ayuda",
                    "modulos",
                    "logistica",
                    "LogisticaAyudas",
                    "LogisticaAyudas.chm");

                if (File.Exists(RutaAyuda))
                {
                    Help.ShowHelp(this, RutaAyuda, "MovimientoInventario_Logistica.html");
                    return;
                }

                DirectorioActual = DirectorioActual.Parent;
            }

            MessageBox.Show(
                this,
                "No se encontró el archivo de ayuda",
                "MovimientoInventario_Logistica",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        private void LogisticaBtnAyudaMovimientoInventario_Click(object sender, EventArgs e)
        {
            LogisticaProcMostrarAyuda(sender, e);
        }
    }
}

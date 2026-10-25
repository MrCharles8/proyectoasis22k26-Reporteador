// Autor: José Xavier Bolaños Tenas, carné 0901-23-2128.
// Propósito: gestionar la captura, navegación y consulta de traslados logísticos.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_Traslados_Logistica;

namespace CapaVista_Traslados_Logistica.Formas
{
    public partial class FrmTraslados : Form
    {
        private readonly ClsControladorTraslado _ControladorTraslado = new ClsControladorTraslado();
        
        // Inicializa el formulario, enlaza eventos y carga los datos de logística.
        public FrmTraslados()
        {
            InitializeComponent();
            LogisticaPnlDatosTraslados.Enabled = false;
            LogisticaProcConfigurarGrillaTraslados();

            LogisticaBtnNuevoTraslados.Click += LogisticaProcHabilitarCaptura;
            LogisticaBtnCancelarTraslados.Click += LogisticaProcCancelarCaptura;
            LogisticaBtnInicioTraslados.Click += LogisticaProcIrAlPrimerTraslado;
            LogisticaBtnFinTraslados.Click += LogisticaProcIrAlUltimoTraslado;
            LogisticaBtnAnteriorTraslados.Click += LogisticaProcIrAlTrasladoAnterior;
            LogisticaBtnSiguienteTraslados.Click += LogisticaProcIrAlTrasladoSiguiente;
            LogisticaBtnVerDetalleTraslados.Click += LogisticaProcMostrarDetalle;
            LogisticaBtnGuardarTraslados.Click += LogisticaProcGuardarTraslado;
            LogisticaBtnAgregarTraslados.Click += LogisticaProcAgregarProducto;
            LogisticaBtnEliminarTraslados.Click += LogisticaProcEliminarProducto;

            LogisticaCboBodegaOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            LogisticaCboBodegaDestinoTraslados.DropDownStyle = ComboBoxStyle.DropDownList;
            LogisticaCboEstadoTraslado.DropDownStyle = ComboBoxStyle.DropDownList;
            LogisticaCboTransporteTraslado.DropDownStyle = ComboBoxStyle.DropDownList;
            LogisticaCboProductoTraslados.DropDownStyle = ComboBoxStyle.DropDownList;

            DataGridViewTextBoxColumn ColumnaIdProducto = new DataGridViewTextBoxColumn
            {
                Name = "idProducto",
                Visible = false
            };
            LogisticaDgvProductoTraslados.Columns.Add(ColumnaIdProducto);

            try
            {
                LogisticaProcCargarListas();
            }
            catch (Exception Excepcion)
            {
                MessageBox.Show("No fue posible cargar los datos de logística. Verifique la conexión ODBC 'EmbutidosS.A'.\n\n" + Excepcion.Message,
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga los catálogos usados por los combos y actualiza la lista de traslados.

        private void LogisticaProcCargarListas()
        {
            try
            {
                DataTable Bodegas = _ControladorTraslado.LogisticaFuncListarBodegas();

                LogisticaCboBodegaOrigen.DisplayMember = "nombreBodega";
                LogisticaCboBodegaOrigen.ValueMember = "idBodega";
                LogisticaCboBodegaOrigen.DataSource = Bodegas;

                LogisticaCboBodegaDestinoTraslados.DisplayMember = "nombreBodega";
                LogisticaCboBodegaDestinoTraslados.ValueMember = "idBodega";
                LogisticaCboBodegaDestinoTraslados.DataSource =
                    _ControladorTraslado.LogisticaFuncListarBodegas();
            }
            catch (Exception Excepcion)
            {
                throw new Exception("Error al cargar BODEGAS: " + Excepcion.Message, Excepcion);
            }

            try
            {
                LogisticaCboProductoTraslados.DisplayMember = "descripcionProducto";
                LogisticaCboProductoTraslados.ValueMember = "idProducto";
                LogisticaCboProductoTraslados.DataSource =
                    _ControladorTraslado.LogisticaFuncListarProductos();
            }
            catch (Exception Excepcion)
            {
                throw new Exception("Error al cargar PRODUCTOS: " + Excepcion.Message, Excepcion);
            }

            try
            {
                LogisticaCboTransporteTraslado.DisplayMember = "descripcionTransporte";
                LogisticaCboTransporteTraslado.ValueMember = "idTransporte";
                LogisticaCboTransporteTraslado.DataSource =
                    _ControladorTraslado.LogisticaFuncListarTransportes();
            }
            catch (Exception Excepcion)
            {
                throw new Exception("Error al cargar TRANSPORTES: " + Excepcion.Message, Excepcion);
            }

            try
            {
                LogisticaCboEstadoTraslado.DisplayMember = "estadoTraslado";
                LogisticaCboEstadoTraslado.ValueMember = "estadoTraslado";
                LogisticaCboEstadoTraslado.DataSource =
                    _ControladorTraslado.LogisticaFuncListarEstados();
            }
            catch (Exception Excepcion)
            {
                throw new Exception("Error al cargar ESTADOS: " + Excepcion.Message, Excepcion);
            }

            try
            {
                LogisticaProcCargarTraslados();
            }
            catch (Exception Excepcion)
            {
                throw new Exception("Error al cargar TRASLADOS: " + Excepcion.Message, Excepcion);
            }
        }

        // Vincula las columnas visibles del grid con los campos devueltos por el controlador.
        private void LogisticaProcConfigurarGrillaTraslados()
        {
            LogisticaDgvListaTraslados.AutoGenerateColumns = false;
            codigoTraslado.DataPropertyName = "codigoTraslado";
            fechaSolicitud.DataPropertyName = "fechaSolicitud";
            bodegaOrigen.DataPropertyName = "bodegaOrigen";
            fechaSalida.DataPropertyName = "fechaSalida";
            bodegaDestino.DataPropertyName = "bodegaDestino";
            fechaEntrega.DataPropertyName = "fechaEntrega";
            codigoTransporte.DataPropertyName = "codigoTransporte";
            estadoTraslado.DataPropertyName = "estadoTraslado";
        }

        // Consulta los traslados y los presenta en el grid principal.
        private void LogisticaProcCargarTraslados()
        {
            LogisticaDgvListaTraslados.DataSource = _ControladorTraslado.LogisticaFuncListarTraslados();
        }

        // Agrega el producto seleccionado al detalle temporal del traslado.
        private void LogisticaProcAgregarProducto(object Sender, EventArgs E)
        {
            int IdProducto;
            int Cantidad;
            if (LogisticaCboProductoTraslados.SelectedValue == null ||
                !Int32.TryParse(LogisticaTxtCantidadTraslados.Text.Trim(), out Cantidad) || Cantidad <= 0)
            {
                MessageBox.Show("Seleccione un producto e ingrese una cantidad entera mayor que cero.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdProducto = Convert.ToInt32(LogisticaCboProductoTraslados.SelectedValue);
            foreach (DataGridViewRow FilaExistente in LogisticaDgvProductoTraslados.Rows)
            {
                if (Convert.ToInt32(FilaExistente.Cells["idProducto"].Value) == IdProducto)
                {
                    FilaExistente.Cells["cantidadProducto"].Value =
                        Convert.ToInt32(FilaExistente.Cells["cantidadProducto"].Value) + Cantidad;
                    LogisticaTxtCantidadTraslados.Clear();
                    return;
                }
            }

            DataRowView ProductoSeleccionado = LogisticaCboProductoTraslados.SelectedItem as DataRowView;
            LogisticaDgvProductoTraslados.Rows.Add(
                ProductoSeleccionado["skuProducto"], ProductoSeleccionado["nombreProducto"], Cantidad, IdProducto);
            LogisticaTxtCantidadTraslados.Clear();
        }

        // Elimina del detalle temporal el producto seleccionado en el grid.
        private void LogisticaProcEliminarProducto(object Sender, EventArgs E)
        {
            if (LogisticaDgvProductoTraslados.CurrentRow != null)
            {
                LogisticaDgvProductoTraslados.Rows.Remove(LogisticaDgvProductoTraslados.CurrentRow);
            }
        }

        // Envía los datos capturados al controlador y refresca la lista tras guardar.

        // Envía los datos capturados al controlador y refresca la lista tras guardar.
        private void LogisticaProcGuardarTraslado(object Sender, EventArgs E)
        {
            try
            {
                DataTable TablaDetalles = new DataTable();
                TablaDetalles.Columns.Add("idProducto", typeof(int));
                TablaDetalles.Columns.Add("cantidad", typeof(int));

                foreach (DataGridViewRow Fila in LogisticaDgvProductoTraslados.Rows)
                {
                    TablaDetalles.Rows.Add(
                        Convert.ToInt32(Fila.Cells["idProducto"].Value),
                        Convert.ToInt32(Fila.Cells["cantidadProducto"].Value));
                }

                _ControladorTraslado.LogisticaProcGuardarTraslado(
                    LogisticaTxtCodigoTraslado.Text.Trim(),
                    LogisticaCboBodegaOrigen.SelectedValue == null
                        ? 0
                        : Convert.ToInt32(LogisticaCboBodegaOrigen.SelectedValue),
                    LogisticaCboBodegaDestinoTraslados.SelectedValue == null
                        ? 0
                        : Convert.ToInt32(LogisticaCboBodegaDestinoTraslados.SelectedValue),
                    LogisticaCboTransporteTraslado.SelectedValue == null
                        ? (int?)null
                        : Convert.ToInt32(LogisticaCboTransporteTraslado.SelectedValue),
                    LogisticaDtpFechaSalidaTraslados.Value,
                    LogisticaCboEstadoTraslado.SelectedValue == null
                        ? String.Empty
                        : LogisticaCboEstadoTraslado.SelectedValue.ToString(),
                    TablaDetalles,
                    LogisticaTxtObservacionesTraslado.Text.Trim()
                );

                LogisticaProcCargarTraslados();

                MessageBox.Show(
                    "Traslado guardado correctamente.",
                    "Traslados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaProcLimpiarControles(LogisticaPnlDatosTraslados);
                LogisticaPnlDatosTraslados.Enabled = false;
            }
            catch (Exception Excepcion)
            {
                MessageBox.Show(
                    Excepcion.Message,
                    "No se pudo guardar el traslado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


        // Habilita el panel para iniciar la captura de un traslado.
        private void LogisticaProcHabilitarCaptura(object Sender, EventArgs E)
        {
            LogisticaPnlDatosTraslados.Enabled = true;
        }

        // Limpia y deshabilita el panel de captura del traslado.
        private void LogisticaProcCancelarCaptura(object Sender, EventArgs E)
        {
            LogisticaProcLimpiarControles(LogisticaPnlDatosTraslados);
            LogisticaPnlDatosTraslados.Enabled = false;
        }

        // Limpia de forma recursiva los controles contenidos en un panel.
        private void LogisticaProcLimpiarControles(Control Contenedor)
        {
            foreach (Control ControlActual in Contenedor.Controls)
            {
                TextBox CuadroTexto = ControlActual as TextBox;
                ComboBox Lista = ControlActual as ComboBox;
                DateTimePicker SelectorFecha = ControlActual as DateTimePicker;
                DataGridView Grilla = ControlActual as DataGridView;

                if (CuadroTexto != null)
                {
                    CuadroTexto.Clear();
                }
                else if (Lista != null)
                {
                    Lista.SelectedIndex = -1;
                    Lista.Text = String.Empty;
                }
                else if (SelectorFecha != null)
                {
                    SelectorFecha.Value = DateTime.Today;
                }
                else if (Grilla != null)
                {
                    if (Grilla.DataSource == null)
                    {
                        Grilla.Rows.Clear();
                    }
                    else
                    {
                        Grilla.DataSource = null;
                    }
                }

                if (ControlActual.HasChildren)
                {
                    LogisticaProcLimpiarControles(ControlActual);
                }
            }
        }

        // Selecciona el primer traslado visible en la lista.
        private void LogisticaProcIrAlPrimerTraslado(object Sender, EventArgs E)
        {
            LogisticaProcSeleccionarFila(0);
        }

        // Selecciona el último traslado visible en la lista.
        private void LogisticaProcIrAlUltimoTraslado(object Sender, EventArgs E)
        {
            LogisticaProcSeleccionarFila(LogisticaDgvListaTraslados.Rows.Count - 1);
        }

        // Selecciona el traslado anterior al registro actual.
        private void LogisticaProcIrAlTrasladoAnterior(object Sender, EventArgs E)
        {
            if (LogisticaDgvListaTraslados.CurrentRow != null)
            {
                LogisticaProcSeleccionarFila(LogisticaDgvListaTraslados.CurrentRow.Index - 1);
            }
        }

        // Selecciona el traslado siguiente al registro actual.
        private void LogisticaProcIrAlTrasladoSiguiente(object Sender, EventArgs E)
        {
            if (LogisticaDgvListaTraslados.CurrentRow != null)
            {
                LogisticaProcSeleccionarFila(LogisticaDgvListaTraslados.CurrentRow.Index + 1);
            }
        }

        // Selecciona una fila del grid si el índice se encuentra dentro de sus límites.
        private void LogisticaProcSeleccionarFila(int Indice)
        {
            if (Indice < 0 || Indice >= LogisticaDgvListaTraslados.Rows.Count)
            {
                return;
            }

            DataGridViewRow Fila = LogisticaDgvListaTraslados.Rows[Indice];
            if (Fila.Cells.Count == 0)
            {
                return;
            }

            LogisticaDgvListaTraslados.CurrentCell = Fila.Cells[0];
            LogisticaDgvListaTraslados.ClearSelection();
            Fila.Selected = true;
        }

        // Abre el formulario con el detalle del traslado.
        private void LogisticaProcMostrarDetalle(object Sender, EventArgs E)
        {
            using (FrmDetalleTraslados FormularioDetalle = new FrmDetalleTraslados())
            {
                FormularioDetalle.ShowDialog(this);
            }
        }
    }
}

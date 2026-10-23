// ------------------------------------------------------
// Autor: Gabriela Pinto García
// Carné: 9959-23-1087
// Fecha: 21/10/2026
// Módulo: Logística - Transporte Externo
// ------------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using CapaControlador_TransporteExterno_Logistica;

namespace CapaVista_TransporteExterno_Logistica.Formas
{
    public partial class RutaYSeguimiento : Form
    {
        private readonly ClsControladorRutaSeguimiento _Controlador;

        private bool _CargandoDatos = false;

        public RutaYSeguimiento()
        {
            InitializeComponent();

            _Controlador = new ClsControladorRutaSeguimiento();

            // EVENTOS DEL FORMULARIO
            this.Load += RutaYSeguimiento_Load;

            LogisticaCboNumeroGuia.SelectedIndexChanged +=
                LogisticaCboNumeroGuia_SelectedIndexChanged;

            LogisticaCboOrigen.SelectedIndexChanged +=
                LogisticaCboOrigen_SelectedIndexChanged;

            LogisticaCboDestino.SelectedIndexChanged +=
                LogisticaCboDestino_SelectedIndexChanged;

            LogisticaBtnAgregarProducto.Click +=
                LogisticaBtnAgregarProducto_Click;

            LogisticaBtnModificarProducto.Click +=
                LogisticaBtnModificarProducto_Click;

            LogisticaBtnEliminarProducto.Click +=
                LogisticaBtnEliminarProducto_Click;

            // PENDIENTE DE API GPS
            LogisticaBtnActualizarUbicacion.Enabled = false;

            LogisticaMetLimpiarSeguimiento();
        }

        // =====================================================
        // CARGAR FORMULARIO
        // =====================================================

        private void RutaYSeguimiento_Load(
            object sender, EventArgs e)
        {
            try
            {
                _CargandoDatos = true;

                LogisticaMetCargarBodegas();
                LogisticaMetCargarGuias();

                LogisticaMetLimpiarRuta();
                LogisticaMetLimpiarSeguimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar Ruta y Seguimiento:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _CargandoDatos = false;
            }
        }

        // =====================================================
        // CARGAR NÚMEROS DE GUÍA
        // =====================================================

        private void LogisticaMetCargarGuias()
        {
            DataTable guias =
                _Controlador.LogisticaFuncObtenerGuias();

            LogisticaCboNumeroGuia.DataSource = null;

            LogisticaCboNumeroGuia.DisplayMember = "Guia";
            LogisticaCboNumeroGuia.ValueMember = "Id";

            LogisticaCboNumeroGuia.DataSource = guias;
            LogisticaCboNumeroGuia.SelectedIndex = -1;
        }

        // =====================================================
        // CARGAR BODEGAS
        // =====================================================

        private void LogisticaMetCargarBodegas()
        {
            DataTable bodegas =
                _Controlador.LogisticaFuncObtenerBodegas();

            // BODEGA DE ORIGEN
            LogisticaCboOrigen.DataSource = null;

            LogisticaCboOrigen.DisplayMember = "Nombre";
            LogisticaCboOrigen.ValueMember = "Id";

            LogisticaCboOrigen.DataSource = bodegas.Copy();
            LogisticaCboOrigen.SelectedIndex = -1;

            // BODEGA DE DESTINO
            LogisticaCboDestino.DataSource = null;

            LogisticaCboDestino.DisplayMember = "Nombre";
            LogisticaCboDestino.ValueMember = "Id";

            LogisticaCboDestino.DataSource = bodegas.Copy();
            LogisticaCboDestino.SelectedIndex = -1;
        }

        // =====================================================
        // OBTENER ID DEL SERVICIO
        // =====================================================

        private int LogisticaFuncObtenerIdServicio()
        {
            if (LogisticaCboNumeroGuia.SelectedValue == null)
                return 0;

            if (LogisticaCboNumeroGuia.SelectedValue
                is DataRowView)
                return 0;

            int idServicio;

            if (int.TryParse(
                Convert.ToString(
                    LogisticaCboNumeroGuia.SelectedValue),
                out idServicio))
            {
                return idServicio;
            }

            return 0;
        }

        // =====================================================
        // OBTENER BODEGA SELECCIONADA
        // =====================================================

        private DataRow LogisticaFuncObtenerBodega(
            ComboBox combo)
        {
            DataRowView fila =
                combo.SelectedItem as DataRowView;

            if (fila == null)
                return null;

            return fila.Row;
        }

        // =====================================================
        // SELECCIONAR BODEGA POR NOMBRE
        // =====================================================

        private void LogisticaMetSeleccionarBodega(
            ComboBox combo,
            string nombre)
        {
            combo.SelectedIndex = -1;

            if (string.IsNullOrWhiteSpace(nombre))
                return;

            for (int i = 0; i < combo.Items.Count; i++)
            {
                DataRowView fila =
                    combo.Items[i] as DataRowView;

                if (fila == null)
                    continue;

                string nombreBodega =
                    Convert.ToString(fila["Nombre"]);

                if (string.Equals(
                    nombreBodega,
                    nombre,
                    StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

        // =====================================================
        // SELECCIONAR BODEGA POR ID
        // =====================================================

        private void LogisticaMetSeleccionarBodegaPorId(
            ComboBox combo,
            object idBodega)
        {
            if (idBodega == null ||
                idBodega == DBNull.Value)
                return;

            int id = Convert.ToInt32(idBodega);

            for (int i = 0; i < combo.Items.Count; i++)
            {
                DataRowView fila =
                    combo.Items[i] as DataRowView;

                if (fila == null)
                    continue;

                if (Convert.ToInt32(fila["Id"]) == id)
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }

        // =====================================================
        // LIMPIAR DATOS DE RUTA
        // =====================================================

        private void LogisticaMetLimpiarRuta()
        {
            LogisticaCboOrigen.SelectedIndex = -1;
            LogisticaCboDestino.SelectedIndex = -1;

            LogisticaTxtDireccionOrigen.Clear();
            LogisticaTxtDireccionDestino.Clear();
        }

        // =====================================================
        // LIMPIAR SEGUIMIENTO GPS
        // =====================================================

        private void LogisticaMetLimpiarSeguimiento()
        {
            LogisticaLblValorUbicacion.Text =
                "Pendiente de API";

            LogisticaLblValorEstadoUbicacion.Text =
                "Sin conexión GPS";

            LogisticaLblValorUltimaActualizacion.Text =
                "Sin actualización";
        }

        // =====================================================
        // CAMBIO DE NÚMERO DE GUÍA
        // =====================================================

        private void LogisticaCboNumeroGuia_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_CargandoDatos)
                return;

            LogisticaMetCargarTransporteSeleccionado();
        }

        // =====================================================
        // CARGAR RUTA DEL TRANSPORTE SELECCIONADO
        // =====================================================

        private void LogisticaMetCargarTransporteSeleccionado()
        {
            bool estadoAnterior = _CargandoDatos;

            try
            {
                _CargandoDatos = true;

                LogisticaMetLimpiarRuta();
                LogisticaMetLimpiarSeguimiento();

                int idServicio =
                    LogisticaFuncObtenerIdServicio();

                if (idServicio <= 0)
                    return;

                DataTable tablaRuta =
                    _Controlador.LogisticaFuncObtenerRuta(
                        idServicio);

                if (tablaRuta.Rows.Count == 0)
                    return;

                DataRow ruta = tablaRuta.Rows[0];

                string origen =
                    Convert.ToString(ruta["Origen"]);

                string destino =
                    Convert.ToString(ruta["Destino"]);

                // SELECCIONAR BODEGAS REGISTRADAS
                LogisticaMetSeleccionarBodega(
                    LogisticaCboOrigen,
                    origen);

                LogisticaMetSeleccionarBodega(
                    LogisticaCboDestino,
                    destino);

                // RECUPERAR DIRECCIONES
                LogisticaTxtDireccionOrigen.Text =
                    Convert.ToString(
                        ruta["DireccionOrigen"]);

                LogisticaTxtDireccionDestino.Text =
                    Convert.ToString(
                        ruta["DireccionDestino"]);

                // VERIFICAR TRASLADO RELACIONADO
                if (ruta["IdTraslado"] != DBNull.Value)
                {
                    int idTraslado =
                        Convert.ToInt32(ruta["IdTraslado"]);

                    DataTable tablaTraslado =
                        _Controlador
                        .LogisticaFuncObtenerBodegasTraslado(
                            idTraslado);

                    if (tablaTraslado.Rows.Count > 0)
                    {
                        DataRow traslado =
                            tablaTraslado.Rows[0];

                        if (LogisticaCboOrigen.SelectedIndex < 0)
                        {
                            LogisticaMetSeleccionarBodegaPorId(
                                LogisticaCboOrigen,
                                traslado["IdOrigen"]);
                        }

                        if (LogisticaCboDestino.SelectedIndex < 0)
                        {
                            LogisticaMetSeleccionarBodegaPorId(
                                LogisticaCboDestino,
                                traslado["IdDestino"]);
                        }
                    }
                }

                // COMPLETAR DIRECCIÓN DE ORIGEN
                if (string.IsNullOrWhiteSpace(
                    LogisticaTxtDireccionOrigen.Text))
                {
                    DataRow bodegaOrigen =
                        LogisticaFuncObtenerBodega(
                            LogisticaCboOrigen);

                    if (bodegaOrigen != null)
                    {
                        LogisticaTxtDireccionOrigen.Text =
                            Convert.ToString(
                                bodegaOrigen["Direccion"]);
                    }
                }

                // COMPLETAR DIRECCIÓN DE DESTINO
                if (string.IsNullOrWhiteSpace(
                    LogisticaTxtDireccionDestino.Text))
                {
                    DataRow bodegaDestino =
                        LogisticaFuncObtenerBodega(
                            LogisticaCboDestino);

                    if (bodegaDestino != null)
                    {
                        LogisticaTxtDireccionDestino.Text =
                            Convert.ToString(
                                bodegaDestino["Direccion"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la ruta:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _CargandoDatos = estadoAnterior;
            }
        }

        // =====================================================
        // CAMBIO DE BODEGA DE ORIGEN
        // =====================================================

        private void LogisticaCboOrigen_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_CargandoDatos)
                return;

            DataRow bodega =
                LogisticaFuncObtenerBodega(
                    LogisticaCboOrigen);

            LogisticaTxtDireccionOrigen.Text =
                bodega == null
                    ? ""
                    : Convert.ToString(
                        bodega["Direccion"]);
        }

        // =====================================================
        // CAMBIO DE BODEGA DE DESTINO
        // =====================================================

        private void LogisticaCboDestino_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_CargandoDatos)
                return;

            DataRow bodega =
                LogisticaFuncObtenerBodega(
                    LogisticaCboDestino);

            LogisticaTxtDireccionDestino.Text =
                bodega == null
                    ? ""
                    : Convert.ToString(
                        bodega["Direccion"]);
        }

        // =====================================================
        // AGREGAR RUTA
        // =====================================================

        private void LogisticaBtnAgregarProducto_Click(
            object sender, EventArgs e)
        {
            try
            {
                int idServicio =
                    LogisticaFuncObtenerIdServicio();

                DataRow origen =
                    LogisticaFuncObtenerBodega(
                        LogisticaCboOrigen);

                DataRow destino =
                    LogisticaFuncObtenerBodega(
                        LogisticaCboDestino);

                _Controlador.LogisticaMetAgregarRuta(
                    idServicio,
                    origen,
                    destino);

                MessageBox.Show(
                    "Ruta agregada correctamente.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaMetCargarTransporteSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo agregar la ruta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // =====================================================
        // MODIFICAR RUTA
        // =====================================================

        private void LogisticaBtnModificarProducto_Click(
            object sender, EventArgs e)
        {
            try
            {
                int idServicio =
                    LogisticaFuncObtenerIdServicio();

                DataRow origen =
                    LogisticaFuncObtenerBodega(
                        LogisticaCboOrigen);

                DataRow destino =
                    LogisticaFuncObtenerBodega(
                        LogisticaCboDestino);

                _Controlador.LogisticaMetModificarRuta(
                    idServicio,
                    origen,
                    destino);

                MessageBox.Show(
                    "Ruta modificada correctamente.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaMetCargarTransporteSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo modificar la ruta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // =====================================================
        // ELIMINAR RUTA
        // =====================================================

        private void LogisticaBtnEliminarProducto_Click(
            object sender, EventArgs e)
        {
            int idServicio =
                LogisticaFuncObtenerIdServicio();

            if (idServicio <= 0)
            {
                MessageBox.Show(
                    "Debes seleccionar un número de guía.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirmacion =
                MessageBox.Show(
                    "¿Deseas eliminar los datos de esta ruta?\n\n" +
                    "El transporte y su número de guía " +
                    "se conservarán.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                _Controlador.LogisticaMetEliminarRuta(
                    idServicio);

                MessageBox.Show(
                    "Datos de ruta eliminados correctamente.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaMetCargarTransporteSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo eliminar la ruta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}

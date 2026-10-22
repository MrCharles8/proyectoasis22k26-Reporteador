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
    public partial class RegistroTransporteExterno : Form
    {
        private readonly ClsControladorTransporteExterno _Controlador;
        private DataTable _Transportes;
        private int _IdSeleccionado = 0;
        private bool _Cargando = false;

        public RegistroTransporteExterno()
        {
            InitializeComponent();

            _Controlador = new ClsControladorTransporteExterno();

            LogisticaBtnAgregarProducto.Click +=
                LogisticaBtnAgregarProducto_Click;

            LogisticaBtnModificarProducto.Click +=
                LogisticaBtnModificarProducto_Click;

            // Evento agregado para eliminar.
            LogisticaBtnEliminarProducto.Click +=
                LogisticaBtnEliminarProducto_Click;

            LogisticaCboNumeroGuia.SelectedIndexChanged +=
                LogisticaCboNumeroGuia_SelectedIndexChanged;

            LogisticaCboTransportista.SelectedIndexChanged +=
                LogisticaCboTransportista_SelectedIndexChanged;

            LogisticaTxtCodigo.ReadOnly = true;
            LogisticaTxtNumeroGuia.ReadOnly = true;
            LogisticaTxtCodigo.Text = "Pendiente de generar";

            LogisticaDtpFechaEntregaReal.ShowCheckBox = true;
            LogisticaDtpFechaEntregaReal.Checked = false;

            LogisticaMetCargarCatalogos();
            LogisticaMetCargarGuias();
            LogisticaMetMostrarVistaPrevia();
        }

        private void LogisticaMetCargarCatalogos()
        {
            try
            {
                _Cargando = true;

                LogisticaCboTransportista.DataSource =
                    _Controlador.LogisticaFuncObtenerEmpresas();

                LogisticaCboTransportista.DisplayMember =
                    "nombreEmpresaTransportista";

                LogisticaCboTransportista.ValueMember =
                    "Pk_EmpresaTransportista";

                LogisticaCboTipoServicio.DataSource =
                    _Controlador.LogisticaFuncObtenerTiposServicio();

                LogisticaCboTipoServicio.DisplayMember =
                    "nombreTipoServicio";

                LogisticaCboTipoServicio.ValueMember =
                    "Pk_TipoServicio";

                LogisticaCboEstado.SelectedItem = "Programado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar catálogos: " + ex.Message);
            }
            finally
            {
                _Cargando = false;
            }
        }

        private void LogisticaMetCargarGuias()
        {
            try
            {
                _Cargando = true;

                _Transportes =
                    _Controlador.LogisticaFuncObtenerRegistroTransportes();

                LogisticaCboNumeroGuia.DataSource = null;

                LogisticaCboNumeroGuia.DisplayMember =
                    "numeroGuiaServicioTransporteExterno";

                LogisticaCboNumeroGuia.ValueMember =
                    "Pk_ServicioTransporteExterno";

                LogisticaCboNumeroGuia.DataSource = _Transportes;
                LogisticaCboNumeroGuia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar guías: " + ex.Message);
            }
            finally
            {
                _Cargando = false;
            }
        }

        private string LogisticaFuncPrefijo()
        {
            string nombre =
                LogisticaCboTransportista.Text.Trim().ToUpperInvariant();

            switch (nombre)
            {
                case "FORZA": return "FZ";
                case "CARGO EXPRESO": return "CE";
                case "GUATEX": return "GX";
                case "DHL EXPRESS": return "DHL";
                case "FEDEX": return "FX";
                case "UPS": return "UPS";
                default: return "TR";
            }
        }

        private void LogisticaMetMostrarVistaPrevia()
        {
            if (_Cargando || _IdSeleccionado > 0)
                return;

            try
            {
                DataTable datos =
                    _Controlador.LogisticaFuncObtenerProximosCodigos();

                if (datos.Rows.Count == 0 ||
                    datos.Rows[0]["siguienteTransporte"] == DBNull.Value ||
                    datos.Rows[0]["siguienteSolicitud"] == DBNull.Value)
                {
                    throw new Exception(
                        "No se pudo consultar el próximo correlativo.");
                }

                int idTransporte = Convert.ToInt32(
                    datos.Rows[0]["siguienteTransporte"]);

                int idSolicitud = Convert.ToInt32(
                    datos.Rows[0]["siguienteSolicitud"]);

                LogisticaTxtNumeroGuia.Text =
                    LogisticaFuncPrefijo() + "-" +
                    idTransporte.ToString("D6");

                LogisticaTxtCodigo.Text =
                    "SP-" + idSolicitud.ToString("D6");
            }
            catch (Exception ex)
            {
                LogisticaTxtNumeroGuia.Text = "Pendiente de generar";
                LogisticaTxtCodigo.Text = "Pendiente de generar";

                MessageBox.Show(
                    "No se pudieron consultar los correlativos: " +
                    ex.Message);
            }
        }

        private void LogisticaCboTransportista_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_Cargando)
                return;

            DataRowView empresa =
                LogisticaCboTransportista.SelectedItem as DataRowView;

            if (empresa != null)
            {
                LogisticaTxtContacto.Text =
                    Convert.ToString(
                        empresa["contactoEmpresaTransportista"]);
            }

            LogisticaMetMostrarVistaPrevia();
        }

        private void LogisticaCboNumeroGuia_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (_Cargando)
                return;

            if (LogisticaCboNumeroGuia.SelectedIndex < 0)
            {
                _IdSeleccionado = 0;
                LogisticaMetMostrarVistaPrevia();
                return;
            }

            DataRowView seleccionado =
                LogisticaCboNumeroGuia.SelectedItem as DataRowView;

            if (seleccionado == null)
                return;

            DataRow fila = seleccionado.Row;

            _IdSeleccionado = Convert.ToInt32(
                fila["Pk_ServicioTransporteExterno"]);

            LogisticaTxtNumeroGuia.Text = Convert.ToString(
                fila["numeroGuiaServicioTransporteExterno"]);

            string codigoPago = Convert.ToString(
                fila["codigoSolicitudPagoTransporte"]);

            LogisticaTxtCodigo.Text =
                string.IsNullOrWhiteSpace(codigoPago)
                    ? "Pendiente de generar"
                    : codigoPago;

            LogisticaCboTransportista.SelectedValue =
                fila["Fk_EmpresaTransportista_Codigo"];

            LogisticaCboTipoServicio.SelectedValue =
                fila["Fk_TipoServicio_Codigo"];

            LogisticaCboEstado.SelectedItem = Convert.ToString(
                fila["estadoServicioTransporteExterno"]);

            LogisticaTxtContacto.Text = Convert.ToString(
                fila["contactoEmpresaTransportista"]);

            LogisticaTxtPlaca.Text = Convert.ToString(
                fila["placaVehiculoTransporte"]);

            LogisticaTxtTipoVehiculo.Text = Convert.ToString(
                fila["tipoVehiculoTransporte"]);

            LogisticaTxtCapacidad.Text = Convert.ToString(
                fila["capacidadVehiculoTransporte"]);

            LogisticaTxtConductor.Text = Convert.ToString(
                fila["nombreConductorTransporte"]);

            LogisticaTxtTelefonoConductor.Text = Convert.ToString(
                fila["telefonoConductorTransporte"]);

            LogisticaDtpFechaContratacion.Value =
                Convert.ToDateTime(
                    fila["fechaContratacionServicioTransporteExterno"]);

            LogisticaDtpFechaEstimada.Value =
                Convert.ToDateTime(
                    fila["fechaEstimadaEntregaServicioTransporteExterno"]);

            LogisticaDtpFechaEntregaReal.Checked =
                fila["fechaEntregaRealServicioTransporteExterno"]
                    != DBNull.Value;

            if (LogisticaDtpFechaEntregaReal.Checked)
            {
                LogisticaDtpFechaEntregaReal.Value =
                    Convert.ToDateTime(
                        fila["fechaEntregaRealServicioTransporteExterno"]);
            }
        }

        private bool LogisticaFuncValidar()
        {
            if (LogisticaCboTransportista.SelectedIndex < 0 ||
                LogisticaCboTipoServicio.SelectedIndex < 0 ||
                LogisticaCboEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Selecciona empresa, tipo de servicio y estado.");

                return false;
            }

            if (LogisticaDtpFechaEstimada.Value.Date <
                LogisticaDtpFechaContratacion.Value.Date)
            {
                MessageBox.Show(
                    "La fecha estimada no puede ser anterior a la contratación.");

                return false;
            }

            return true;
        }

        private DateTime? LogisticaFuncFechaReal()
        {
            return LogisticaDtpFechaEntregaReal.Checked
                ? (DateTime?)LogisticaDtpFechaEntregaReal.Value.Date
                : null;
        }

        private void LogisticaBtnAgregarProducto_Click(
            object sender, EventArgs e)
        {
            if (!LogisticaFuncValidar())
                return;

            try
            {
                DataTable resultado =
                    _Controlador.LogisticaFuncAgregarTransporte(
                        Convert.ToInt32(
                            LogisticaCboTransportista.SelectedValue),
                        Convert.ToInt32(
                            LogisticaCboTipoServicio.SelectedValue),
                        LogisticaCboEstado.Text,
                        LogisticaDtpFechaContratacion.Value.Date,
                        LogisticaDtpFechaEstimada.Value.Date,
                        LogisticaFuncFechaReal(),
                        LogisticaTxtPlaca.Text.Trim(),
                        LogisticaTxtTipoVehiculo.Text.Trim(),
                        LogisticaTxtCapacidad.Text.Trim(),
                        LogisticaTxtConductor.Text.Trim(),
                        LogisticaTxtTelefonoConductor.Text.Trim()
                    );

                string guia = Convert.ToString(
                    resultado.Rows[0]["numeroGuia"]);

                string solicitud = Convert.ToString(
                    resultado.Rows[0]["codigoSolicitudPago"]);

                MessageBox.Show(
                    "Transporte registrado correctamente.\n\n" +
                    "Guía: " + guia + "\n" +
                    "Solicitud de pago: " + solicitud + "\n" +
                    "Estado: Pendiente",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogisticaMetCargarGuias();

                for (int i = 0;
                     i < LogisticaCboNumeroGuia.Items.Count; i++)
                {
                    DataRowView item =
                        LogisticaCboNumeroGuia.Items[i] as DataRowView;

                    if (item != null &&
                        Convert.ToString(
                            item["numeroGuiaServicioTransporteExterno"])
                            == guia)
                    {
                        LogisticaCboNumeroGuia.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar transporte: " + ex.Message);
            }
        }

        private void LogisticaBtnModificarProducto_Click(
            object sender, EventArgs e)
        {
            if (_IdSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Primero selecciona un número de guía.");

                return;
            }

            if (!LogisticaFuncValidar())
                return;

            try
            {
                _Controlador.LogisticaMetModificarTransporte(
                    _IdSeleccionado,
                    Convert.ToInt32(
                        LogisticaCboTransportista.SelectedValue),
                    Convert.ToInt32(
                        LogisticaCboTipoServicio.SelectedValue),
                    LogisticaCboEstado.Text,
                    LogisticaDtpFechaContratacion.Value.Date,
                    LogisticaDtpFechaEstimada.Value.Date,
                    LogisticaFuncFechaReal(),
                    LogisticaTxtPlaca.Text.Trim(),
                    LogisticaTxtTipoVehiculo.Text.Trim(),
                    LogisticaTxtCapacidad.Text.Trim(),
                    LogisticaTxtConductor.Text.Trim(),
                    LogisticaTxtTelefonoConductor.Text.Trim()
                );

                int id = _IdSeleccionado;

                LogisticaMetCargarGuias();
                LogisticaCboNumeroGuia.SelectedValue = id;

                MessageBox.Show(
                    "Transporte modificado correctamente.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar transporte: " + ex.Message);
            }
        }

        // Eliminar transporte seleccionado.
        private void LogisticaBtnEliminarProducto_Click(
            object sender, EventArgs e)
        {
            if (_IdSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Primero selecciona un número de guía.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string guia = LogisticaTxtNumeroGuia.Text;

            DialogResult respuesta = MessageBox.Show(
                "¿Deseas eliminar el transporte " + guia + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _Controlador.LogisticaMetEliminarTransporte(
                    _IdSeleccionado);

                _IdSeleccionado = 0;

                LogisticaMetCargarGuias();

                LogisticaCboNumeroGuia.SelectedIndex = -1;

                LogisticaTxtCodigo.Clear();
                LogisticaTxtNumeroGuia.Clear();
                LogisticaTxtContacto.Clear();
                LogisticaTxtPlaca.Clear();
                LogisticaTxtTipoVehiculo.Clear();
                LogisticaTxtCapacidad.Clear();
                LogisticaTxtConductor.Clear();
                LogisticaTxtTelefonoConductor.Clear();

                LogisticaDtpFechaEntregaReal.Checked = false;

                LogisticaMetMostrarVistaPrevia();

                MessageBox.Show(
                    "El transporte " + guia +
                    " se eliminó correctamente.",
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el transporte: " + ex.Message,
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

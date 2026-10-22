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
    public partial class ListadoTransporteExterno : Form
    {
        private readonly ClsControladorTransporteExterno _Controlador;

        public ListadoTransporteExterno()
        {
            InitializeComponent();

            _Controlador = new ClsControladorTransporteExterno();

            // Cargar transportes al abrir el formulario.
            this.Load += ListadoTransporteExterno_Load;

            // Actualizar al regresar al listado.
            this.Activated += ListadoTransporteExterno_Activated;
        }

        // Cargar transportes al iniciar.
        private void ListadoTransporteExterno_Load(
            object sender, EventArgs e)
        {
            LogisticaMetCargarTransportes();
        }

        // Actualizar automáticamente el listado.
        private void ListadoTransporteExterno_Activated(
            object sender, EventArgs e)
        {
            LogisticaMetCargarTransportes();
        }

        // Consultar los transportes desde MySQL.
        public void LogisticaMetCargarTransportes()
        {
            try
            {
                DataTable tabla =
                    _Controlador.LogisticaFuncObtenerTransportes();

                // Limpiar información anterior.
                LogisticaDvglListadoTransportes.DataSource = null;

                // Mostrar registros actualizados.
                LogisticaDvglListadoTransportes.DataSource = tabla;

                // Configuración del DataGridView.
                LogisticaDvglListadoTransportes.ReadOnly = true;

                LogisticaDvglListadoTransportes.AllowUserToAddRows =
                    false;

                LogisticaDvglListadoTransportes.AllowUserToDeleteRows =
                    false;

                LogisticaDvglListadoTransportes.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                LogisticaDvglListadoTransportes.MultiSelect = false;

                LogisticaDvglListadoTransportes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el listado de transportes:\n" +
                    ex.Message,
                    "Transporte Externo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Evento del DataGridView.
        // Este método está conectado desde el Designer.
        private void LogisticaDvglListadoTransportes_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            // No se necesita ejecutar ninguna acción por ahora.
        }
    }
}

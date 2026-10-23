// ============================================================================
// MÓDULO: LOGÍSTICA
// FORMULARIO: FrmMDILogistica
// DESCRIPCIÓN:
// Formulario principal del módulo de Logística, encargado de gestionar la
// navegación y el acceso a los diferentes submódulos del sistema, incluyendo
// inventario, catálogo de productos, ubicaciones, transporte, traslados,
// auditoría y cierre de inventario.
//
// Implementa métodos estandarizados para abrir formularios secundarios,
// actualizar la información del usuario activo y administrar los eventos
// de los botones del menú principal.
//
// RESPONSABLE: VELVETH SARAÍ CHAVEZ MEJÍA       0901 23 6269
// ============================================================================


using System;
using System.Windows.Forms;
using CapaVista_Inventario_Logistica.Formas;
using CapaVista_TransporteInterno_Logistica.Formas;
using CapaVista_Traslados_Logistica.Formas;
using CapaVista_MuestreoAuditoria_Logistica;
using CapaVista_CierreInventario.Forms;

namespace CapaVista_Logistica
{
    public partial class FrmMDILogistica : Form
    {
        // Constructor principal
        public FrmMDILogistica()
        {
            InitializeComponent();
        }

        // ============================================
        // MÉTODOS DEL MDI
        // ============================================

        // Actualizar información del usuario para mostrar en el formulario principal 
        // Metodo que debiamos utilizar obligatoriamente por Componente de Seguridad
        public void LogisticaMetActualizarInfoUsuario(string Nombre, string Rol)
        {
            LogisticaLblUsuario.Text = Nombre;
            LogisticaLblRolUsuario.Text = Rol;

            LogisticaLbUsuarioRol.Left = LogisticaLblUsuario.Right + 30;
        }

        // Abrir formularios secundarios
        private void LogisticaMetAbrirFormulario(
            Form Formulario)
        {
            using (Formulario)
            {
                Formulario.StartPosition = FormStartPosition.CenterParent;
                Formulario.ShowDialog(this);
            }
        }

        // ============================================
        // EVENTOS DE BOTONES
        // ============================================

        // Ubicaciones / Sucursales
        private void LogisticaBtnUbicaciones_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmMantenimientoSucursales());
        }

        // Catálogo de productos
        private void LogisticaBtnCatalogo_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmMantenimientoProducto());
        }

        // Inventario / Stock
        private void LogisticaBtnInventario_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmMantenimientoStock());
        }

        // Gestión de transporte
        private void LogisticaBtnGestionTransporte_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmSeleccionTipoTraslado());
        }

        // Traslados
        private void LogisticaBtnTraslado_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmTraslados());
        }

        // Auditoría de inventario
        private void LogisticaBtnAuditoria_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmAuditoriaInventario());
        }

        // Cierre de inventario
        private void LogisticaBtnCierredeInventario_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmCierreInventario());
        }
    }
}

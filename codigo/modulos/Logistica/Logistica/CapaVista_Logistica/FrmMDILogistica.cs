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
using CapaVista_Traslados_Logistica.Formas;
using CapaVista_MuestreoAuditoria_Logistica;
using CapaVista_CierreInventario.Forms;
using System.Drawing;

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

        private void LogisticaBtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Seguro que deseas cerrar sesión?",
        "Cerrar sesión",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ============================================
        // BOTÓN HAMBURGUESA - EXPANDIR / CONTRAER MENÚ
        // ============================================

        private void LogisticaBtnHamburguesa_Click(object sender, EventArgs e)
        {
            if (LogisticaPnlNavegador.Width == 270)
            {
                // Contraer menú lateral
                LogisticaPnlNavegador.Width = 64;

                // Reubicar panel principal
                LogisticaPnlBanner.Location = new Point(73, 34);

                // Reubicar botón hamburguesa
                LogisticaBtnHamburguesa.Location = new Point(73, 8);

                // Reubicar información del usuario
                LogisticaLblTextoUsuario.Location = new Point(128, 8);
                LogisticaLblUsuario.Location = new Point(228, 9);

                // Reubicar información del rol
                LogisticaLblTextoRol.Location = new Point(500, 9);
                LogisticaLblRolUsuario.Location = new Point(546, 9);
            }
            else
            {
                // Expandir menú lateral
                LogisticaPnlNavegador.Width = 270;

                // Restaurar panel principal
                LogisticaPnlBanner.Location = new Point(279, 34);

                // Restaurar botón hamburguesa
                LogisticaBtnHamburguesa.Location = new Point(279, 8);

                // Restaurar información del usuario
                LogisticaLblTextoUsuario.Location = new Point(334, 8);
                LogisticaLblUsuario.Location = new Point(434, 9);

                // Restaurar información del rol
                LogisticaLblTextoRol.Location = new Point(706, 9);
                LogisticaLblRolUsuario.Location = new Point(752, 9);
            }
        }
    }
}

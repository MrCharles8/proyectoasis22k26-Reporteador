
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA
 * FORMULARIO: FrmMDILogistica
 *
 * DESCRIPCIÓN:
 * Formulario principal del módulo de Logística, encargado de gestionar la
 * navegación y el acceso a los diferentes submódulos del sistema, incluyendo
 * inventario, catálogo de productos, ubicaciones, transporte, traslados,
 * auditoría y cierre de inventario.
 *
 * Implementa métodos estandarizados para abrir formularios secundarios,
 * actualizar la información del usuario activo y administrar los eventos
 * de los botones del menú principal.
 *
 * RESPONSABLE: VELVETH SARAÍ CHAVEZ MEJÍA
 * CARNÉ: 0901 23 6269
 * ============================================================================
 */

using System;
using System.Drawing;
using System.Windows.Forms;

// Formularios del módulo de Inventario.
// Namespace actualizado de Formas a Formularios.
using CapaVista_Inventario_Logistica.Formularios;

// Formularios del módulo de Traslados.
using CapaVista_Traslados_Logistica.Formularios;

// Formularios del módulo de Muestreo y Auditoría.
using CapaVista_MuestreoAuditoria_Logistica;

// Formularios del módulo de Cierre de Inventario.
using CapaVista_CierreInventario_Logistica.Formularios;

using CapaVista_Enlace_Logistica.Formas;

namespace CapaVista_Logistica
{
    public partial class FrmMDILogistica : Form
    {
        // ============================================
        // CONSTRUCTOR PRINCIPAL
        // ============================================

        public FrmMDILogistica()
        {
            InitializeComponent();
        }

        // ============================================
        // MÉTODOS DEL MDI
        // ============================================

        // Actualizar información del usuario activo.
        // Método requerido por el componente de Seguridad.
        public void LogisticaMetActualizarInfoUsuario(
            string Nombre, string Rol)
        {
            LogisticaLblUsuario.Text = Nombre;
            LogisticaLblRolUsuario.Text = Rol;

            LogisticaLbUsuarioRol.Left =
                LogisticaLblUsuario.Right + 30;
        }

        // Procedimiento para abrir formularios secundarios.
        private void LogisticaMetAbrirFormulario(Form Formulario)
        {
            using (Formulario)
            {
                Formulario.StartPosition =
                    FormStartPosition.CenterParent;

                Formulario.ShowDialog(this);
            }
        }

        // ============================================
        // EVENTOS DE BOTONES
        // ============================================

        // ============================================
        // UBICACIONES / SUCURSALES
        // ============================================

        private void LogisticaBtnUbicaciones_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmMantenimientoSucursales());
        }

        // ============================================
        // CATÁLOGO DE PRODUCTOS
        // ============================================

        private void LogisticaBtnCatalogo_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmMantenimientoProducto());
        }

        // ============================================
        // INVENTARIO / STOCK
        // ============================================

        private void LogisticaBtnInventario_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmMantenimientoStock());
        }

        // ============================================
        // GESTIÓN DE TRANSPORTE
        // ============================================

        private void LogisticaBtnGestionTransporte_Click(
            object sender, EventArgs e)
        {
            // Pendiente de integrar el formulario
            // principal de Gestión de Transporte.
        }

        // ============================================
        // TRASLADOS
        // ============================================

        private void LogisticaBtnTraslado_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmTraslados());
        }

        // ============================================
        // AUDITORÍA DE INVENTARIO
        // ============================================

        private void LogisticaBtnAuditoria_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmAuditoriaInventario());
        }

        // ============================================
        // CIERRE DE INVENTARIO
        // ============================================

        private void LogisticaBtnCierredeInventario_Click(
            object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
                new FrmCierreInventario());
        }

        // ============================================
        // CERRAR SESIÓN
        // ============================================

        private void LogisticaBtnCerrarSesion_Click(
            object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show(
                "¿Seguro que deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (Resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ============================================
        // BOTÓN HAMBURGUESA
        // EXPANDIR / CONTRAER MENÚ
        // ============================================

        private void LogisticaBtnHamburguesa_Click(
            object sender, EventArgs e)
        {
            if (LogisticaPnlNavegador.Width == 270)
            {
                // ====================================
                // CONTRAER MENÚ LATERAL
                // ====================================

                LogisticaPnlNavegador.Width = 64;

                // Reubicar panel principal.
                LogisticaPnlBanner.Location =
                    new Point(73, 34);

                // Reubicar botón hamburguesa.
                LogisticaBtnHamburguesa.Location =
                    new Point(73, 8);

                // Reubicar información del usuario.
                LogisticaLblTextoUsuario.Location =
                    new Point(128, 8);

                LogisticaLblUsuario.Location =
                    new Point(228, 9);

                // Reubicar información del rol.
                LogisticaLblTextoRol.Location =
                    new Point(500, 9);

                LogisticaLblRolUsuario.Location =
                    new Point(546, 9);
            }
            else
            {
                // ====================================
                // EXPANDIR MENÚ LATERAL
                // ====================================

                LogisticaPnlNavegador.Width = 270;

                // Restaurar panel principal.
                LogisticaPnlBanner.Location =
                    new Point(279, 34);

                // Restaurar botón hamburguesa.
                LogisticaBtnHamburguesa.Location =
                    new Point(279, 8);

                // Restaurar información del usuario.
                LogisticaLblTextoUsuario.Location =
                    new Point(334, 8);

                LogisticaLblUsuario.Location =
                    new Point(434, 9);

                // Restaurar información del rol.
                LogisticaLblTextoRol.Location =
                    new Point(706, 9);

                LogisticaLblRolUsuario.Location =
                    new Point(752, 9);
            }
        }

        private void LogisticaBtnEnlace_Click(object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(
               new Frm_Solicitud_Pago());
        }
    }
}

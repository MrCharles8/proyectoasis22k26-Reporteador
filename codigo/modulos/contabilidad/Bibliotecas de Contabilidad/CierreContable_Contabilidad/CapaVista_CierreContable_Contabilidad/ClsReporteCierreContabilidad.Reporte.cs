/*
 * ==================================================================
 * Área : Contabilidad
 * Autor : Gabriel André Guillén Pocón
 * Carné : 0901-23-1998
 * Fecha : 14/11/2026
 * ==================================================================
 * Propósito :
 *  Entrega al MDI la ventana del reporte de cierre contable.
 * ===================================================================
*/

using System.Windows.Forms;
using CapaControlador_Contabilidad;

namespace CapaVista_Contabilidad
{
    // conexión del reporte con el MDI
    public static partial class ClsReporteCierreContabilidad
    {
        // crea la ventana del reporte
        static partial void ContabilidadMetCrearReporte(ClsModeloPermisosPantallaContabilidad Permisos, ref Form Formulario)
        {
            Formulario = new FrmReporteCierreContable(Permisos);
        }
    }
}

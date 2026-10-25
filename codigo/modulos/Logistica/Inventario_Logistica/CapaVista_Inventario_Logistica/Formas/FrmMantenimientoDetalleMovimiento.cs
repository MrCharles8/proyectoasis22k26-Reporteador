/*
 * Autor: José Xavier Bolaños Tenas
 * Carné: 0901-23-2128
 * Descripción: Configura el formulario de mantenimiento para los detalles de movimientos de inventario.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Inventario_Logistica.Formas
{
    public partial class FrmMantenimientoDetalleMovimiento : Form
    {
        public FrmMantenimientoDetalleMovimiento()
        {
            InitializeComponent();
            LogisticaNavDetalleMovimiento.NavegadorMetConfigurar("tbldetallemovimiento", 4, 6);
        }
    }
}

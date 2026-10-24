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
    public partial class FrmMantenimientoStock : Form
    {
        public FrmMantenimientoStock()
        {
            InitializeComponent();
        }

        private void LogisticaMetAbrirFormulario(
         Form Formulario)
        {
            using (Formulario)
            {
                Formulario.StartPosition = FormStartPosition.CenterParent;
                Formulario.ShowDialog(this);
            }
        }

        private void LogisticaBtnMovimientoInventario_Click(object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmMantenimientoMovimientoInventario());

        }

        private void LogisticaBtnDetalleMovimiento_Click(object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmMantenimientoDetalleMovimiento());

        }

        private void LogisticaBtnTipoMovimiento_Click(object sender, EventArgs e)
        {
            LogisticaMetAbrirFormulario(new FrmMantenimientoTipoMovimiento());

        }
    }
}

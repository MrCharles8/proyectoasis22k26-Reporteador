using System;
using System.Windows.Forms;

namespace CapaVista_Inventario_Logistica.Formas
{
    public partial class FrmMantenimientoProducto : Form
    {
        public FrmMantenimientoProducto()
        {
            InitializeComponent();
            LogisticaNavProducto.NavegadorMetConfigurar("tblProducto", 4, 6);
        }

        private void LogisticaProcAbrirMantenimientoCategoria()
        {
            using (FrmMantenimientoCategoria FrmCategoria = new FrmMantenimientoCategoria())
            {
                FrmCategoria.ShowDialog(this);
            }
        }

        private void LogisticaBtnCategoria_Click(object sender, EventArgs e)
        {
            LogisticaProcAbrirMantenimientoCategoria();
        }

        private void LogisticaProcAbrirMantenimientoMarca()
        {
            using (FrmMantenimientoMarca FrmMarca = new FrmMantenimientoMarca())
            {
                FrmMarca.ShowDialog(this);
            }
        }

        private void LogisticaBtnMarca_Click(object sender, EventArgs e)
        {
            LogisticaProcAbrirMantenimientoMarca();
        }

        private void LogisticaProcAbrirMantenimientoLinea()
        {
            using (FrmMantenimientoLinea FrmLinea = new FrmMantenimientoLinea())
            {
                FrmLinea.ShowDialog(this);
            }
        }

        private void LogisticaBtnLinea_Click(object sender, EventArgs e)
        {
            LogisticaProcAbrirMantenimientoLinea();
        }
    }
}

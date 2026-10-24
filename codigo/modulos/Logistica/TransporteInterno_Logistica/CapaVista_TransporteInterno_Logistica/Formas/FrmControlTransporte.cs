using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_TransporteInterno_Logistica.Formas
{
    public partial class FrmControlTransporte : Form
    {
        public FrmControlTransporte()
        {
            InitializeComponent();

            LogisticaNavTransporteInterno.NavegadorMetConfigurar("tblTelemetriaTemperatura", 4, 6);
        }

        private void txtObservacionesInspeccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogisticaNavTransporteInterno_Load(object sender, EventArgs e)
        {

        }

        private void FrmControlTransporte_Load(object sender, EventArgs e)
        {

        }
    }
}

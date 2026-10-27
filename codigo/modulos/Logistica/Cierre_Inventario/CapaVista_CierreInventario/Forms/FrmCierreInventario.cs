/*
*Responsable: Nills Berducido Gómez
* Carne: 0901 23 14275

*Descripción:
*Formulario de cierre de inventario
* permite realizar el cierre mensual validando los datos que se tienen

* Fecha: 26 / 10 / 2026
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

namespace CapaVista_CierreInventario.Forms
{
    public partial class FrmCierreInventario : Form
    {
        public FrmCierreInventario()
        {
            InitializeComponent();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            FrmConsultaCierres frmConsultas = new FrmConsultaCierres();
            frmConsultas.ShowDialog();
        }
    }
    
}

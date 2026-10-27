/*Responsable: Carlos Eduardo Chin Caal
* Carne: 0901-23-5686

*Descripción:
Formulario de mantenimiento de marca
permite ingresar, guardar, modificar y eliminar marcas de productos en el sistema
a traves del navegador incluyendo la funcionalidad de busqueda y
filtrado de registros.

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

namespace CapaVista_Inventario_Logistica.Formas
{
    public partial class FrmMantenimientoMarca : Form
    {
        public FrmMantenimientoMarca()
        {
            InitializeComponent();
            LogisticaNavMarca.NavegadorMetConfigurar("tblmarca", 4, 6);
        }

    }
}

/*
 * Responsable: Velveth Saraì Chavez Mejìa
 * Carne: 0901 23 6269  
 * 
 * Descripción: 
 * Formulario de mantenimiento de bodegas,
 * permite ingresar, guardar, modificar y eliminar bodegas en el sistema
 * a traves del navegador incluyendo la funcionalidad de busqueda y 
 * filtrado de registros.
 * 
 * Fecha: 25/10/2026
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
    public partial class FrmMantenimientoBodegas : Form
    {
        public FrmMantenimientoBodegas()
        {
            InitializeComponent();

            LogisticaNavBodega.NavegadorMetConfigurar("tblBodega", 4, 6);
        }

        
    }
}

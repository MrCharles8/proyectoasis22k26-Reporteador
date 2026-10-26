/*
 * Responsable: Velveth Saraì Chavez Mejìa
 * Carne: 0901 23 6269  
 * 
 * Descripción: 
 * Formulario de mantenimiento de sucursales,
 * permite ingresar, guardar, modificar y eliminar sucursales en el sistema
 * a traves del navegador incluyendo la funcionalidad de busqueda y 
 * filtrado de registros.
 * 
 * Fecha: 25/10/2024
 */



using CapaVista_Navegador;
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
    public partial class FrmMantenimientoSucursales : Form
    {
        public FrmMantenimientoSucursales()
        {
            InitializeComponent();
            LogisticaNavSucursales.NavegadorMetConfigurar("tblSucursal", 4, 6);
        }

        private void LogisticaProcAbrirMantenimientoBodegas()
        {
            using (FrmMantenimientoBodegas FrmBodega = new FrmMantenimientoBodegas())
            {
                FrmBodega.ShowDialog(this);
            }
        }

        private void LogisticaBtnBodega_Click(object sender, EventArgs e)
        {
               LogisticaProcAbrirMantenimientoBodegas();
        }
    }
}
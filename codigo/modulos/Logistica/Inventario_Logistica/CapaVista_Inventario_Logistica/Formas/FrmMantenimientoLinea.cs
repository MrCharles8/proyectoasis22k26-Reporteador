/*
 * Responsable: Nills Berducido Gómez
 * Carne: 0901 23 14275  
 * 
 * Descripción: 
 * Formulario de mantenimiento linea
 * Permite ingresar, guardar, modificar y eliminar lineas en el sistema
 * 
 * Fecha: 26/10/2026
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
    public partial class FrmMantenimientoLinea : Form
    {
        public FrmMantenimientoLinea()
        {
            InitializeComponent();

            LogisticaNavLinea.NavegadorMetConfigurar("tblLinea", 4, 6);
        }

    }
}

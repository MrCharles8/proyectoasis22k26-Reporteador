/*
 * Responsable: Nills Berducido Gómez
 * Carne: 0901 23 14275  
 * 
 * Descripción: 
 * Formulario de mantenimiento categoria 
 * Permite ingresar, guardar, modificar y eliminar categorias en el sistema
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
    public partial class FrmMantenimientoCategoria : Form
    {
        public FrmMantenimientoCategoria()
        {
            InitializeComponent();

            LogisticaNavCategoria.NavegadorMetConfigurar("tblCategoria", 4, 6);
        }

     
    }
}

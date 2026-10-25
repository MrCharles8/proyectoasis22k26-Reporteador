using CapaControlador_Inventario_Logistica.Modelos_de_Controladores;
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
    public partial class FrmMantenimientoTipoMovimiento : Form
    {
        /*ClsModelosTipoMovimiento _Datos = new ClsModelosTipoMovimiento();*/
        /* Dictionary<string, object> _Fuentes = new Dictionary<string, object>();*/
        public FrmMantenimientoTipoMovimiento()
        {
            InitializeComponent();
            /*_Fuentes.Add("DsMantenimientoTipoMovimiento", _Datos.LogisticaMetObtenerTodos());*/
            /* LogisticaNavTipoMovimiento.NavegadorMetConfigurar("tblTipoMovimiento", 4, 6 , _Fuentes); */
            LogisticaNavTipoMovimiento.NavegadorMetConfigurar("tbltipomovimiento", 4, 6);
        }
    }
}

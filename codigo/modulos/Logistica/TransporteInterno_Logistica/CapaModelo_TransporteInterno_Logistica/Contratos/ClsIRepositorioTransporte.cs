using CapaModelo_TransporteInterno_Logistica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_TransporteInterno_Logistica.Contratos
{
    public interface ClsIRepositorioTransporte
    {
        IEnumerable<ClsTransporte> LogisticaMetObtenerTodos();
    }
}

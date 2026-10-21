// Autor: José Xavier Bolaños Tenas, carné 0901-23-2128.
// Propósito: proporcionar la conexión ODBC común a los repositorios del modelo.

using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_Traslados_Logistica.Repositorios
{
    public class ClsRepositorio
    {
        private readonly string _CadenaConexion;

        // Inicializa la cadena de conexión ODBC utilizada por el repositorio.
        protected ClsRepositorio()
        {
            _CadenaConexion = "Dsn=EmbutidosS.A";
        }

        // Crea y devuelve una conexión ODBC para ejecutar operaciones de datos.
        protected OdbcConnection LogisticaMetObtenerConexion()
        {
            return new OdbcConnection(_CadenaConexion);
        }
    }
}

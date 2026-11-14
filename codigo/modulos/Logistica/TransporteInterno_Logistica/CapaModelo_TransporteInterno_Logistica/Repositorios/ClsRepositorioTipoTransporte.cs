using CapaModelo_TransporteInterno_Logistica.Contratos;
using CapaModelo_TransporteInterno_Logistica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_TransporteInterno_Logistica.Repositorios
{
    public class ClsRepositorioTipoTransporte
        : ClsIRepositorioTipoTransporte
    {
        private readonly string _SelectAll;

        public ClsRepositorioTipoTransporte()
        {
            _SelectAll =
                "SELECT " +
                "idTipoTransporte AS IdTipoTransporte, " +
                "nombreTipoTransporte AS NombreTipoTransporte, " +
                "created_at AS CreatedAt, " +
                "updated_at AS UpdatedAt " +
                "FROM tblTipoTransporte " +
                "ORDER BY idTipoTransporte";
        }

        // =====================================================
        // OBTENER TODOS LOS REGISTROS
        // =====================================================

        public IEnumerable<ClsTipoTransporte>
            LogisticaMetObtenerTodos()
        {
            var ListaTipos = new List<ClsTipoTransporte>();

            DataTable TablaDatos = new DataTable();

            using (OdbcConnection Conexion =
                new OdbcConnection("DSN=EmbutidosS.A;"))
            {
                using (OdbcDataAdapter Adaptador =
                    new OdbcDataAdapter(_SelectAll, Conexion))
                {
                    Adaptador.Fill(TablaDatos);
                }
            }

            foreach (DataRow Fila in TablaDatos.Rows)
            {
                var Tipo = new ClsTipoTransporte
                {
                    IdTipoTransporte =
                        Convert.ToInt32(
                            Fila["IdTipoTransporte"]),

                    NombreTipoTransporte =
                        Convert.ToString(
                            Fila["NombreTipoTransporte"]),

                    CreatedAt =
                        Convert.ToDateTime(
                            Fila["CreatedAt"]),

                    UpdatedAt =
                        Convert.ToDateTime(
                            Fila["UpdatedAt"])
                };

                ListaTipos.Add(Tipo);
            }

            return ListaTipos;
        }
    }
}

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
    public class ClsRepositorioTransporte
        : ClsIRepositorioTransporte
    {
        private readonly string _SelectAll;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ClsRepositorioTransporte()
        {
            _SelectAll =
                "SELECT " +
                "idTransporte AS IdTransporte, " +
                "nroPlacaTransporte AS NroPlacaTransporte, " +
                "marcaTransporte AS MarcaTransporte, " +
                "modeloTransporte AS ModeloTransporte, " +
                "anioTransporte AS AnioTransporte, " +
                "esRefrigeradoTransporte AS EsRefrigeradoTransporte, " +
                "Fk_Estado_Codigo AS FkEstadoCodigo, " +
                "Fk_Tipo_Transporte_Codigo AS FkTipoTransporteCodigo, " +
                "created_at AS CreatedAt, " +
                "updated_at AS UpdatedAt " +
                "FROM tblTransporte " +
                "ORDER BY idTransporte";
        }

        // =====================================================
        // OBTENER TODOS LOS TRANSPORTES
        // =====================================================

        public IEnumerable<ClsTransporte>
            LogisticaMetObtenerTodos()
        {
            var ListaTransportes = new List<ClsTransporte>();

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
                var Transporte = new ClsTransporte
                {
                    IdTransporte =
                        Convert.ToInt32(Fila["IdTransporte"]),

                    NroPlacaTransporte =
                        Convert.ToString(Fila["NroPlacaTransporte"]),

                    MarcaTransporte =
                        Convert.ToString(Fila["MarcaTransporte"]),

                    ModeloTransporte =
                        Convert.ToString(Fila["ModeloTransporte"]),

                    AnioTransporte =
                        Convert.ToInt32(Fila["AnioTransporte"]),

                    EsRefrigeradoTransporte =
                        Convert.ToBoolean(Fila["EsRefrigeradoTransporte"]),

                    FkEstadoCodigo =
                        Convert.ToInt32(Fila["FkEstadoCodigo"]),

                    FkTipoTransporteCodigo =
                        Convert.ToInt32(Fila["FkTipoTransporteCodigo"]),

                    CreatedAt =
                        Convert.ToDateTime(Fila["CreatedAt"]),

                    UpdatedAt =
                        Convert.ToDateTime(Fila["UpdatedAt"])
                };

                ListaTransportes.Add(Transporte);
            }

            return ListaTransportes;
        }
    }
}

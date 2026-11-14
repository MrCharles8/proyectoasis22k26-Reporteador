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
    public class ClsRepositorioCamaraRefrigeracion
        : ClsIRepositorioCamaraRefrigeracion
    {
        private readonly string _SelectAll;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ClsRepositorioCamaraRefrigeracion()
        {
            _SelectAll =
                "SELECT " +
                "idCamaraRefrigeracion AS IdCamaraRefrigeracion, " +
                "Fk_Transporte_Codigo AS FkTransporteCodigo, " +
                "marcaEquipoCamaraRefrigeracion AS MarcaEquipoCamaraRefrigeracion, " +
                "tempMinimaCelsiusCamaraRefrigeracion AS TempMinimaCelsiusCamaraRefrigeracion, " +
                "tempMaximaCelsiusCamaraRefrigeracion AS TempMaximaCelsiusCamaraRefrigeracion, " +
                "estadoOperativoCamaraRefrigeracion AS EstadoOperativoCamaraRefrigeracion, " +
                "created_at AS CreatedAt, " +
                "updated_at AS UpdatedAt " +
                "FROM tblCamaraRefrigeracion " +
                "ORDER BY idCamaraRefrigeracion";
        }

        // =====================================================
        // CONSULTAR TODAS LAS CÁMARAS
        // =====================================================

        public IEnumerable<ClsCamaraRefrigeracion>
            LogisticaMetObtenerTodos()
        {
            var ListaCamaras =
                new List<ClsCamaraRefrigeracion>();

            DataTable TablaDatos = new DataTable();

            using (var Conexion =
                new OdbcConnection("DSN=EmbutidosS.A;"))
            {
                using (var Adaptador =
                    new OdbcDataAdapter(_SelectAll, Conexion))
                {
                    Adaptador.Fill(TablaDatos);
                }
            }

            foreach (DataRow Fila in TablaDatos.Rows)
            {
                var Camara = new ClsCamaraRefrigeracion
                {
                    IdCamaraRefrigeracion =
                        Convert.ToInt32(
                            Fila["IdCamaraRefrigeracion"]),

                    FkTransporteCodigo =
                        Convert.ToInt32(
                            Fila["FkTransporteCodigo"]),

                    MarcaEquipoCamaraRefrigeracion =
                        Convert.ToString(
                            Fila["MarcaEquipoCamaraRefrigeracion"]),

                    TempMinimaCelsiusCamaraRefrigeracion =
                        Convert.ToDecimal(
                            Fila["TempMinimaCelsiusCamaraRefrigeracion"]),

                    TempMaximaCelsiusCamaraRefrigeracion =
                        Convert.ToDecimal(
                            Fila["TempMaximaCelsiusCamaraRefrigeracion"]),

                    EstadoOperativoCamaraRefrigeracion =
                        Convert.ToString(
                            Fila["EstadoOperativoCamaraRefrigeracion"]),

                    CreatedAt =
                        Convert.ToDateTime(Fila["CreatedAt"]),

                    UpdatedAt =
                        Convert.ToDateTime(Fila["UpdatedAt"])
                };

                ListaCamaras.Add(Camara);
            }

            return ListaCamaras;
        }
    }
}

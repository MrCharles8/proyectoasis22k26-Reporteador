using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_TransporteInterno_Logistica.Entidades;
using CapaModelo_TransporteInterno_Logistica.Repositorios;

namespace CapaControlador_TransporteInterno_Logistica.Modelos_de_Controladores
{
    public class ClsModeloTransporte
    {
        // =====================================================
        // REPOSITORIO
        // =====================================================

        private readonly ClsRepositorioTransporte
            _RepositorioTransporte;

        // =====================================================
        // PROPIEDADES DEL MODELO
        // =====================================================

        public int IdTransporte { get; set; }

        public string NroPlacaTransporte { get; set; }

        public string MarcaTransporte { get; set; }

        public string ModeloTransporte { get; set; }

        public int AnioTransporte { get; set; }

        public bool EsRefrigeradoTransporte { get; set; }

        public int FkEstadoCodigo { get; set; }

        public int FkTipoTransporteCodigo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ClsModeloTransporte()
        {
            _RepositorioTransporte =
                new ClsRepositorioTransporte();
        }

        // =====================================================
        // OBTENER TODOS LOS TRANSPORTES
        // =====================================================

        public List<ClsModeloTransporte>
            LogisticaMetObtenerTodos()
        {
            var ResultadoConsulta =
                _RepositorioTransporte.LogisticaMetObtenerTodos();

            var ListaTransportes =
                new List<ClsModeloTransporte>();

            foreach (ClsTransporte Item in ResultadoConsulta)
            {
                ListaTransportes.Add(new ClsModeloTransporte
                {
                    IdTransporte =
                        Item.IdTransporte,

                    NroPlacaTransporte =
                        Item.NroPlacaTransporte,

                    MarcaTransporte =
                        Item.MarcaTransporte,

                    ModeloTransporte =
                        Item.ModeloTransporte,

                    AnioTransporte =
                        Item.AnioTransporte,

                    EsRefrigeradoTransporte =
                        Item.EsRefrigeradoTransporte,

                    FkEstadoCodigo =
                        Item.FkEstadoCodigo,

                    FkTipoTransporteCodigo =
                        Item.FkTipoTransporteCodigo,

                    CreatedAt =
                        Item.CreatedAt,

                    UpdatedAt =
                        Item.UpdatedAt
                });
            }

            return ListaTransportes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_TransporteInterno_Logistica.Entidades;
using CapaModelo_TransporteInterno_Logistica.Repositorios;

namespace CapaControlador_TransporteInterno_Logistica.Modelos_de_Controladores
{
    public class ClsModeloTipoTransporte
    {
        // =====================================================
        // REPOSITORIO
        // =====================================================

        private readonly ClsRepositorioTipoTransporte
            _RepositorioTipoTransporte;

        // =====================================================
        // PROPIEDADES
        // =====================================================

        public int IdTipoTransporte { get; set; }

        public string NombreTipoTransporte { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ClsModeloTipoTransporte()
        {
            _RepositorioTipoTransporte =
                new ClsRepositorioTipoTransporte();
        }

        // =====================================================
        // OBTENER TODOS LOS TIPOS DE TRANSPORTE
        // =====================================================

        public List<ClsModeloTipoTransporte>
            LogisticaMetObtenerTodos()
        {
            var ResultadoConsulta =
                _RepositorioTipoTransporte.LogisticaMetObtenerTodos();

            var ListaTipos =
                new List<ClsModeloTipoTransporte>();

            foreach (ClsTipoTransporte Item in ResultadoConsulta)
            {
                ListaTipos.Add(new ClsModeloTipoTransporte
                {
                    IdTipoTransporte =
                        Item.IdTipoTransporte,

                    NombreTipoTransporte =
                        Item.NombreTipoTransporte,

                    CreatedAt =
                        Item.CreatedAt,

                    UpdatedAt =
                        Item.UpdatedAt
                });
            }

            return ListaTipos;
        }
    }
}

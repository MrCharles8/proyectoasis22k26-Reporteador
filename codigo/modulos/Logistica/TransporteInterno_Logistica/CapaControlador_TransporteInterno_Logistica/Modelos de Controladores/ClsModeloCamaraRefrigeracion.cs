using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_TransporteInterno_Logistica.Entidades;
using CapaModelo_TransporteInterno_Logistica.Repositorios;
using CapaModelo_TransporteInterno_Logistica.Contratos;

namespace CapaControlador_TransporteInterno_Logistica.Modelos_de_Controladores
{
    public class ClsModeloCamaraRefrigeracion
    {
        private readonly ClsIRepositorioCamaraRefrigeracion
            _RepositorioCamara;

        // =====================================================
        // PROPIEDADES DEL MODELO
        // =====================================================

        public int IdCamaraRefrigeracion { get; set; }

        public int FkTransporteCodigo { get; set; }

        public string MarcaEquipoCamaraRefrigeracion
        {
            get;
            set;
        }

        public decimal TempMinimaCelsiusCamaraRefrigeracion
        {
            get;
            set;
        }

        public decimal TempMaximaCelsiusCamaraRefrigeracion
        {
            get;
            set;
        }

        public string EstadoOperativoCamaraRefrigeracion
        {
            get;
            set;
        }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public ClsModeloCamaraRefrigeracion()
        {
            _RepositorioCamara =
                new ClsRepositorioCamaraRefrigeracion();
        }

        // =====================================================
        // OBTENER TODAS LAS CÁMARAS
        // =====================================================

        public List<ClsModeloCamaraRefrigeracion>
            LogisticaMetObtenerTodos()
        {
            var ResultadoConsulta =
                _RepositorioCamara.LogisticaMetObtenerTodos();

            var ListaCamaras =
                new List<ClsModeloCamaraRefrigeracion>();

            foreach (ClsCamaraRefrigeracion Item
                in ResultadoConsulta)
            {
                ListaCamaras.Add(
                    new ClsModeloCamaraRefrigeracion
                    {
                        IdCamaraRefrigeracion =
                            Item.IdCamaraRefrigeracion,

                        FkTransporteCodigo =
                            Item.FkTransporteCodigo,

                        MarcaEquipoCamaraRefrigeracion =
                            Item.MarcaEquipoCamaraRefrigeracion,

                        TempMinimaCelsiusCamaraRefrigeracion =
                            Item.TempMinimaCelsiusCamaraRefrigeracion,

                        TempMaximaCelsiusCamaraRefrigeracion =
                            Item.TempMaximaCelsiusCamaraRefrigeracion,

                        EstadoOperativoCamaraRefrigeracion =
                            Item.EstadoOperativoCamaraRefrigeracion,

                        CreatedAt = Item.CreatedAt,

                        UpdatedAt = Item.UpdatedAt
                    });
            }

            return ListaCamaras;
        }
    }
}

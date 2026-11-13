
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsModeloLinea.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Coordina la consulta de líneas de productos
 * entre la Capa Modelo y la Capa Vista.
 *
 * Obtiene los registros desde el repositorio
 * y los convierte en objetos ClsModeloLinea,
 * cuyas propiedades se utilizan directamente
 * como campos del DataSet del reporte RDLC.
 *
 * Implementa la arquitectura MVC de Logística.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Linq;

using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Repositorios;

namespace CapaControlador_Inventario_Logistica.Modelos_de_Controladores
{
    public class ClsModeloLinea
    {
        // ========================================================
        // REPOSITORIO
        // ========================================================

        private readonly ClsIRepositorioLinea _Repositorio;

        // ========================================================
        // PROPIEDADES PARA EL REPORTE RDLC
        // ========================================================

        public int IdLinea { get; set; }

        public string NombreLinea { get; set; }

        public decimal PorcentajeComisionLinea { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        // ========================================================
        // CONSTRUCTOR PRINCIPAL
        // ========================================================

        public ClsModeloLinea()
        {
            _Repositorio = new ClsRepositorioLinea();
        }

        // ========================================================
        // CONSTRUCTOR PARA PRUEBAS UNITARIAS
        // ========================================================

        public ClsModeloLinea(
            ClsIRepositorioLinea Repositorio)
        {
            if (Repositorio == null)
            {
                throw new ArgumentNullException(
                    nameof(Repositorio));
            }

            _Repositorio = Repositorio;
        }

        // ========================================================
        // OBTENER TODOS LOS REGISTROS
        // ========================================================

        public List<ClsModeloLinea> LogisticaMetObtenerTodos()
        {
            return _Repositorio
                .LogisticaMetObtenerTodos()
                .Select(L => new ClsModeloLinea
                {
                    IdLinea = L.IdLinea,

                    NombreLinea = L.NombreLinea,

                    PorcentajeComisionLinea =
                        L.PorcentajeComisionLinea,

                    FechaCreacion = L.CreatedAt,

                    FechaActualizacion = L.UpdatedAt
                })
                .ToList();
        }
    }
}

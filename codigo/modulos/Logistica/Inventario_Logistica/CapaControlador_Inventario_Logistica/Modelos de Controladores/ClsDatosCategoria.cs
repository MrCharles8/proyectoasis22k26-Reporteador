
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsDatosCategoria.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Define la estructura de los datos utilizados entre
 * el Controlador y la Vista para generar el reporte
 * de categorías.
 *
 * Contiene las propiedades que serán utilizadas
 * como campos del conjunto de datos DsReporteCategoria
 * dentro del archivo RDLC.
 * ============================================================================
 */

using System;

namespace CapaControlador_Inventario_Logistica.Modelos_de_Controladores
{
    public class ClsDatosCategoria
    {
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        public decimal PorcentajeComisionCategoria
        {
            get;
            set;
        }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}

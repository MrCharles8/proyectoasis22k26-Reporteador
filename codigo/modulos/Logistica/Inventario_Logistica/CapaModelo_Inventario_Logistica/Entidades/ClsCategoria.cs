
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsCategoria.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Representa los datos de las categorías de productos
 * registradas en el sistema ERP. Contiene las propiedades
 * correspondientes al identificador, nombre, porcentaje
 * de comisión y fechas de creación y actualización.
 *
 * Esta entidad permite transportar información entre
 * el repositorio y el controlador del módulo Logística.
 * ============================================================================
 */

using System;

namespace CapaModelo_Inventario_Logistica.Entidades
{
    public class ClsCategoria
    {
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        public decimal PorcentajeComisionCategoria
        {
            get;
            set;
        }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}


/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsLinea.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Representa los datos de las líneas de productos
 * almacenadas en tblLinea.
 *
 * Contiene el identificador, nombre, porcentaje de
 * comisión y fechas de creación y actualización,
 * permitiendo transportar información desde la
 * Capa Modelo hacia el Controlador.
 * ============================================================================
 */

using System;

namespace CapaModelo_Inventario_Logistica.Entidades
{
    public class ClsLinea
    {
        public int IdLinea { get; set; }

        public string NombreLinea { get; set; }

        public decimal PorcentajeComisionLinea { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

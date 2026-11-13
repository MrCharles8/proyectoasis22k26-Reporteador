
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsIRepositorioLinea.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Define el contrato para consultar las líneas de
 * productos almacenadas en la base de datos.
 *
 * Establece las operaciones que debe implementar
 * el repositorio y permite separar las responsabilidades
 * entre la Capa Modelo y el Controlador.
 * ============================================================================
 */

using System.Collections.Generic;

using CapaModelo_Inventario_Logistica.Entidades;

namespace CapaModelo_Inventario_Logistica.Contratos
{
    public interface ClsIRepositorioLinea
    {
        // ========================================================
        // OBTENER TODOS LOS REGISTROS
        // ========================================================

        IEnumerable<ClsLinea> LogisticaMetObtenerTodos();
    }
}


/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsIRepositorioCategoria.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Define el contrato de acceso a los datos de categorías.
 * Establece los métodos que debe implementar el
 * repositorio para consultar la información almacenada
 * en la tabla tblCategoria.
 *
 * Facilita la separación de responsabilidades entre
 * las capas Modelo y Controlador.
 * ============================================================================
 */

using System.Collections.Generic;

using CapaModelo_Inventario_Logistica.Entidades;

namespace CapaModelo_Inventario_Logistica.Contratos
{
    public interface ClsIRepositorioCategoria
    {
        IEnumerable<ClsCategoria>
            LogisticaMetObtenerTodos();
    }
}

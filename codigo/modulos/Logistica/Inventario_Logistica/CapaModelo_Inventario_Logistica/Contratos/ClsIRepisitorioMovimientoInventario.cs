
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsIRepositorioMovimientoInventario.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Define las operaciones de registro, modificación,
 * eliminación y consulta de movimientos de inventario,
 * así como las consultas de catálogos relacionados.
 * ============================================================================
 */

using System;
using System.Collections.Generic;

using CapaModelo_Inventario_Logistica.Entidades;

namespace CapaModelo_Inventario_Logistica.Contratos
{
    public interface ClsIRepositorioMovimientoInventario
    {
        int LogisticaMetAgregar(
            ClsMovimientoInventario Entidad);

        int LogisticaMetEditar(
            ClsMovimientoInventario Entidad);

        int LogisticaMetEliminar(int IdMovimiento);

        IEnumerable<ClsMovimientoInventario>
            LogisticaMetObtenerTodos();

        IEnumerable<ClsCatalogo>
            LogisticaMetObtenerTipos();

        IEnumerable<ClsCatalogo>
            LogisticaMetObtenerSucursales();

        IEnumerable<ClsCatalogo>
            LogisticaMetObtenerBodegas(int IdSucursal);

        IEnumerable<ClsCatalogo>
            LogisticaMetObtenerTransportes();

        Tuple<string, string>
            LogisticaMetObtenerTipo(int IdTipo);
    }
}

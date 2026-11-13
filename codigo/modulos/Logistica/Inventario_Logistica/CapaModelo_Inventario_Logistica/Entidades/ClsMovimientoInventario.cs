
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsMovimientoInventario.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Representa el encabezado de los movimientos de
 * inventario y sus relaciones con tipos de movimiento,
 * sucursales, bodegas y transportes.
 * También contiene los nombres para las consultas.
 * ============================================================================
 */

using System;

namespace CapaModelo_Inventario_Logistica.Entidades
{
    public class ClsMovimientoInventario
    {
        public int IdMovimientoInventario { get; set; }
        public int FkTipoMovimientoCodigo { get; set; }

        public int? FkSucursalOrigenCodigo { get; set; }
        public int? FkBodegaOrigenCodigo { get; set; }

        public int? FkSucursalDestinoCodigo { get; set; }
        public int? FkBodegaDestinoCodigo { get; set; }

        public int? FkTransporteCodigo { get; set; }

        public DateTime FechaMovimientoInventario { get; set; }

        public string ObservacionesMovimientoInventario
        {
            get;
            set;
        }

        public string EstadoMovimientoInventario
        {
            get;
            set;
        }

        // Datos para las consultas y reportes.

        public string NombreTipoMovimiento { get; set; }
        public string SignoTipoMovimiento { get; set; }

        public string NombreSucursalOrigen { get; set; }
        public string NombreBodegaOrigen { get; set; }

        public string NombreSucursalDestino { get; set; }
        public string NombreBodegaDestino { get; set; }

        public string NombreTransporte { get; set; }
    }
}

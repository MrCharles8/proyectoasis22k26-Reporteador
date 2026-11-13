
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsModeloMovimientoInventario.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Controla las operaciones de movimientos de inventario.
 * Valida los datos, administra las consultas y comunica
 * la Capa Vista con el repositorio correspondiente.
 *
 * Proporciona los datos para el DataGridView y el
 * reporte RpReporteMovimientoInventario.rdlc.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Linq;

using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Entidades;
using CapaModelo_Inventario_Logistica.Repositorios;

namespace CapaControlador_Inventario_Logistica.Modelos_de_Controladores
{
    public class ClsModeloMovimientoInventario
    {
        private readonly ClsIRepositorioMovimientoInventario _Repositorio;

        // ========================================================
        // PROPIEDADES DEL MOVIMIENTO
        // ========================================================

        public int IdMovimientoInventario { get; set; }
        public int FkTipoMovimientoCodigo { get; set; }

        public int? FkSucursalOrigenCodigo { get; set; }
        public int? FkBodegaOrigenCodigo { get; set; }

        public int? FkSucursalDestinoCodigo { get; set; }
        public int? FkBodegaDestinoCodigo { get; set; }

        public int? FkTransporteCodigo { get; set; }

        public DateTime FechaMovimientoInventario { get; set; }

        public string ObservacionesMovimientoInventario { get; set; }
        public string EstadoMovimientoInventario { get; set; }

        // ========================================================
        // PROPIEDADES PARA CONSULTAS Y REPORTE RDLC
        // ========================================================

        public string NombreTipoMovimiento { get; set; }
        public string SignoTipoMovimiento { get; set; }

        public string NombreSucursalOrigen { get; set; }
        public string NombreBodegaOrigen { get; set; }

        public string NombreSucursalDestino { get; set; }
        public string NombreBodegaDestino { get; set; }

        public string NombreTransporte { get; set; }

        // ========================================================
        // CONSTRUCTORES
        // ========================================================

        public ClsModeloMovimientoInventario()
        {
            _Repositorio = new ClsRepositorioMovimientoInventario();
        }

        public ClsModeloMovimientoInventario(
            ClsIRepositorioMovimientoInventario Repositorio)
        {
            if (Repositorio == null)
                throw new ArgumentNullException(nameof(Repositorio));

            _Repositorio = Repositorio;
        }

        // ========================================================
        // VALIDACIÓN DE MOVIMIENTOS
        // ========================================================

        private void LogisticaProcValidarMovimiento(
            ClsModeloMovimientoInventario D)
        {
            if (D == null || D.FkTipoMovimientoCodigo <= 0)
                throw new ArgumentException(
                    "Seleccione un tipo de movimiento válido.");

            if (string.IsNullOrWhiteSpace(
                D.ObservacionesMovimientoInventario))
                throw new ArgumentException(
                    "Ingrese las observaciones del movimiento.");

            if (D.ObservacionesMovimientoInventario.Length > 500)
                throw new ArgumentException(
                    "Las observaciones no pueden superar 500 caracteres.");

            // La sucursal y su bodega deben seleccionarse juntas.
            if (D.FkSucursalOrigenCodigo.HasValue !=
                D.FkBodegaOrigenCodigo.HasValue)
                throw new ArgumentException(
                    "Seleccione sucursal y bodega de origen juntas.");

            if (D.FkSucursalDestinoCodigo.HasValue !=
                D.FkBodegaDestinoCodigo.HasValue)
                throw new ArgumentException(
                    "Seleccione sucursal y bodega de destino juntas.");

            bool Origen = D.FkSucursalOrigenCodigo.HasValue &&
                          D.FkBodegaOrigenCodigo.HasValue;

            bool Destino = D.FkSucursalDestinoCodigo.HasValue &&
                           D.FkBodegaDestinoCodigo.HasValue;

            Tuple<string, string> Tipo =
                _Repositorio.LogisticaMetObtenerTipo(
                    D.FkTipoMovimientoCodigo);

            if (Tipo == null)
                throw new ArgumentException(
                    "El tipo de movimiento seleccionado no existe.");

            bool Traslado = Tipo.Item1.IndexOf(
                "Traslado",
                StringComparison.OrdinalIgnoreCase) >= 0;

            if (Traslado)
            {
                if (!Origen || !Destino)
                    throw new ArgumentException(
                        "El traslado requiere origen y destino.");
            }
            else if (Tipo.Item2 == "+")
            {
                if (!Destino)
                    throw new ArgumentException(
                        "Seleccione una sucursal y bodega de destino.");
            }
            else if (Tipo.Item2 == "-")
            {
                if (!Origen)
                    throw new ArgumentException(
                        "Seleccione una sucursal y bodega de origen.");
            }
            else
            {
                throw new ArgumentException(
                    "El tipo de movimiento tiene un signo inválido.");
            }

            if (Origen && Destino &&
                D.FkBodegaOrigenCodigo.Value ==
                D.FkBodegaDestinoCodigo.Value)
                throw new ArgumentException(
                    "La bodega de origen y destino deben ser diferentes.");
        }

        // ========================================================
        // CONVERTIR DATOS A ENTIDAD
        // ========================================================

        private ClsMovimientoInventario LogisticaFuncEntidad(
            ClsModeloMovimientoInventario D)
        {
            return new ClsMovimientoInventario
            {
                IdMovimientoInventario = D.IdMovimientoInventario,
                FkTipoMovimientoCodigo = D.FkTipoMovimientoCodigo,

                FkSucursalOrigenCodigo = D.FkSucursalOrigenCodigo,
                FkBodegaOrigenCodigo = D.FkBodegaOrigenCodigo,

                FkSucursalDestinoCodigo = D.FkSucursalDestinoCodigo,
                FkBodegaDestinoCodigo = D.FkBodegaDestinoCodigo,

                FkTransporteCodigo = D.FkTransporteCodigo,

                FechaMovimientoInventario = D.FechaMovimientoInventario,
                ObservacionesMovimientoInventario =
                    D.ObservacionesMovimientoInventario
            };
        }

        // ========================================================
        // INGRESAR
        // ========================================================

        public string LogisticaFuncAgregar(
            ClsModeloMovimientoInventario D)
        {
            LogisticaProcValidarMovimiento(D);

            int Filas = _Repositorio.LogisticaMetAgregar(
                LogisticaFuncEntidad(D));

            if (Filas <= 0)
                throw new InvalidOperationException(
                    "No se pudo registrar el movimiento.");

            return "Movimiento registrado correctamente.";
        }

        // ========================================================
        // MODIFICAR
        // ========================================================

        public string LogisticaFuncEditar(
            ClsModeloMovimientoInventario D)
        {
            if (D == null || D.IdMovimientoInventario <= 0)
                throw new ArgumentException(
                    "Seleccione un movimiento para modificar.");

            LogisticaProcValidarMovimiento(D);

            int Filas = _Repositorio.LogisticaMetEditar(
                LogisticaFuncEntidad(D));

            if (Filas <= 0)
                throw new InvalidOperationException(
                    "No se pudo modificar el movimiento. " +
                    "Debe estar pendiente y sin detalles.");

            return "Movimiento modificado correctamente.";
        }

        // ========================================================
        // ELIMINAR
        // ========================================================

        public string LogisticaFuncEliminar(int IdMovimiento)
        {
            if (IdMovimiento <= 0)
                throw new ArgumentException(
                    "Seleccione un movimiento válido.");

            int Filas = _Repositorio.LogisticaMetEliminar(
                IdMovimiento);

            if (Filas <= 0)
                throw new InvalidOperationException(
                    "No se pudo eliminar el movimiento. " +
                    "Debe estar pendiente y sin detalles.");

            return "Movimiento eliminado correctamente.";
        }

        // ========================================================
        // CONSULTAR MOVIMIENTOS PARA VISTA Y RDLC
        // ========================================================

        public List<ClsModeloMovimientoInventario>
            LogisticaMetObtenerTodos()
        {
            return _Repositorio.LogisticaMetObtenerTodos()
                .Select(D => new ClsModeloMovimientoInventario
                {
                    IdMovimientoInventario = D.IdMovimientoInventario,
                    FkTipoMovimientoCodigo = D.FkTipoMovimientoCodigo,

                    FkSucursalOrigenCodigo = D.FkSucursalOrigenCodigo,
                    FkBodegaOrigenCodigo = D.FkBodegaOrigenCodigo,

                    FkSucursalDestinoCodigo = D.FkSucursalDestinoCodigo,
                    FkBodegaDestinoCodigo = D.FkBodegaDestinoCodigo,

                    FkTransporteCodigo = D.FkTransporteCodigo,

                    FechaMovimientoInventario =
                        D.FechaMovimientoInventario,

                    ObservacionesMovimientoInventario =
                        D.ObservacionesMovimientoInventario,

                    EstadoMovimientoInventario =
                        D.EstadoMovimientoInventario,

                    NombreTipoMovimiento = D.NombreTipoMovimiento,
                    SignoTipoMovimiento = D.SignoTipoMovimiento,

                    NombreSucursalOrigen = D.NombreSucursalOrigen,
                    NombreBodegaOrigen = D.NombreBodegaOrigen,

                    NombreSucursalDestino = D.NombreSucursalDestino,
                    NombreBodegaDestino = D.NombreBodegaDestino,

                    NombreTransporte = D.NombreTransporte
                })
                .ToList();
        }

        // ========================================================
        // CATÁLOGOS DEL FORMULARIO
        // ========================================================

        private List<ClsOpcionCatalogo> LogisticaFuncCatalogo(
            IEnumerable<ClsCatalogo> Datos)
        {
            return Datos.Select(D => new ClsOpcionCatalogo
            {
                Id = D.Id,
                Nombre = D.Nombre
            }).ToList();
        }

        public List<ClsOpcionCatalogo> LogisticaFuncTipos()
        {
            return LogisticaFuncCatalogo(
                _Repositorio.LogisticaMetObtenerTipos());
        }

        public List<ClsOpcionCatalogo> LogisticaFuncSucursales()
        {
            return LogisticaFuncCatalogo(
                _Repositorio.LogisticaMetObtenerSucursales());
        }

        public List<ClsOpcionCatalogo> LogisticaFuncBodegas(
            int IdSucursal)
        {
            return LogisticaFuncCatalogo(
                _Repositorio.LogisticaMetObtenerBodegas(IdSucursal));
        }

        public List<ClsOpcionCatalogo> LogisticaFuncTransportes()
        {
            return LogisticaFuncCatalogo(
                _Repositorio.LogisticaMetObtenerTransportes());
        }

        public Tuple<string, string> LogisticaFuncObtenerTipo(
            int IdTipo)
        {
            return _Repositorio.LogisticaMetObtenerTipo(IdTipo);
        }
    }
}

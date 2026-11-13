
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
 * Controla las operaciones de los movimientos de
 * inventario entre la Vista y la Capa Modelo.
 *
 * Valida el tipo de movimiento, las sucursales,
 * las bodegas y los datos obligatorios.
 * Proporciona los registros para el DataGridView
 * y para el reporte RDLC del módulo.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Entidades;
using CapaModelo_Inventario_Logistica.Repositorios;

namespace CapaControlador_Inventario_Logistica.Modelos_de_Controladores
{
    public class ClsModeloMovimientoInventario
    {
        // ========================================================
        // REPOSITORIO
        // ========================================================

        private readonly ClsIRepositorioMovimientoInventario
            _Repositorio;

        // ========================================================
        // PROPIEDADES DEL MOVIMIENTO Y DEL RDLC
        // ========================================================

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

        public string NombreTipoMovimiento { get; set; }
        public string SignoTipoMovimiento { get; set; }

        public string NombreSucursalOrigen { get; set; }
        public string NombreBodegaOrigen { get; set; }

        public string NombreSucursalDestino { get; set; }
        public string NombreBodegaDestino { get; set; }

        public string NombreTransporte { get; set; }

        // ========================================================
        // CONSTRUCTOR PRINCIPAL
        // ========================================================

        public ClsModeloMovimientoInventario()
        {
            _Repositorio =
                new ClsRepositorioMovimientoInventario();
        }

        // ========================================================
        // CONSTRUCTOR PARA PRUEBAS UNITARIAS
        // ========================================================

        public ClsModeloMovimientoInventario(
            ClsIRepositorioMovimientoInventario Repositorio)
        {
            _Repositorio = Repositorio
                ?? throw new ArgumentNullException(
                    nameof(Repositorio));
        }

        // ========================================================
        // VALIDAR DATOS
        // ========================================================

        private void LogisticaProcValidarMovimiento(
            ClsModeloMovimientoInventario D)
        {
            if (D == null)
            {
                throw new ValidationException(
                    "No existen datos del movimiento.");
            }

            if (D.FkTipoMovimientoCodigo <= 0)
            {
                throw new ValidationException(
                    "Seleccione el tipo de movimiento.");
            }

            if (string.IsNullOrWhiteSpace(
                D.ObservacionesMovimientoInventario))
            {
                throw new ValidationException(
                    "Ingrese las observaciones.");
            }

            if (D.ObservacionesMovimientoInventario.Length > 500)
            {
                throw new ValidationException(
                    "Las observaciones no pueden superar " +
                    "los 500 caracteres.");
            }

            bool SucursalOrigen =
                D.FkSucursalOrigenCodigo.HasValue;

            bool BodegaOrigen =
                D.FkBodegaOrigenCodigo.HasValue;

            bool SucursalDestino =
                D.FkSucursalDestinoCodigo.HasValue;

            bool BodegaDestino =
                D.FkBodegaDestinoCodigo.HasValue;

            if (SucursalOrigen != BodegaOrigen)
            {
                throw new ValidationException(
                    "La sucursal y la bodega de origen " +
                    "deben seleccionarse juntas.");
            }

            if (SucursalDestino != BodegaDestino)
            {
                throw new ValidationException(
                    "La sucursal y la bodega de destino " +
                    "deben seleccionarse juntas.");
            }

            Tuple<string, string> Tipo =
                _Repositorio.LogisticaMetObtenerTipo(
                    D.FkTipoMovimientoCodigo);

            if (Tipo == null)
            {
                throw new ValidationException(
                    "El tipo de movimiento no existe.");
            }

            string Nombre = Tipo.Item1;
            string Signo = Tipo.Item2;

            bool EsTraslado =
                Nombre.IndexOf(
                    "TRASLADO",
                    StringComparison.OrdinalIgnoreCase) >= 0;

            if (EsTraslado)
            {
                if (!SucursalOrigen || !SucursalDestino)
                {
                    throw new ValidationException(
                        "Un traslado necesita sucursal " +
                        "y bodega de origen y destino.");
                }

                if (D.FkBodegaOrigenCodigo ==
                    D.FkBodegaDestinoCodigo)
                {
                    throw new ValidationException(
                        "La bodega de origen y destino " +
                        "no pueden ser iguales.");
                }
            }
            else if (Signo == "+")
            {
                if (!SucursalDestino || SucursalOrigen)
                {
                    throw new ValidationException(
                        "Una entrada necesita bodega " +
                        "de destino y no debe tener origen.");
                }
            }
            else if (Signo == "-")
            {
                if (!SucursalOrigen || SucursalDestino)
                {
                    throw new ValidationException(
                        "Una salida necesita bodega " +
                        "de origen y no debe tener destino.");
                }
            }
            else
            {
                throw new ValidationException(
                    "El signo del tipo de movimiento " +
                    "debe ser + o -.");
            }
        }

        // ========================================================
        // CONVERTIR A ENTIDAD
        // ========================================================

        private ClsMovimientoInventario
            LogisticaFuncCrearEntidad(
                ClsModeloMovimientoInventario D)
        {
            return new ClsMovimientoInventario
            {
                IdMovimientoInventario =
                    D.IdMovimientoInventario,

                FkTipoMovimientoCodigo =
                    D.FkTipoMovimientoCodigo,

                FkSucursalOrigenCodigo =
                    D.FkSucursalOrigenCodigo,

                FkBodegaOrigenCodigo =
                    D.FkBodegaOrigenCodigo,

                FkSucursalDestinoCodigo =
                    D.FkSucursalDestinoCodigo,

                FkBodegaDestinoCodigo =
                    D.FkBodegaDestinoCodigo,

                FkTransporteCodigo =
                    D.FkTransporteCodigo,

                FechaMovimientoInventario =
                    D.FechaMovimientoInventario,

                ObservacionesMovimientoInventario =
                    D.ObservacionesMovimientoInventario
            };
        }

        // ========================================================
        // AGREGAR
        // ========================================================

        public string LogisticaFuncAgregar(
            ClsModeloMovimientoInventario D)
        {
            LogisticaProcValidarMovimiento(D);

            int Filas = _Repositorio.LogisticaMetAgregar(
                LogisticaFuncCrearEntidad(D));

            if (Filas <= 0)
            {
                throw new InvalidOperationException(
                    "No se pudo guardar el movimiento.");
            }

            return "El movimiento se guardó correctamente.";
        }

        // ========================================================
        // MODIFICAR
        // ========================================================

        public string LogisticaFuncEditar(
            ClsModeloMovimientoInventario D)
        {
            if (D == null || D.IdMovimientoInventario <= 0)
            {
                throw new ValidationException(
                    "Seleccione el movimiento a modificar.");
            }

            LogisticaProcValidarMovimiento(D);

            int Filas = _Repositorio.LogisticaMetEditar(
                LogisticaFuncCrearEntidad(D));

            if (Filas <= 0)
            {
                throw new InvalidOperationException(
                    "No fue posible modificar el movimiento. " +
                    "Debe estar pendiente y sin detalles.");
            }

            return "El movimiento se modificó correctamente.";
        }

        // ========================================================
        // ELIMINAR
        // ========================================================

        public string LogisticaFuncEliminar(int IdMovimiento)
        {
            if (IdMovimiento <= 0)
            {
                throw new ValidationException(
                    "Seleccione un movimiento válido.");
            }

            int Filas =
                _Repositorio.LogisticaMetEliminar(
                    IdMovimiento);

            if (Filas <= 0)
            {
                throw new InvalidOperationException(
                    "No se puede eliminar el movimiento. " +
                    "Debe estar pendiente y sin detalles.");
            }

            return "El movimiento se eliminó correctamente.";
        }

        // ========================================================
        // CONSULTAR REGISTROS PARA LA VISTA Y EL RDLC
        // ========================================================

        public List<ClsModeloMovimientoInventario>
            LogisticaMetObtenerTodos()
        {
            return _Repositorio.LogisticaMetObtenerTodos()
                .Select(D => new ClsModeloMovimientoInventario
                {
                    IdMovimientoInventario =
                        D.IdMovimientoInventario,

                    FkTipoMovimientoCodigo =
                        D.FkTipoMovimientoCodigo,

                    FkSucursalOrigenCodigo =
                        D.FkSucursalOrigenCodigo,

                    FkBodegaOrigenCodigo =
                        D.FkBodegaOrigenCodigo,

                    FkSucursalDestinoCodigo =
                        D.FkSucursalDestinoCodigo,

                    FkBodegaDestinoCodigo =
                        D.FkBodegaDestinoCodigo,

                    FkTransporteCodigo =
                        D.FkTransporteCodigo,

                    FechaMovimientoInventario =
                        D.FechaMovimientoInventario,

                    ObservacionesMovimientoInventario =
                        D.ObservacionesMovimientoInventario,

                    EstadoMovimientoInventario =
                        D.EstadoMovimientoInventario,

                    NombreTipoMovimiento =
                        D.NombreTipoMovimiento,

                    SignoTipoMovimiento =
                        D.SignoTipoMovimiento,

                    NombreSucursalOrigen =
                        D.NombreSucursalOrigen,

                    NombreBodegaOrigen =
                        D.NombreBodegaOrigen,

                    NombreSucursalDestino =
                        D.NombreSucursalDestino,

                    NombreBodegaDestino =
                        D.NombreBodegaDestino,

                    NombreTransporte =
                        D.NombreTransporte
                })
                .ToList();
        }

        // ========================================================
        // CATÁLOGOS
        // ========================================================

        private List<ClsOpcionCatalogo>
            LogisticaFuncConvertirCatalogo(
                IEnumerable<ClsCatalogo> Datos)
        {
            return Datos.Select(D => new ClsOpcionCatalogo
            {
                Id = D.Id,
                Nombre = D.Nombre
            }).ToList();
        }

        public List<ClsOpcionCatalogo>
            LogisticaFuncTipos()
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerTipos());
        }

        public List<ClsOpcionCatalogo>
            LogisticaFuncSucursales()
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerSucursales());
        }

        public List<ClsOpcionCatalogo>
            LogisticaFuncBodegas(int IdSucursal)
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerBodegas(
                    IdSucursal));
        }

        public List<ClsOpcionCatalogo>
            LogisticaFuncTransportes()
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerTransportes());
        }

        public Tuple<string, string>
            LogisticaFuncObtenerTipo(int IdTipo)
        {
            return _Repositorio.LogisticaMetObtenerTipo(
                IdTipo);
        }
    }
}

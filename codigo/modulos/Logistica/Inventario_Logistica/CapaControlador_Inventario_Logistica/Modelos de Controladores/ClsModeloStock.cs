
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsModeloStock.cs
 *
 * REALIZADO POR: VELVETH SARAÍ CHAVEZ MEJÍA
 * CARNÉ: 0901 23 6269
 * FECHA: 07/11/2026
 *
 * DESCRIPCIÓN:
 * Valida los datos del Stock y coordina las operaciones
 * entre la Vista y la Capa Modelo.
 *
 * Incluye cálculos de stock actual, stock virtual y
 * variaciones de inventario según el signo del movimiento.
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
    public class ClsModeloStock
    {
        // ========================================================
        // REPOSITORIO
        // ========================================================

        private readonly ClsIRepositorioStock _Repositorio;

        public ClsDatosStock Stock { get; set; }

        public ClsEstadoEntidad Estado { get; set; }

        // ========================================================
        // CONSTRUCTOR PRINCIPAL
        // ========================================================

        public ClsModeloStock()
        {
            _Repositorio = new ClsRepositorioStock();

            Stock = new ClsDatosStock();
        }

        // ========================================================
        // CONSTRUCTOR PARA PRUEBAS UNITARIAS
        // ========================================================

        public ClsModeloStock(ClsIRepositorioStock Repositorio)
        {
            if (Repositorio == null)
            {
                throw new ArgumentNullException(
                    nameof(Repositorio));
            }

            _Repositorio = Repositorio;

            Stock = new ClsDatosStock();
        }

        // ========================================================
        // GUARDAR, MODIFICAR O ELIMINAR
        // ========================================================

        public string LogisticaFuncGrabarCambios()
        {
            if (Stock == null)
            {
                throw new ValidationException(
                    "No hay datos de Stock.");
            }

            int Filas;
            string Mensaje;

            switch (Estado)
            {
                case ClsEstadoEntidad.Added:

                    LogisticaProcValidarStock(Stock);

                    Filas = _Repositorio.LogisticaMetAgregar(
                        LogisticaFuncCrearEntidad(Stock));

                    Mensaje = "El stock se guardó correctamente.";
                    break;

                case ClsEstadoEntidad.Modified:

                    if (Stock.IdStock <= 0)
                    {
                        throw new ValidationException(
                            "Seleccione el stock a modificar.");
                    }

                    LogisticaProcValidarStock(Stock);

                    Filas = _Repositorio.LogisticaMetEditar(
                        LogisticaFuncCrearEntidad(Stock));

                    Mensaje = "El stock se modificó correctamente.";
                    break;

                case ClsEstadoEntidad.Deleted:

                    if (Stock.IdStock <= 0)
                    {
                        throw new ValidationException(
                            "Seleccione el stock a eliminar.");
                    }

                    Filas = _Repositorio.LogisticaMetEliminar(
                        Stock.IdStock);

                    Mensaje = "El stock se eliminó correctamente.";
                    break;

                default:

                    throw new InvalidOperationException(
                        "Operación no válida.");
            }

            if (Filas <= 0)
            {
                throw new InvalidOperationException(
                    "No se modificó ningún registro.");
            }

            return Mensaje;
        }

        // ========================================================
        // VALIDACIONES DEL STOCK
        // ========================================================

        private void LogisticaProcValidarStock(
            ClsDatosStock Datos)
        {
            var Resultados = new List<ValidationResult>();

            bool Valido = Validator.TryValidateObject(
                Datos,
                new ValidationContext(Datos),
                Resultados,
                true);

            if (!Valido)
            {
                throw new ValidationException(
                    string.Join(
                        "\n",
                        Resultados.Select(R => R.ErrorMessage)));
            }

            if (Datos.ApartadosStock > Datos.StockActualStock)
            {
                throw new ValidationException(
                    "Los apartados no pueden superar el stock actual.");
            }
        }

        // ========================================================
        // CONVERTIR DATOS EN ENTIDAD
        // ========================================================

        private ClsStock LogisticaFuncCrearEntidad(
            ClsDatosStock D)
        {
            return new ClsStock
            {
                IdStock = D.IdStock,

                FkSucursalCodigo = D.FkSucursalCodigo,
                FkBodegaCodigo = D.FkBodegaCodigo,
                FkProductoCodigo = D.FkProductoCodigo,

                StockFisicoStock = D.StockFisicoStock,
                StockVirtualStock = D.StockVirtualStock,
                StockAnteriorStock = D.StockAnteriorStock,
                StockActualStock = D.StockActualStock,

                CargosMesStock = D.CargosMesStock,
                AbonosMesStock = D.AbonosMesStock,

                CargosAcumuladosStock =
                    D.CargosAcumuladosStock,

                AbonosAcumuladosStock =
                    D.AbonosAcumuladosStock,

                ApartadosStock = D.ApartadosStock,

                EstadoVentaStock = D.EstadoVentaStock,
                EstadoCompraStock = D.EstadoCompraStock
            };
        }

        // ========================================================
        // CONSULTAR TODOS LOS REGISTROS
        // ========================================================

        public List<ClsDatosStock> LogisticaFuncObtenerTodos()
        {
            return _Repositorio.LogisticaMetObtenerTodos()
                .Select(D => new ClsDatosStock
                {
                    IdStock = D.IdStock,

                    FkSucursalCodigo = D.FkSucursalCodigo,
                    FkBodegaCodigo = D.FkBodegaCodigo,
                    FkProductoCodigo = D.FkProductoCodigo,

                    StockFisicoStock = D.StockFisicoStock,
                    StockVirtualStock = D.StockVirtualStock,
                    StockAnteriorStock = D.StockAnteriorStock,
                    StockActualStock = D.StockActualStock,

                    CargosMesStock = D.CargosMesStock,
                    AbonosMesStock = D.AbonosMesStock,

                    CargosAcumuladosStock =
                        D.CargosAcumuladosStock,

                    AbonosAcumuladosStock =
                        D.AbonosAcumuladosStock,

                    ApartadosStock = D.ApartadosStock,

                    EstadoVentaStock = D.EstadoVentaStock,
                    EstadoCompraStock = D.EstadoCompraStock,

                    NombreSucursal = D.NombreSucursal,
                    NombreBodega = D.NombreBodega,
                    NombreProducto = D.NombreProducto
                })
                .ToList();
        }

        // ========================================================
        // CONVERTIR CATÁLOGOS
        // ========================================================

        private List<ClsOpcionCatalogo>
            LogisticaFuncConvertirCatalogo(
                IEnumerable<ClsCatalogo> Datos)
        {
            return Datos.Select(X =>
                new ClsOpcionCatalogo
                {
                    Id = X.Id,
                    Nombre = X.Nombre
                })
                .ToList();
        }

        // ========================================================
        // OBTENER SUCURSALES
        // ========================================================

        public List<ClsOpcionCatalogo>
            LogisticaFuncSucursales()
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerSucursales());
        }

        // ========================================================
        // OBTENER BODEGAS POR SUCURSAL
        // ========================================================

        public List<ClsOpcionCatalogo>
            LogisticaFuncBodegas(int IdSucursal)
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerBodegas(
                    IdSucursal));
        }

        // ========================================================
        // OBTENER PRODUCTOS
        // ========================================================

        public List<ClsOpcionCatalogo>
            LogisticaFuncProductos()
        {
            return LogisticaFuncConvertirCatalogo(
                _Repositorio.LogisticaMetObtenerProductos());
        }

        // ========================================================
        // CALCULAR VARIACIÓN SEGÚN TIPO DE MOVIMIENTO
        // ========================================================

        public int LogisticaFuncCalcularVariacionMovimiento(
            string SignoTipoMovimiento,
            int Cantidad)
        {
            if (Cantidad <= 0)
            {
                throw new ArgumentException(
                    "La cantidad debe ser mayor que cero.");
            }

            switch (SignoTipoMovimiento)
            {
                case "+":
                    return Cantidad;

                case "-":
                    return -Cantidad;

                default:
                    throw new ArgumentException(
                        "El signo del movimiento no es válido.");
            }
        }

        // ========================================================
        // CALCULAR STOCK ACTUAL
        // ========================================================

        public int LogisticaFuncCalcularStockActual(
            int StockAnterior,
            int CargosMes,
            int AbonosMes)
        {
            if (StockAnterior < 0 ||
                CargosMes < 0 ||
                AbonosMes < 0)
            {
                throw new ValidationException(
                    "Los valores no pueden ser negativos.");
            }

            long Resultado =
                (long)StockAnterior +
                CargosMes -
                AbonosMes;

            if (Resultado < 0 ||
                Resultado > int.MaxValue)
            {
                throw new ValidationException(
                    "El stock calculado está fuera del rango permitido.");
            }

            return (int)Resultado;
        }

        // ========================================================
        // CALCULAR STOCK VIRTUAL
        // ========================================================

        public int LogisticaFuncCalcularStockVirtual(
            int StockActual,
            int Apartados)
        {
            if (StockActual < 0 || Apartados < 0)
            {
                throw new ValidationException(
                    "El stock y los apartados no pueden ser negativos.");
            }

            if (Apartados > StockActual)
            {
                throw new ValidationException(
                    "Los apartados no pueden superar el stock actual.");
            }

            return StockActual - Apartados;
        }

        // ========================================================
        // CALCULAR SALDO DESPUÉS DE UN MOVIMIENTO
        // ========================================================

        public int LogisticaFuncCalcularStockConMovimiento(
            int StockActual,
            string SignoTipoMovimiento,
            int Cantidad)
        {
            if (StockActual < 0)
            {
                throw new ValidationException(
                    "El stock actual no puede ser negativo.");
            }

            int Variacion =
                LogisticaFuncCalcularVariacionMovimiento(
                    SignoTipoMovimiento,
                    Cantidad);

            long Resultado =
                (long)StockActual + Variacion;

            if (Resultado < 0 ||
                Resultado > int.MaxValue)
            {
                throw new ValidationException(
                    "El movimiento genera un stock fuera del rango permitido.");
            }

            return (int)Resultado;
        }
    }
}

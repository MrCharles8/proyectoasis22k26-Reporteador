
/*
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsRepositorioMovimientoInventario.cs
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Gestiona los encabezados de movimientos de inventario
 * mediante ODBC. Permite agregar, modificar, eliminar,
 * consultar registros y obtener los catálogos relacionados.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Entidades;

namespace CapaModelo_Inventario_Logistica.Repositorios
{
    public class ClsRepositorioMovimientoInventario :
        ClsRepositorioMaestro,
        ClsIRepositorioMovimientoInventario
    {
        // ========================================================
        // AGREGAR MOVIMIENTO
        // ========================================================

        public int LogisticaMetAgregar(
            ClsMovimientoInventario D)
        {
            const string Sql = @"
                INSERT INTO tblMovimientoInventario
                (
                    Fk_Tipo_Movimiento_Codigo,
                    Fk_Sucursal_Origen_Codigo,
                    Fk_Bodega_Origen_Codigo,
                    Fk_Sucursal_Destino_Codigo,
                    Fk_Bodega_Destino_Codigo,
                    Fk_Transporte_Codigo,
                    fechaMovimientoInventario,
                    observacionesMovimientoInventario,
                    estadoMovimientoInventario
                )
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, 'PENDIENTE')";

            return LogisticaMetEjecutarOperacion(
                Sql, LogisticaFuncParametros(D));
        }

        // ========================================================
        // MODIFICAR MOVIMIENTO
        // ========================================================

        public int LogisticaMetEditar(
            ClsMovimientoInventario D)
        {
            const string Sql = @"
                UPDATE tblMovimientoInventario m
                SET
                    Fk_Tipo_Movimiento_Codigo = ?,
                    Fk_Sucursal_Origen_Codigo = ?,
                    Fk_Bodega_Origen_Codigo = ?,
                    Fk_Sucursal_Destino_Codigo = ?,
                    Fk_Bodega_Destino_Codigo = ?,
                    Fk_Transporte_Codigo = ?,
                    fechaMovimientoInventario = ?,
                    observacionesMovimientoInventario = ?
                WHERE m.idMovimientoInventario = ?
                  AND m.estadoMovimientoInventario = 'PENDIENTE'
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM tblDetalleMovimiento d
                      WHERE d.Fk_Movimiento_Inventario_Codigo =
                            m.idMovimientoInventario
                  )";

            List<OdbcParameter> Parametros =
                LogisticaFuncParametros(D);

            Parametros.Add(new OdbcParameter(
                "Id", OdbcType.Int)
            {
                Value = D.IdMovimientoInventario
            });

            return LogisticaMetEjecutarOperacion(
                Sql, Parametros);
        }

        // ========================================================
        // ELIMINAR MOVIMIENTO
        // ========================================================

        public int LogisticaMetEliminar(int IdMovimiento)
        {
            const string Sql = @"
                DELETE FROM tblMovimientoInventario
                WHERE idMovimientoInventario = ?
                  AND estadoMovimientoInventario = 'PENDIENTE'
                  AND NOT EXISTS
                  (
                      SELECT 1
                      FROM tblDetalleMovimiento d
                      WHERE d.Fk_Movimiento_Inventario_Codigo =
                            tblMovimientoInventario.idMovimientoInventario
                  )";

            return LogisticaMetEjecutarOperacion(
                Sql,
                new List<OdbcParameter>
                {
                    new OdbcParameter("Id", OdbcType.Int)
                    {
                        Value = IdMovimiento
                    }
                });
        }

        // ========================================================
        // PARÁMETROS ODBC
        // ========================================================

        private List<OdbcParameter> LogisticaFuncParametros(
            ClsMovimientoInventario D)
        {
            return new List<OdbcParameter>
            {
                new OdbcParameter("Tipo", OdbcType.Int)
                {
                    Value = D.FkTipoMovimientoCodigo
                },

                new OdbcParameter("SucursalOrigen", OdbcType.Int)
                {
                    Value = LogisticaFuncDb(
                        D.FkSucursalOrigenCodigo)
                },

                new OdbcParameter("BodegaOrigen", OdbcType.Int)
                {
                    Value = LogisticaFuncDb(
                        D.FkBodegaOrigenCodigo)
                },

                new OdbcParameter("SucursalDestino", OdbcType.Int)
                {
                    Value = LogisticaFuncDb(
                        D.FkSucursalDestinoCodigo)
                },

                new OdbcParameter("BodegaDestino", OdbcType.Int)
                {
                    Value = LogisticaFuncDb(
                        D.FkBodegaDestinoCodigo)
                },

                new OdbcParameter("Transporte", OdbcType.Int)
                {
                    Value = LogisticaFuncDb(
                        D.FkTransporteCodigo)
                },

                new OdbcParameter("Fecha", OdbcType.DateTime)
                {
                    Value = D.FechaMovimientoInventario
                },

                new OdbcParameter("Observaciones", OdbcType.VarChar, 500)
                {
                    Value = D.ObservacionesMovimientoInventario
                }
            };
        }

        private static object LogisticaFuncDb(int? Id)
        {
            return Id.HasValue
                ? (object)Id.Value
                : DBNull.Value;
        }

        private static int? LogisticaFuncEnteroNulo(
            DataRow F,
            string Campo)
        {
            return F.IsNull(Campo)
                ? (int?)null
                : Convert.ToInt32(F[Campo]);
        }

        // ========================================================
        // EJECUTAR INSERT, UPDATE O DELETE
        // ========================================================

        private int LogisticaMetEjecutarOperacion(
            string Sql,
            List<OdbcParameter> Parametros)
        {
            using (OdbcConnection Conexion =
                LogisticaMetObtenerConexion())
            using (OdbcCommand Comando =
                new OdbcCommand(Sql, Conexion))
            {
                Comando.Parameters.AddRange(
                    Parametros.ToArray());

                Conexion.Open();

                return Comando.ExecuteNonQuery();
            }
        }

        // ========================================================
        // CONSULTAR MOVIMIENTOS
        // ========================================================

        public IEnumerable<ClsMovimientoInventario>
            LogisticaMetObtenerTodos()
        {
            const string Sql = @"
                SELECT
                    m.idMovimientoInventario,
                    m.Fk_Tipo_Movimiento_Codigo,
                    m.Fk_Sucursal_Origen_Codigo,
                    m.Fk_Bodega_Origen_Codigo,
                    m.Fk_Sucursal_Destino_Codigo,
                    m.Fk_Bodega_Destino_Codigo,
                    m.Fk_Transporte_Codigo,
                    m.fechaMovimientoInventario,
                    m.observacionesMovimientoInventario,
                    m.estadoMovimientoInventario,
                    t.nombreTipoMovimiento,
                    t.signoTipoMovimiento,

                    COALESCE(so.nombreSucursal, '')
                        AS NombreSucursalOrigen,

                    COALESCE(bo.nombreBodega, '')
                        AS NombreBodegaOrigen,

                    COALESCE(sd.nombreSucursal, '')
                        AS NombreSucursalDestino,

                    COALESCE(bd.nombreBodega, '')
                        AS NombreBodegaDestino,

                    COALESCE(
                        CONCAT(
                            tr.nroPlacaTransporte,
                            ' - ',
                            tr.marcaTransporte
                        ), ''
                    ) AS NombreTransporte

                FROM tblMovimientoInventario m

                INNER JOIN tblTipoMovimiento t
                    ON t.idTipoMovimiento =
                       m.Fk_Tipo_Movimiento_Codigo

                LEFT JOIN tblSucursal so
                    ON so.idSucursal =
                       m.Fk_Sucursal_Origen_Codigo

                LEFT JOIN tblBodega bo
                    ON bo.idBodega =
                       m.Fk_Bodega_Origen_Codigo

                LEFT JOIN tblSucursal sd
                    ON sd.idSucursal =
                       m.Fk_Sucursal_Destino_Codigo

                LEFT JOIN tblBodega bd
                    ON bd.idBodega =
                       m.Fk_Bodega_Destino_Codigo

                LEFT JOIN tblTransporte tr
                    ON tr.idTransporte =
                       m.Fk_Transporte_Codigo

                ORDER BY m.idMovimientoInventario";

            DataTable Tabla =
                LogisticaMetEjecucionConsulta(
                    Sql,
                    CommandType.Text);

            List<ClsMovimientoInventario> Lista =
                new List<ClsMovimientoInventario>();

            foreach (DataRow F in Tabla.Rows)
            {
                Lista.Add(new ClsMovimientoInventario
                {
                    IdMovimientoInventario =
                        Convert.ToInt32(
                            F["idMovimientoInventario"]),

                    FkTipoMovimientoCodigo =
                        Convert.ToInt32(
                            F["Fk_Tipo_Movimiento_Codigo"]),

                    FkSucursalOrigenCodigo =
                        LogisticaFuncEnteroNulo(
                            F, "Fk_Sucursal_Origen_Codigo"),

                    FkBodegaOrigenCodigo =
                        LogisticaFuncEnteroNulo(
                            F, "Fk_Bodega_Origen_Codigo"),

                    FkSucursalDestinoCodigo =
                        LogisticaFuncEnteroNulo(
                            F, "Fk_Sucursal_Destino_Codigo"),

                    FkBodegaDestinoCodigo =
                        LogisticaFuncEnteroNulo(
                            F, "Fk_Bodega_Destino_Codigo"),

                    FkTransporteCodigo =
                        LogisticaFuncEnteroNulo(
                            F, "Fk_Transporte_Codigo"),

                    FechaMovimientoInventario =
                        Convert.ToDateTime(
                            F["fechaMovimientoInventario"]),

                    ObservacionesMovimientoInventario =
                        Convert.ToString(
                            F["observacionesMovimientoInventario"]),

                    EstadoMovimientoInventario =
                        Convert.ToString(
                            F["estadoMovimientoInventario"]),

                    NombreTipoMovimiento =
                        Convert.ToString(
                            F["nombreTipoMovimiento"]),

                    SignoTipoMovimiento =
                        Convert.ToString(
                            F["signoTipoMovimiento"]),

                    NombreSucursalOrigen =
                        Convert.ToString(
                            F["NombreSucursalOrigen"]),

                    NombreBodegaOrigen =
                        Convert.ToString(
                            F["NombreBodegaOrigen"]),

                    NombreSucursalDestino =
                        Convert.ToString(
                            F["NombreSucursalDestino"]),

                    NombreBodegaDestino =
                        Convert.ToString(
                            F["NombreBodegaDestino"]),

                    NombreTransporte =
                        Convert.ToString(
                            F["NombreTransporte"])
                });
            }

            return Lista;
        }

        // ========================================================
        // CONSULTAR CATÁLOGOS
        // ========================================================

        private IEnumerable<ClsCatalogo>
            LogisticaFuncCatalogo(
                string Sql,
                List<OdbcParameter> Parametros = null)
        {
            DataTable Tabla = Parametros == null
                ? LogisticaMetEjecucionConsulta(
                    Sql, CommandType.Text)
                : LogisticaMetEjecucionConsulta(
                    Sql, CommandType.Text, Parametros);

            List<ClsCatalogo> Lista =
                new List<ClsCatalogo>();

            foreach (DataRow F in Tabla.Rows)
            {
                Lista.Add(new ClsCatalogo
                {
                    Id = Convert.ToInt32(F["Id"]),
                    Nombre = Convert.ToString(F["Nombre"])
                });
            }

            return Lista;
        }

        // ========================================================
        // TIPOS DE MOVIMIENTO
        // ========================================================

        public IEnumerable<ClsCatalogo>
            LogisticaMetObtenerTipos()
        {
            return LogisticaFuncCatalogo(@"
                SELECT
                    idTipoMovimiento AS Id,
                    CONCAT(
                        nombreTipoMovimiento,
                        ' (',
                        signoTipoMovimiento,
                        ')'
                    ) AS Nombre
                FROM tblTipoMovimiento
                ORDER BY nombreTipoMovimiento");
        }

        // ========================================================
        // SUCURSALES
        // ========================================================

        public IEnumerable<ClsCatalogo>
            LogisticaMetObtenerSucursales()
        {
            return LogisticaFuncCatalogo(@"
                SELECT
                    idSucursal AS Id,
                    nombreSucursal AS Nombre
                FROM tblSucursal
                ORDER BY nombreSucursal");
        }

        // ========================================================
        // BODEGAS POR SUCURSAL
        // ========================================================

        public IEnumerable<ClsCatalogo>
            LogisticaMetObtenerBodegas(int IdSucursal)
        {
            return LogisticaFuncCatalogo(@"
                SELECT
                    idBodega AS Id,
                    nombreBodega AS Nombre
                FROM tblBodega
                WHERE Fk_Sucursal_Codigo = ?
                ORDER BY nombreBodega",
                new List<OdbcParameter>
                {
                    new OdbcParameter(
                        "Sucursal", OdbcType.Int)
                    {
                        Value = IdSucursal
                    }
                });
        }

        // ========================================================
        // TRANSPORTES
        // ========================================================

        public IEnumerable<ClsCatalogo>
            LogisticaMetObtenerTransportes()
        {
            return LogisticaFuncCatalogo(@"
                SELECT
                    idTransporte AS Id,
                    CONCAT(
                        nroPlacaTransporte,
                        ' - ',
                        marcaTransporte
                    ) AS Nombre
                FROM tblTransporte
                ORDER BY nroPlacaTransporte");
        }

        // ========================================================
        // OBTENER TIPO Y SIGNO
        // ========================================================

        public Tuple<string, string>
            LogisticaMetObtenerTipo(int IdTipo)
        {
            DataTable Tabla =
                LogisticaMetEjecucionConsulta(@"
                    SELECT
                        nombreTipoMovimiento,
                        signoTipoMovimiento
                    FROM tblTipoMovimiento
                    WHERE idTipoMovimiento = ?",
                    CommandType.Text,
                    new List<OdbcParameter>
                    {
                        new OdbcParameter(
                            "Tipo", OdbcType.Int)
                        {
                            Value = IdTipo
                        }
                    });

            if (Tabla.Rows.Count == 0)
            {
                return null;
            }

            return Tuple.Create(
                Convert.ToString(
                    Tabla.Rows[0]["nombreTipoMovimiento"]),
                Convert.ToString(
                    Tabla.Rows[0]["signoTipoMovimiento"]));
        }
    }
}

// Autor: José Xavier Bolaños Tenas, carné 0901-23-2128.
// Propósito: consultar catálogos y persistir traslados mediante ODBC.

using System;
using System.Data;
using System.Data.Odbc;
using CapaModelo_Traslados_Logistica.Entidades;

namespace CapaModelo_Traslados_Logistica.Repositorios
{
    public class ClsRepositorioTraslado : ClsRepositorio
    {
        // Inicializa el repositorio con la conexión heredada.
        public ClsRepositorioTraslado() : base()
        {
        }

        // Consulta las bodegas activas junto con su identificador visible.
        public DataTable LogisticaFuncListarBodegas()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT idBodega, CONCAT(idBodega, ' - ', nombreBodega) AS nombreBodega " +
                "FROM tblBodega WHERE estadoBodega = 1 ORDER BY nombreBodega");
        }

        // Consulta los productos activos para el combo de selección.
        public DataTable LogisticaFuncListarProductos()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT idProducto, skuProducto, nombreProducto, " +
                "CONCAT(skuProducto, ' - ', nombreProducto) AS descripcionProducto " +
                "FROM tblProducto WHERE estadoProducto = 1 ORDER BY nombreProducto");
        }

        // Consulta los transportes activos para el combo de selección.
        public DataTable LogisticaFuncListarTransportes()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT idTransporte, CONCAT(nroPlacaTransporte, ' - ', conductorTransporte) AS descripcionTransporte " +
                "FROM tblTransporte WHERE estadoTransporte = 1 ORDER BY nroPlacaTransporte");
        }

        // Consulta los traslados y sus datos descriptivos para el grid principal.
        public DataTable LogisticaFuncListarTraslados()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT T.codigoTraslado, T.fechaSolicitudTraslado AS fechaSolicitud, " +
                "CONCAT(BO.idBodega, ' - ', BO.nombreBodega) AS bodegaOrigen, " +
                "T.fechaSalidaTraslado AS fechaSalida, " +
                "CONCAT(BD.idBodega, ' - ', BD.nombreBodega) AS bodegaDestino, " +
                "T.fechaLlegadaTraslado AS fechaEntrega, " +
                "COALESCE(TR.nroPlacaTransporte, '') AS codigoTransporte, " +
                "T.estadoTraslado " +
                "FROM tblTraslado T " +
                "INNER JOIN tblBodega BO ON BO.idBodega = T.fkBodegaOrigenIdBodega " +
                "INNER JOIN tblBodega BD ON BD.idBodega = T.fkBodegaDestinoIdBodega " +
                "LEFT JOIN tblTransporte TR ON TR.idTransporte = T.fkTransporteIdTransporte " +
                "ORDER BY T.fechaSolicitudTraslado DESC, T.idTraslado DESC");
        }

        // Guarda la cabecera y sus detalles dentro de una única transacción.
        public void LogisticaProcGuardarTraslado(ClsEntidadTraslado Traslado)
        {
            using (OdbcConnection Conexion = LogisticaMetObtenerConexion())
            {
                Conexion.Open();
                using (OdbcTransaction Transaccion = Conexion.BeginTransaction())
                {
                    try
                    {
                        int IdTraslado;
                        using (OdbcCommand Comando = new OdbcCommand(
                            "INSERT INTO tblTraslado (codigoTraslado, fkBodegaOrigenIdBodega, fkBodegaDestinoIdBodega, " +
                            "fkTransporteIdTransporte, fechaSolicitudTraslado, fechaSalidaTraslado, estadoTraslado) " +
                            "VALUES (?, ?, ?, ?, ?, ?, ?)", Conexion, Transaccion))
                        {
                            Comando.Parameters.AddWithValue("codigoTraslado", Traslado.Codigo);
                            Comando.Parameters.AddWithValue("bodegaOrigen", Traslado.IdBodegaOrigen);
                            Comando.Parameters.AddWithValue("bodegaDestino", Traslado.IdBodegaDestino);
                            Comando.Parameters.AddWithValue("transporte", Traslado.IdTransporte.HasValue ? (object)Traslado.IdTransporte.Value : DBNull.Value);
                            Comando.Parameters.AddWithValue("fechaSolicitud", Traslado.FechaSolicitud);
                            Comando.Parameters.AddWithValue("fechaSalida", Traslado.FechaSalida.HasValue ? (object)Traslado.FechaSalida.Value : DBNull.Value);
                            Comando.Parameters.AddWithValue("estado", Traslado.Estado);
                            Comando.ExecuteNonQuery();
                        }

                        using (OdbcCommand ComandoId = new OdbcCommand("SELECT LAST_INSERT_ID()", Conexion, Transaccion))
                        {
                            IdTraslado = Convert.ToInt32(ComandoId.ExecuteScalar());
                        }

                        foreach (ClsEntidadDetalleTraslado Detalle in Traslado.Detalles)
                        {
                            using (OdbcCommand ComandoDetalle = new OdbcCommand(
                                "INSERT INTO tblDetalleTraslado (fkTrasladoIdTraslado, fkProductoIdProducto, cantidadDetalleTraslado) " +
                                "VALUES (?, ?, ?)", Conexion, Transaccion))
                            {
                                ComandoDetalle.Parameters.AddWithValue("traslado", IdTraslado);
                                ComandoDetalle.Parameters.AddWithValue("producto", Detalle.IdProducto);
                                ComandoDetalle.Parameters.AddWithValue("cantidad", Detalle.Cantidad);
                                ComandoDetalle.ExecuteNonQuery();
                            }
                        }

                        Transaccion.Commit();
                    }
                    catch
                    {
                        Transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        // Ejecuta una consulta de lectura y devuelve el resultado como DataTable.
        private DataTable LogisticaFuncConsultarTabla(string Consulta)
        {
            DataTable Tabla = new DataTable();
            using (OdbcConnection Conexion = LogisticaMetObtenerConexion())
            using (OdbcDataAdapter Adaptador = new OdbcDataAdapter(Consulta, Conexion))
            {
                Adaptador.Fill(Tabla);
            }
            return Tabla;
        }
    }
}
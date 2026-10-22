
using System;
using System.Data;
using System.Data.Odbc;
using CapaModelo_Traslados_Logistica.Entidades;

namespace CapaModelo_Traslados_Logistica.Repositorios
{
    public class ClsRepositorioTraslado : ClsRepositorio
    {
        public ClsRepositorioTraslado() : base()
        {
        }

        // LISTAR BODEGAS
        public DataTable LogisticaFuncListarBodegas()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT Pk_Bodega AS idBodega, " +
                "CONCAT(Pk_Bodega, ' - ', nombreBodega) AS nombreBodega " +
                "FROM tblBodega ORDER BY nombreBodega");
        }

        // LISTAR PRODUCTOS
        public DataTable LogisticaFuncListarProductos()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT Pk_Producto AS idProducto, " +
                "skuProducto, nombreProducto, " +
                "CONCAT(skuProducto, ' - ', nombreProducto) " +
                "AS descripcionProducto " +
                "FROM tblProducto ORDER BY nombreProducto");
        }

        // LISTAR TRANSPORTES
        public DataTable LogisticaFuncListarTransportes()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT Pk_Transporte AS idTransporte, " +
                "CONCAT(nroPlacaTransporte, ' - ', " +
                "COALESCE(marcaTransporte, 'Sin marca')) " +
                "AS descripcionTransporte " +
                "FROM tblTransporte ORDER BY nroPlacaTransporte");
        }

        // LISTAR TRASLADOS
        public DataTable LogisticaFuncListarTraslados()
        {
            return LogisticaFuncConsultarTabla(
                "SELECT T.codigoTraslado, " +
                "T.fechaSolicitudTraslado AS fechaSolicitud, " +
                "CONCAT(BO.Pk_Bodega, ' - ', BO.nombreBodega) " +
                "AS bodegaOrigen, " +
                "T.fechaSalidaTraslado AS fechaSalida, " +
                "CONCAT(BD.Pk_Bodega, ' - ', BD.nombreBodega) " +
                "AS bodegaDestino, " +
                "T.fechaLlegadaTraslado AS fechaEntrega, " +
                "COALESCE(TR.nroPlacaTransporte, '') " +
                "AS codigoTransporte, " +
                "T.estadoTraslado " +
                "FROM tblTraslado T " +
                "INNER JOIN tblBodega BO " +
                "ON BO.Pk_Bodega = T.Fk_Bodega_OrigenCodigo " +
                "INNER JOIN tblBodega BD " +
                "ON BD.Pk_Bodega = T.Fk_Bodega_DestinoCodigo " +
                "LEFT JOIN tblTransporte TR " +
                "ON TR.Pk_Transporte = T.Fk_Transporte_Codigo " +
                "ORDER BY T.fechaSolicitudTraslado DESC, " +
                "T.Pk_Traslado DESC");
        }

        // GUARDAR TRASLADO
        public void LogisticaProcGuardarTraslado(
            ClsEntidadTraslado Traslado)
        {
            using (OdbcConnection Conexion =
                LogisticaMetObtenerConexion())
            {
                Conexion.Open();

                using (OdbcTransaction Transaccion =
                    Conexion.BeginTransaction())
                {
                    try
                    {
                        int IdTraslado;

                        using (OdbcCommand Comando = new OdbcCommand(
                            "INSERT INTO tblTraslado " +
                            "(codigoTraslado, " +
                            "Fk_Bodega_OrigenCodigo, " +
                            "Fk_Bodega_DestinoCodigo, " +
                            "Fk_Transporte_Codigo, " +
                            "fechaSolicitudTraslado, " +
                            "fechaSalidaTraslado, estadoTraslado) " +
                            "VALUES (?, ?, ?, ?, ?, ?, ?)",
                            Conexion, Transaccion))
                        {
                            Comando.Parameters.AddWithValue(
                                "codigoTraslado", Traslado.Codigo);

                            Comando.Parameters.AddWithValue(
                                "bodegaOrigen", Traslado.IdBodegaOrigen);

                            Comando.Parameters.AddWithValue(
                                "bodegaDestino", Traslado.IdBodegaDestino);

                            Comando.Parameters.AddWithValue(
                                "transporte",
                                Traslado.IdTransporte.HasValue
                                ? (object)Traslado.IdTransporte.Value
                                : DBNull.Value);

                            Comando.Parameters.AddWithValue(
                                "fechaSolicitud", Traslado.FechaSolicitud);

                            Comando.Parameters.AddWithValue(
                                "fechaSalida",
                                Traslado.FechaSalida.HasValue
                                ? (object)Traslado.FechaSalida.Value
                                : DBNull.Value);

                            Comando.Parameters.AddWithValue(
                                "estado", Traslado.Estado);

                            Comando.ExecuteNonQuery();
                        }

                        using (OdbcCommand ComandoId = new OdbcCommand(
                            "SELECT LAST_INSERT_ID()",
                            Conexion, Transaccion))
                        {
                            IdTraslado = Convert.ToInt32(
                                ComandoId.ExecuteScalar());
                        }

                        foreach (ClsEntidadDetalleTraslado Detalle
                            in Traslado.Detalles)
                        {
                            using (OdbcCommand ComandoDetalle =
                                new OdbcCommand(
                                    "INSERT INTO tblDetalleTraslado " +
                                    "(Fk_Traslado_Codigo, " +
                                    "Fk_Producto_Codigo, " +
                                    "cantidadDetalleTraslado) " +
                                    "VALUES (?, ?, ?)",
                                    Conexion, Transaccion))
                            {
                                ComandoDetalle.Parameters.AddWithValue(
                                    "traslado", IdTraslado);

                                ComandoDetalle.Parameters.AddWithValue(
                                    "producto", Detalle.IdProducto);

                                ComandoDetalle.Parameters.AddWithValue(
                                    "cantidad", Detalle.Cantidad);

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

        // CONSULTA GENERAL
        private DataTable LogisticaFuncConsultarTabla(string Consulta)
        {
            DataTable Tabla = new DataTable();

            using (OdbcConnection Conexion =
                LogisticaMetObtenerConexion())
            using (OdbcDataAdapter Adaptador =
                new OdbcDataAdapter(Consulta, Conexion))
            {
                Adaptador.Fill(Tabla);
            }

            return Tabla;
        }
    }
}

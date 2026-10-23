// ------------------------------------------------------
// Autor: Gabriela Pinto García
// Carné: 9959-23-1087
// Fecha: 21/10/2026
// Módulo: Logística - Transporte Externo
// ------------------------------------------------------
using System;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_TransporteExterno_Logistica.Repositorio
{
    public class ClsRepositorioRutaSeguimiento : ClsRepositorio
    {
        // Ejecutar consultas y devolver los resultados.
        private DataTable LogisticaFuncConsultar(
            string consulta,
            params object[] parametros)
        {
            using (OdbcConnection conexion =
                LogisticaMetObtenerConexion())
            {
                using (OdbcCommand comando =
                    new OdbcCommand(consulta, conexion))
                {
                    foreach (object parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(
                            "?", parametro ?? DBNull.Value);
                    }

                    using (OdbcDataAdapter adaptador =
                        new OdbcDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        // Ejecutar operaciones de inserción, modificación y eliminación.
        private int LogisticaFuncEjecutar(
            string consulta,
            params object[] parametros)
        {
            using (OdbcConnection conexion =
                LogisticaMetObtenerConexion())
            {
                using (OdbcCommand comando =
                    new OdbcCommand(consulta, conexion))
                {
                    foreach (object parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(
                            "?", parametro ?? DBNull.Value);
                    }

                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
        }

        // Obtener números de guía registrados.
        public DataTable LogisticaFuncObtenerGuias()
        {
            return LogisticaFuncConsultar(
                @"SELECT
                    Pk_ServicioTransporteExterno AS Id,
                    numeroGuiaServicioTransporteExterno AS Guia
                  FROM tblServicioTransporteExterno
                  WHERE numeroGuiaServicioTransporteExterno IS NOT NULL
                  ORDER BY Pk_ServicioTransporteExterno DESC");
        }

        // Obtener catálogo de bodegas.
        public DataTable LogisticaFuncObtenerBodegas()
        {
            return LogisticaFuncConsultar(
                @"SELECT
                    idBodega AS Id,
                    nombreBodega AS Nombre,
                    direccionBodega AS Direccion
                  FROM tblbodega
                  ORDER BY nombreBodega");
        }

        // Obtener la ruta de un transporte.
        public DataTable LogisticaFuncObtenerRuta(int idServicio)
        {
            return LogisticaFuncConsultar(
                @"SELECT
                    origenServicioTransporteExterno AS Origen,
                    direccionOrigenServicioTransporteExterno AS DireccionOrigen,
                    destinoServicioTransporteExterno AS Destino,
                    direccionDestinoServicioTransporteExterno AS DireccionDestino,
                    estadoServicioTransporteExterno AS Estado,
                    Fk_Traslado_IdTraslado AS IdTraslado
                  FROM tblServicioTransporteExterno
                  WHERE Pk_ServicioTransporteExterno = ?",
                idServicio);
        }

        // Obtener bodegas relacionadas con un traslado.
        public DataTable LogisticaFuncObtenerBodegasTraslado(
            int idTraslado)
        {
            return LogisticaFuncConsultar(
                @"SELECT
                    fkBodegaOrigenIdBodega AS IdOrigen,
                    fkBodegaDestinoIdBodega AS IdDestino
                  FROM tbltraslado
                  WHERE idTraslado = ?",
                idTraslado);
        }

        // Obtener la última ubicación registrada.(PENDIENTE)
        public DataTable LogisticaFuncObtenerUbicacion(
            int idServicio)
        {
            return LogisticaFuncConsultar(
                @"SELECT
                    ubicacionActualTransporte AS Ubicacion,
                    fechaActualizacionUbicacionTransporte AS Fecha
                  FROM tblUbicacionTransporte
                  WHERE Fk_ServicioTransporteExterno_Codigo = ?
                  ORDER BY fechaActualizacionUbicacionTransporte DESC,
                           Pk_UbicacionTransporte DESC
                  LIMIT 1",
                idServicio);
        }

        // Agregar o modificar la ruta del transporte.
        public int LogisticaMetGuardarRuta(
            int idServicio,
            string origen,
            string direccionOrigen,
            string destino,
            string direccionDestino)
        {
            return LogisticaFuncEjecutar(
                @"UPDATE tblServicioTransporteExterno
                  SET origenServicioTransporteExterno = ?,
                      direccionOrigenServicioTransporteExterno = ?,
                      destinoServicioTransporteExterno = ?,
                      direccionDestinoServicioTransporteExterno = ?
                  WHERE Pk_ServicioTransporteExterno = ?",
                origen,
                direccionOrigen,
                destino,
                direccionDestino,
                idServicio);
        }

        // Eliminar únicamente los datos de ruta., No elimina el transporte ni su número de guía.
        public int LogisticaMetEliminarRuta(int idServicio)
        {
            return LogisticaFuncEjecutar(
                @"UPDATE tblServicioTransporteExterno
                  SET origenServicioTransporteExterno = NULL,
                      direccionOrigenServicioTransporteExterno = NULL,
                      destinoServicioTransporteExterno = NULL,
                      direccionDestinoServicioTransporteExterno = NULL
                  WHERE Pk_ServicioTransporteExterno = ?",
                idServicio);
        }

        // Registrar una nueva ubicación del transporte.
        public int LogisticaMetGuardarUbicacion(
            int idServicio,
            string ubicacion)
        {
            return LogisticaFuncEjecutar(
                @"INSERT INTO tblUbicacionTransporte
                    (
                        Fk_ServicioTransporteExterno_Codigo,
                        ubicacionActualTransporte,
                        fechaActualizacionUbicacionTransporte
                    )
                  VALUES (?, ?, NOW())",
                idServicio,
                ubicacion);
        }
    }
}

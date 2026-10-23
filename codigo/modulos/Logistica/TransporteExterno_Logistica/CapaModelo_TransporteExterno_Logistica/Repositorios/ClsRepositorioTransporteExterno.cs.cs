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
    public class ClsRepositorioTransporteExterno : ClsRepositorio
    {
        // Obtener todos los transportes.
        public DataTable LogisticaFuncObtenerTransportes()
        {
            return LogisticaFuncConsultar(
                "SELECT * FROM tblServicioTransporteExterno");
        }

        // Obtener empresas transportistas.
        public DataTable LogisticaFuncObtenerEmpresas()
        {
            return LogisticaFuncConsultar(
                @"SELECT Pk_EmpresaTransportista,
                         nombreEmpresaTransportista,
                         contactoEmpresaTransportista
                  FROM tblEmpresaTransportista
                  WHERE is_active = 1
                  ORDER BY nombreEmpresaTransportista");
        }

        // Obtener tipos de servicio.
        public DataTable LogisticaFuncObtenerTiposServicio()
        {
            return LogisticaFuncConsultar(
                @"SELECT Pk_TipoServicio, nombreTipoServicio
                  FROM tblTipoServicio
                  WHERE is_active = 1
                  ORDER BY nombreTipoServicio");
        }

        // Obtener transportes con sus datos relacionados.
        public DataTable LogisticaFuncObtenerRegistroTransportes()
        {
            return LogisticaFuncConsultar(
                @"SELECT s.Pk_ServicioTransporteExterno,
                         s.numeroGuiaServicioTransporteExterno,
                         s.Fk_EmpresaTransportista_Codigo,
                         s.Fk_TipoServicio_Codigo,
                         s.estadoServicioTransporteExterno,
                         s.fechaContratacionServicioTransporteExterno,
                         s.fechaEstimadaEntregaServicioTransporteExterno,
                         s.fechaEntregaRealServicioTransporteExterno,
                         e.contactoEmpresaTransportista,
                         v.placaVehiculoTransporte,
                         v.tipoVehiculoTransporte,
                         v.capacidadVehiculoTransporte,
                         c.nombreConductorTransporte,
                         c.telefonoConductorTransporte,
                         p.codigoSolicitudPagoTransporte
                  FROM tblServicioTransporteExterno s
                  INNER JOIN tblEmpresaTransportista e
                    ON e.Pk_EmpresaTransportista =
                       s.Fk_EmpresaTransportista_Codigo
                  LEFT JOIN tblVehiculoTransporte v
                    ON v.Fk_ServicioTransporteExterno_Codigo =
                       s.Pk_ServicioTransporteExterno
                  LEFT JOIN tblConductorTransporte c
                    ON c.Fk_ServicioTransporteExterno_Codigo =
                       s.Pk_ServicioTransporteExterno
                  LEFT JOIN tblSolicitudPagoTransporte p
                    ON p.Fk_ServicioTransporteExterno_Codigo =
                       s.Pk_ServicioTransporteExterno
                  ORDER BY s.Pk_ServicioTransporteExterno DESC");
        }

        // Ejecutar consultas y devolver un DataTable.
        private DataTable LogisticaFuncConsultar(string sql)
        {
            DataTable tabla = new DataTable();

            using (OdbcConnection conexion =
                LogisticaMetObtenerConexion())
            using (OdbcCommand comando =
                new OdbcCommand(sql, conexion))
            using (OdbcDataAdapter adaptador =
                new OdbcDataAdapter(comando))
            {
                conexion.Open();
                adaptador.Fill(tabla);
            }

            return tabla;
        }

        // Obtener los próximos códigos.
        public DataTable LogisticaFuncObtenerProximosCodigos()
        {
            return LogisticaFuncConsultar(
                @"SELECT
                    (SELECT AUTO_INCREMENT
                     FROM information_schema.TABLES
                     WHERE TABLE_SCHEMA = DATABASE()
                       AND TABLE_NAME =
                           'tblServicioTransporteExterno')
                     AS siguienteTransporte,
                    (SELECT AUTO_INCREMENT
                     FROM information_schema.TABLES
                     WHERE TABLE_SCHEMA = DATABASE()
                       AND TABLE_NAME =
                           'tblSolicitudPagoTransporte')
                     AS siguienteSolicitud");
        }

        // Obtener prefijo de la guía.
        private string LogisticaFuncPrefijoEmpresa(string nombre)
        {
            switch ((nombre ?? "").Trim().ToUpperInvariant())
            {
                case "CARGO EXPRESO":
                    return "CE";
                case "GUATEX":
                    return "GX";
                case "DHL":
                case "DHL EXPRESS":
                    return "DHL";
                case "FEDEX":
                    return "FX";
                case "UPS":
                    return "UPS";
                case "FORZA":
                    return "FZ";
                default:
                    return "TR";
            }
        }

        // Registrar transporte, vehículo, conductor y solicitud.
        public DataTable LogisticaFuncAgregarTransporte(
            int empresa,
            int tipo,
            string estado,
            DateTime contratacion,
            DateTime estimada,
            DateTime? real,
            string placa,
            string tipoVehiculo,
            string capacidad,
            string conductor,
            string telefono)
        {
            DataTable resultado = new DataTable();

            resultado.Columns.Add("idServicio", typeof(int));
            resultado.Columns.Add("numeroGuia", typeof(string));
            resultado.Columns.Add("idSolicitud", typeof(int));
            resultado.Columns.Add("codigoSolicitudPago", typeof(string));

            using (OdbcConnection conexion =
                LogisticaMetObtenerConexion())
            {
                conexion.Open();

                using (OdbcTransaction transaccion =
                    conexion.BeginTransaction())
                {
                    try
                    {
                        string nombreEmpresa;

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"SELECT nombreEmpresaTransportista
                              FROM tblEmpresaTransportista
                              WHERE Pk_EmpresaTransportista = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue(
                                "@empresa", empresa);

                            object nombre = cmd.ExecuteScalar();

                            if (nombre == null ||
                                nombre == DBNull.Value)
                            {
                                throw new Exception(
                                    "La empresa transportista no existe.");
                            }

                            nombreEmpresa = Convert.ToString(nombre);
                        }

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"INSERT INTO tblServicioTransporteExterno
                              (
                                Fk_EmpresaTransportista_Codigo,
                                Fk_TipoServicio_Codigo,
                                estadoServicioTransporteExterno,
                                origenServicioTransporteExterno,
                                destinoServicioTransporteExterno,
                                fechaContratacionServicioTransporteExterno,
                                fechaEstimadaEntregaServicioTransporteExterno,
                                fechaEntregaRealServicioTransporteExterno
                              )
                              VALUES (?, ?, ?, ?, ?, ?, ?, ?)",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue(
                                "@empresa", empresa);
                            cmd.Parameters.AddWithValue("@tipo", tipo);
                            cmd.Parameters.AddWithValue("@estado", estado);
                            cmd.Parameters.AddWithValue("@origen", "");
                            cmd.Parameters.AddWithValue("@destino", "");
                            cmd.Parameters.AddWithValue(
                                "@contratacion", contratacion.Date);
                            cmd.Parameters.AddWithValue(
                                "@estimada", estimada.Date);
                            cmd.Parameters.AddWithValue(
                                "@real",
                                real.HasValue
                                    ? (object)real.Value.Date
                                    : DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }

                        int idServicio;

                        using (OdbcCommand cmd = new OdbcCommand(
                            "SELECT LAST_INSERT_ID()",
                            conexion, transaccion))
                        {
                            idServicio = Convert.ToInt32(
                                cmd.ExecuteScalar());
                        }

                        string guia =
                            LogisticaFuncPrefijoEmpresa(nombreEmpresa) +
                            "-" + idServicio.ToString("D6");

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"UPDATE tblServicioTransporteExterno
                              SET numeroGuiaServicioTransporteExterno = ?
                              WHERE Pk_ServicioTransporteExterno = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@guia", guia);
                            cmd.Parameters.AddWithValue("@id", idServicio);
                            cmd.ExecuteNonQuery();
                        }

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"INSERT INTO tblVehiculoTransporte
                              (
                                Fk_ServicioTransporteExterno_Codigo,
                                placaVehiculoTransporte,
                                tipoVehiculoTransporte,
                                capacidadVehiculoTransporte
                              )
                              VALUES (?, ?, ?, ?)",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", idServicio);
                            cmd.Parameters.AddWithValue("@placa", placa);
                            cmd.Parameters.AddWithValue(
                                "@tipo", tipoVehiculo);
                            cmd.Parameters.AddWithValue(
                                "@capacidad", capacidad);
                            cmd.ExecuteNonQuery();
                        }

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"INSERT INTO tblConductorTransporte
                              (
                                Fk_ServicioTransporteExterno_Codigo,
                                nombreConductorTransporte,
                                telefonoConductorTransporte
                              )
                              VALUES (?, ?, ?)",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", idServicio);
                            cmd.Parameters.AddWithValue(
                                "@nombre", conductor);
                            cmd.Parameters.AddWithValue(
                                "@telefono", telefono);
                            cmd.ExecuteNonQuery();
                        }

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"INSERT INTO tblSolicitudPagoTransporte
                              (
                                Fk_ServicioTransporteExterno_Codigo,
                                estadoSolicitudPagoTransporte
                              )
                              VALUES (?, ?)",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", idServicio);
                            cmd.Parameters.AddWithValue(
                                "@estado", "Pendiente");
                            cmd.ExecuteNonQuery();
                        }

                        int idSolicitud;

                        using (OdbcCommand cmd = new OdbcCommand(
                            "SELECT LAST_INSERT_ID()",
                            conexion, transaccion))
                        {
                            idSolicitud = Convert.ToInt32(
                                cmd.ExecuteScalar());
                        }

                        string codigo =
                            "SP-" + idSolicitud.ToString("D6");

                        using (OdbcCommand cmd = new OdbcCommand(
                            @"UPDATE tblSolicitudPagoTransporte
                              SET codigoSolicitudPagoTransporte = ?
                              WHERE Pk_SolicitudPagoTransporte = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.Parameters.AddWithValue("@id", idSolicitud);
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();

                        resultado.Rows.Add(
                            idServicio, guia, idSolicitud, codigo);

                        return resultado;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        // Modificar transporte, vehículo y conductor.
        public void LogisticaMetModificarTransporte(
            int id,
            int empresa,
            int tipo,
            string estado,
            DateTime contratacion,
            DateTime estimada,
            DateTime? real,
            string placa,
            string tipoVehiculo,
            string capacidad,
            string conductor,
            string telefono)
        {
            using (OdbcConnection conexion =
                LogisticaMetObtenerConexion())
            {
                conexion.Open();

                using (OdbcTransaction transaccion =
                    conexion.BeginTransaction())
                {
                    try
                    {
                        using (OdbcCommand comando = new OdbcCommand(
                            @"UPDATE tblServicioTransporteExterno
                              SET Fk_EmpresaTransportista_Codigo = ?,
                                  Fk_TipoServicio_Codigo = ?,
                                  estadoServicioTransporteExterno = ?,
                                  fechaContratacionServicioTransporteExterno = ?,
                                  fechaEstimadaEntregaServicioTransporteExterno = ?,
                                  fechaEntregaRealServicioTransporteExterno = ?
                              WHERE Pk_ServicioTransporteExterno = ?",
                            conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue(
                                "@empresa", empresa);
                            comando.Parameters.AddWithValue("@tipo", tipo);
                            comando.Parameters.AddWithValue(
                                "@estado", estado);
                            comando.Parameters.AddWithValue(
                                "@contratacion", contratacion.Date);
                            comando.Parameters.AddWithValue(
                                "@estimada", estimada.Date);
                            comando.Parameters.AddWithValue(
                                "@real",
                                real.HasValue
                                    ? (object)real.Value.Date
                                    : DBNull.Value);
                            comando.Parameters.AddWithValue("@id", id);

                            comando.ExecuteNonQuery();
                        }

                        using (OdbcCommand comando = new OdbcCommand(
                            @"INSERT INTO tblVehiculoTransporte
                              (
                                Fk_ServicioTransporteExterno_Codigo,
                                placaVehiculoTransporte,
                                tipoVehiculoTransporte,
                                capacidadVehiculoTransporte
                              )
                              VALUES (?, ?, ?, ?)
                              ON DUPLICATE KEY UPDATE
                                placaVehiculoTransporte =
                                    VALUES(placaVehiculoTransporte),
                                tipoVehiculoTransporte =
                                    VALUES(tipoVehiculoTransporte),
                                capacidadVehiculoTransporte =
                                    VALUES(capacidadVehiculoTransporte)",
                            conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@placa", placa);
                            comando.Parameters.AddWithValue(
                                "@tipo", tipoVehiculo);
                            comando.Parameters.AddWithValue(
                                "@capacidad", capacidad);

                            comando.ExecuteNonQuery();
                        }

                        using (OdbcCommand comando = new OdbcCommand(
                            @"INSERT INTO tblConductorTransporte
                              (
                                Fk_ServicioTransporteExterno_Codigo,
                                nombreConductorTransporte,
                                telefonoConductorTransporte
                              )
                              VALUES (?, ?, ?)
                              ON DUPLICATE KEY UPDATE
                                nombreConductorTransporte =
                                    VALUES(nombreConductorTransporte),
                                telefonoConductorTransporte =
                                    VALUES(telefonoConductorTransporte)",
                            conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue(
                                "@nombre", conductor);
                            comando.Parameters.AddWithValue(
                                "@telefono", telefono);

                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        // Eliminar transporte sin importar su estado.
        public void LogisticaMetEliminarTransporte(int id)
        {
            using (OdbcConnection conexion =
                LogisticaMetObtenerConexion())
            {
                conexion.Open();

                using (OdbcTransaction transaccion =
                    conexion.BeginTransaction())
                {
                    try
                    {
                        using (OdbcCommand cmd = new OdbcCommand(
                            @"SELECT Pk_ServicioTransporteExterno
                              FROM tblServicioTransporteExterno
                              WHERE Pk_ServicioTransporteExterno = ?
                              FOR UPDATE",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", id);

                            object valor = cmd.ExecuteScalar();

                            if (valor == null || valor == DBNull.Value)
                            {
                                throw new Exception(
                                    "El transporte no existe.");
                            }
                        }

                        // Primero eliminar la solicitud de pago.
                        using (OdbcCommand cmd = new OdbcCommand(
                            @"DELETE FROM tblSolicitudPagoTransporte
                              WHERE Fk_ServicioTransporteExterno_Codigo = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // Eliminar conductor.
                        using (OdbcCommand cmd = new OdbcCommand(
                            @"DELETE FROM tblConductorTransporte
                              WHERE Fk_ServicioTransporteExterno_Codigo = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // Eliminar vehículo.
                        using (OdbcCommand cmd = new OdbcCommand(
                            @"DELETE FROM tblVehiculoTransporte
                              WHERE Fk_ServicioTransporteExterno_Codigo = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // Eliminar transporte.
                        using (OdbcCommand cmd = new OdbcCommand(
                            @"DELETE FROM tblServicioTransporteExterno
                              WHERE Pk_ServicioTransporteExterno = ?",
                            conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", id);

                            int filas = cmd.ExecuteNonQuery();

                            if (filas == 0)
                            {
                                throw new Exception(
                                    "No se pudo eliminar el transporte.");
                            }
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

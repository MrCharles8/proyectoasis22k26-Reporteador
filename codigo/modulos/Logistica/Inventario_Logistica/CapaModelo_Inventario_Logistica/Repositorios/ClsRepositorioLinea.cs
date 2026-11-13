
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsRepositorioLinea.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Consulta los registros almacenados en tblLinea
 * mediante la conexión ODBC del sistema ERP.
 *
 * Recupera los datos de las líneas de productos
 * y los convierte en entidades para utilizarlos
 * en el reporte RDLC de líneas.
 * ============================================================================
 */

using System;
using System.Collections.Generic;
using System.Data;

using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Entidades;

namespace CapaModelo_Inventario_Logistica.Repositorios
{
    public class ClsRepositorioLinea :
        ClsRepositorioMaestro,
        ClsIRepositorioLinea
    {
        // ========================================================
        // CONSULTA SQL DE LÍNEAS
        // ========================================================

        private const string LogisticaSqlObtenerTodos = @"
            SELECT
                idLinea,
                nombreLinea,
                porcentajeComisionLinea,
                created_at,
                updated_at
            FROM tblLinea
            ORDER BY idLinea ASC";

        // ========================================================
        // OBTENER TODOS LOS REGISTROS
        // ========================================================

        public IEnumerable<ClsLinea> LogisticaMetObtenerTodos()
        {
            DataTable Tabla =
                LogisticaMetEjecucionConsulta(
                    LogisticaSqlObtenerTodos,
                    CommandType.Text);

            List<ClsLinea> Lista =
                new List<ClsLinea>();

            foreach (DataRow Fila in Tabla.Rows)
            {
                ClsLinea Linea = new ClsLinea
                {
                    IdLinea =
                        Convert.ToInt32(
                            Fila["idLinea"]),

                    NombreLinea =
                        Convert.ToString(
                            Fila["nombreLinea"]),

                    PorcentajeComisionLinea =
                        Convert.ToDecimal(
                            Fila["porcentajeComisionLinea"]),

                    CreatedAt =
                        Convert.ToDateTime(
                            Fila["created_at"]),

                    UpdatedAt =
                        Convert.ToDateTime(
                            Fila["updated_at"])
                };

                Lista.Add(Linea);
            }

            return Lista;
        }
    }
}


/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsRepositorioCategoria.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Realiza consultas a la tabla tblCategoria mediante
 * la conexión ODBC del sistema ERP.
 *
 * Obtiene los identificadores, nombres, porcentajes
 * de comisión y fechas de las categorías registradas,
 * convirtiendo los resultados en entidades para
 * utilizarlos en la generación del reporte RDLC.
 * ============================================================================
 */


using System;
using System.Collections.Generic;
using System.Data;

using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Entidades;

namespace CapaModelo_Inventario_Logistica.Repositorios
{
    public class ClsRepositorioCategoria :
        ClsRepositorioMaestro,
        ClsIRepositorioCategoria
    {
        // ========================================================
        // CONSULTAR CATEGORÍAS
        // ========================================================

        public IEnumerable<ClsCategoria>
            LogisticaMetObtenerTodos()
        {
            string Sql = @"
                SELECT
                    idCategoria,
                    nombreCategoria,
                    porcentajeComisionCategoria,
                    created_at,
                    updated_at
                FROM tblCategoria
                ORDER BY idCategoria ASC";

            DataTable Tabla =
                LogisticaMetEjecucionConsulta(
                    Sql,
                    CommandType.Text);

            List<ClsCategoria> Lista =
                new List<ClsCategoria>();

            foreach (DataRow Fila in Tabla.Rows)
            {
                Lista.Add(new ClsCategoria
                {
                    IdCategoria =
                        Convert.ToInt32(
                            Fila["idCategoria"]),

                    NombreCategoria =
                        Convert.ToString(
                            Fila["nombreCategoria"]),

                    PorcentajeComisionCategoria =
                        Convert.ToDecimal(
                            Fila["porcentajeComisionCategoria"]),

                    CreatedAt =
                        Convert.ToDateTime(
                            Fila["created_at"]),

                    UpdatedAt =
                        Convert.ToDateTime(
                            Fila["updated_at"])
                });
            }

            return Lista;
        }
    }
}

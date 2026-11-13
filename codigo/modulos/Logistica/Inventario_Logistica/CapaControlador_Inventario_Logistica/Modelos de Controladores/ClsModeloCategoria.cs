
/*
 * ============================================================================
 * MÓDULO: LOGÍSTICA - INVENTARIO
 * ARCHIVO: ClsModeloCategoria.cs
 *
 * REALIZADO POR: NILLS BERDUCIDO GÓMEZ
 * CARNÉ: 0901 23 14275
 * FECHA DE REALIZACIÓN: 13/11/2026
 *
 * DESCRIPCIÓN:
 * Coordina la obtención de información de las categorías
 * entre la Capa Modelo y la Capa Vista.
 *
 * Utiliza el repositorio para consultar los registros
 * existentes y transforma las entidades en objetos
 * de datos que pueden ser utilizados por el reporte
 * RDLC de categorías.
 *
 * Implementa la arquitectura MVC del módulo Logística.
 * ============================================================================
 */


using System;
using System.Collections.Generic;
using System.Linq;

using CapaModelo_Inventario_Logistica.Contratos;
using CapaModelo_Inventario_Logistica.Repositorios;

namespace CapaControlador_Inventario_Logistica.Modelos_de_Controladores
{
    public class ClsModeloCategoria
    {
        private readonly ClsIRepositorioCategoria
            _Repositorio;

        // ========================================================
        // CONSTRUCTOR PRINCIPAL
        // ========================================================

        public ClsModeloCategoria()
        {
            _Repositorio =
                new ClsRepositorioCategoria();
        }

        // ========================================================
        // CONSTRUCTOR PARA PRUEBAS UNITARIAS
        // ========================================================

        public ClsModeloCategoria(
            ClsIRepositorioCategoria Repositorio)
        {
            if (Repositorio == null)
            {
                throw new ArgumentNullException(
                    nameof(Repositorio));
            }

            _Repositorio = Repositorio;
        }

        // ========================================================
        // OBTENER TODAS LAS CATEGORÍAS
        // ========================================================

        public List<ClsDatosCategoria>
            LogisticaFuncObtenerTodos()
        {
            return _Repositorio
                .LogisticaMetObtenerTodos()
                .Select(C => new ClsDatosCategoria
                {
                    IdCategoria =
                        C.IdCategoria,

                    NombreCategoria =
                        C.NombreCategoria,

                    PorcentajeComisionCategoria =
                        C.PorcentajeComisionCategoria,

                    FechaCreacion =
                        C.CreatedAt,

                    FechaActualizacion =
                        C.UpdatedAt
                })
                .ToList();
        }
    }
}

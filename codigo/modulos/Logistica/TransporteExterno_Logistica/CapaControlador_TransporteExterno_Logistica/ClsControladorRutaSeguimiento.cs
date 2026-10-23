// ------------------------------------------------------
// Autor: Gabriela Pinto García
// Carné: 9959-23-1087
// Fecha: 21/10/2026
// Módulo: Logística - Transporte Externo
// ------------------------------------------------------
using System;
using System.Data;
using CapaModelo_TransporteExterno_Logistica.Repositorio;

namespace CapaControlador_TransporteExterno_Logistica
{
    public class ClsControladorRutaSeguimiento
    {
        private readonly ClsRepositorioRutaSeguimiento _Repositorio;

        public ClsControladorRutaSeguimiento()
        {
            _Repositorio = new ClsRepositorioRutaSeguimiento();
        }

        // Obtener los números de guía registrados.
        public DataTable LogisticaFuncObtenerGuias()
        {
            return _Repositorio.LogisticaFuncObtenerGuias();
        }

        // Obtener el catálogo de bodegas.
        public DataTable LogisticaFuncObtenerBodegas()
        {
            return _Repositorio.LogisticaFuncObtenerBodegas();
        }

        // Obtener los datos de la ruta de un transporte.
        public DataTable LogisticaFuncObtenerRuta(int idServicio)
        {
            return _Repositorio.LogisticaFuncObtenerRuta(idServicio);
        }

        // Obtener bodegas relacionadas con un traslado.
        public DataTable LogisticaFuncObtenerBodegasTraslado(int idTraslado)
        {
            return _Repositorio.LogisticaFuncObtenerBodegasTraslado(
                idTraslado);
        }

        // Obtener la última ubicación registrada.
        public DataTable LogisticaFuncObtenerUbicacion(int idServicio)
        {
            return _Repositorio.LogisticaFuncObtenerUbicacion(
                idServicio);
        }

        // Verificar si el transporte tiene una ruta registrada.
        public bool LogisticaFuncTieneRuta(DataRow ruta)
        {
            if (ruta == null)
            {
                return false;
            }

            string origen = Convert.ToString(ruta["Origen"]);
            string destino = Convert.ToString(ruta["Destino"]);

            return !string.IsNullOrWhiteSpace(origen) &&
                   !string.IsNullOrWhiteSpace(destino);
        }

        // Validar los datos de origen y destino.
        private void LogisticaMetValidarRuta(
            int idServicio,
            DataRow origen,
            DataRow destino)
        {
            if (idServicio <= 0)
            {
                throw new Exception(
                    "Debes seleccionar un número de guía.");
            }

            if (origen == null)
            {
                throw new Exception(
                    "Debes seleccionar una bodega de origen.");
            }

            if (destino == null)
            {
                throw new Exception(
                    "Debes seleccionar una bodega de destino.");
            }

            int idOrigen = Convert.ToInt32(origen["Id"]);
            int idDestino = Convert.ToInt32(destino["Id"]);

            if (idOrigen == idDestino)
            {
                throw new Exception(
                    "La bodega de origen y destino deben ser diferentes.");
            }
        }

        // Agregar una ruta a un transporte registrado.
        public void LogisticaMetAgregarRuta(
            int idServicio,
            DataRow origen,
            DataRow destino)
        {
            LogisticaMetValidarRuta(
                idServicio,
                origen,
                destino);

            DataTable tabla =
                _Repositorio.LogisticaFuncObtenerRuta(idServicio);

            if (tabla.Rows.Count == 0)
            {
                throw new Exception(
                    "No existe el transporte seleccionado.");
            }

            if (LogisticaFuncTieneRuta(tabla.Rows[0]))
            {
                throw new Exception(
                    "Este transporte ya tiene una ruta registrada. Utiliza Modificar.");
            }

            int resultado = _Repositorio.LogisticaMetGuardarRuta(
                idServicio,
                Convert.ToString(origen["Nombre"]),
                Convert.ToString(origen["Direccion"]),
                Convert.ToString(destino["Nombre"]),
                Convert.ToString(destino["Direccion"]));

            if (resultado <= 0)
            {
                throw new Exception(
                    "No se pudo agregar la ruta.");
            }
        }

        // Modificar una ruta existente.
        // También permite completar una ruta vacía.
        public void LogisticaMetModificarRuta(
            int idServicio,
            DataRow origen,
            DataRow destino)
        {
            LogisticaMetValidarRuta(
                idServicio,
                origen,
                destino);

            DataTable tabla =
                _Repositorio.LogisticaFuncObtenerRuta(idServicio);

            if (tabla.Rows.Count == 0)
            {
                throw new Exception(
                    "No existe el transporte seleccionado.");
            }

            int resultado = _Repositorio.LogisticaMetGuardarRuta(
                idServicio,
                Convert.ToString(origen["Nombre"]),
                Convert.ToString(origen["Direccion"]),
                Convert.ToString(destino["Nombre"]),
                Convert.ToString(destino["Direccion"]));

            if (resultado <= 0)
            {
                throw new Exception(
                    "No se pudo modificar la ruta.");
            }
        }

        // Eliminar únicamente los datos de la ruta.
        // Conserva el transporte y su número de guía.
        public void LogisticaMetEliminarRuta(int idServicio)
        {
            if (idServicio <= 0)
            {
                throw new Exception(
                    "Debes seleccionar un número de guía.");
            }

            DataTable tabla =
                _Repositorio.LogisticaFuncObtenerRuta(idServicio);

            if (tabla.Rows.Count == 0)
            {
                throw new Exception(
                    "No existe el transporte seleccionado.");
            }

            if (!LogisticaFuncTieneRuta(tabla.Rows[0]))
            {
                throw new Exception(
                    "Este transporte no tiene una ruta registrada.");
            }

            int resultado =
                _Repositorio.LogisticaMetEliminarRuta(idServicio);

            if (resultado <= 0)
            {
                throw new Exception(
                    "No se pudo eliminar la ruta.");
            }
        }

        // Actualizar la ubicación actual del transporte.
        public void LogisticaMetActualizarUbicacion(
            int idServicio,
            string ubicacion)
        {
            if (idServicio <= 0)
            {
                throw new Exception(
                    "Debes seleccionar un número de guía.");
            }

            if (string.IsNullOrWhiteSpace(ubicacion))
            {
                throw new Exception(
                    "Debes ingresar la ubicación actual.");
            }

            DataTable tabla =
                _Repositorio.LogisticaFuncObtenerRuta(idServicio);

            if (tabla.Rows.Count == 0)
            {
                throw new Exception(
                    "No existe el transporte seleccionado.");
            }

            int resultado =
                _Repositorio.LogisticaMetGuardarUbicacion(
                    idServicio,
                    ubicacion.Trim());

            if (resultado <= 0)
            {
                throw new Exception(
                    "No se pudo actualizar la ubicación.");
            }
        }
    }
}

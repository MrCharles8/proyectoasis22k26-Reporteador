
// Autor: José Xavier Bolaños Tenas, carné 0901-23-2128.
// Propósito: validar las operaciones y coordinar el acceso a datos de traslados.

using System;
using System.Data;
using CapaModelo_Traslados_Logistica.Entidades;
using CapaModelo_Traslados_Logistica.Repositorios;

namespace CapaControlador_Traslados_Logistica
{
    public class ClsControladorTraslado
    {
        private readonly ClsRepositorioTraslado _RepositorioTraslado = new ClsRepositorioTraslado();

        // Obtiene las bodegas disponibles para origen y destino.
        public DataTable LogisticaFuncListarBodegas()
        {
            return _RepositorioTraslado.LogisticaFuncListarBodegas();
        }

        // Obtiene los productos activos que pueden agregarse a un traslado.
        public DataTable LogisticaFuncListarProductos()
        {
            return _RepositorioTraslado.LogisticaFuncListarProductos();
        }

        // Obtiene los transportes activos disponibles.
        public DataTable LogisticaFuncListarTransportes()
        {
            return _RepositorioTraslado.LogisticaFuncListarTransportes();
        }

        // Obtiene los traslados registrados.
        public DataTable LogisticaFuncListarTraslados()
        {
            return _RepositorioTraslado.LogisticaFuncListarTraslados();
        }

        // Construye la lista de estados válidos.
        public DataTable LogisticaFuncListarEstados()
        {
            DataTable TablaEstados = new DataTable();
            TablaEstados.Columns.Add("estadoTraslado", typeof(string));

            TablaEstados.Rows.Add("SOLICITADO");
            TablaEstados.Rows.Add("EN_TRANSITO");
            TablaEstados.Rows.Add("RECIBIDO");
            TablaEstados.Rows.Add("CANCELADO");

            return TablaEstados;
        }

        // Valida los datos y solicita guardar el traslado.
        public void LogisticaProcGuardarTraslado(
            string Codigo,
            int IdBodegaOrigen,
            int IdBodegaDestino,
            int? IdTransporte,
            DateTime? FechaSalida,
            string Estado,
            DataTable TablaDetalles,
            string Observaciones,
            DateTime? FechaLlegada = null)
        {
            if (String.IsNullOrWhiteSpace(Codigo))
            {
                throw new ArgumentException(
                    "Ingrese el código del traslado.");
            }

            if (Codigo.Trim().Length > 30)
            {
                throw new ArgumentException(
                    "El código no puede superar los 30 caracteres.");
            }

            if (IdBodegaOrigen <= 0 || IdBodegaDestino <= 0)
            {
                throw new ArgumentException(
                    "Seleccione las bodegas de origen y destino.");
            }

            if (IdBodegaOrigen == IdBodegaDestino)
            {
                throw new ArgumentException(
                    "La bodega de origen debe ser distinta de la bodega de destino.");
            }

            if (IdTransporte.HasValue && IdTransporte.Value <= 0)
            {
                throw new ArgumentException(
                    "Seleccione un transporte válido.");
            }

            if (Estado != "SOLICITADO" &&
                Estado != "EN_TRANSITO" &&
                Estado != "RECIBIDO" &&
                Estado != "CANCELADO")
            {
                throw new ArgumentException(
                    "Seleccione un estado de traslado válido.");
            }

            if (Observaciones == null)
            {
                throw new ArgumentException(
                    "Las observaciones no pueden ser NULL.");
            }

            if (Observaciones.Length > 500)
            {
                throw new ArgumentException(
                    "Las observaciones no pueden superar los 500 caracteres.");
            }

            if (FechaSalida.HasValue &&
                FechaLlegada.HasValue &&
                FechaLlegada.Value < FechaSalida.Value)
            {
                throw new ArgumentException(
                    "La fecha de llegada no puede ser anterior a la fecha de salida.");
            }

            if (TablaDetalles == null || TablaDetalles.Rows.Count == 0)
            {
                throw new ArgumentException(
                    "Agregue al menos un producto al traslado.");
            }

            foreach (DataRow Fila in TablaDetalles.Rows)
            {
                if (Convert.ToInt32(Fila["idProducto"]) <= 0 ||
                    Convert.ToInt32(Fila["cantidad"]) <= 0)
                {
                    throw new ArgumentException(
                        "Los productos y cantidades deben ser válidos.");
                }
            }

            ClsEntidadTraslado Traslado = new ClsEntidadTraslado
            {
                Codigo = Codigo.Trim(),
                IdBodegaOrigen = IdBodegaOrigen,
                IdBodegaDestino = IdBodegaDestino,
                IdTransporte = IdTransporte,
                FechaSolicitud = DateTime.Now,
                FechaSalida = FechaSalida,
                FechaLlegada = FechaLlegada,
                Estado = Estado,
                Observaciones = Observaciones
            };

            foreach (DataRow Fila in TablaDetalles.Rows)
            {
                Traslado.Detalles.Add(new ClsEntidadDetalleTraslado
                {
                    IdProducto = Convert.ToInt32(Fila["idProducto"]),
                    Cantidad = Convert.ToInt32(Fila["cantidad"])
                });
            }

            _RepositorioTraslado.LogisticaProcGuardarTraslado(Traslado);
        }
    }
}

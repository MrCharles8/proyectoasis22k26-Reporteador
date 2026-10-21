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

        // Obtiene los traslados registrados para mostrarlos en la vista.
        public DataTable LogisticaFuncListarTraslados()
        {
            return _RepositorioTraslado.LogisticaFuncListarTraslados();
        }

        // Construye la lista de estados válidos definida por el ENUM de la base de datos.
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

        // Valida los datos del traslado, crea sus entidades y solicita su persistencia.
        public void LogisticaProcGuardarTraslado(string Codigo, int IdBodegaOrigen, int IdBodegaDestino,
            int? IdTransporte, DateTime FechaSalida, string Estado, DataTable TablaDetalles)
        {
            if (String.IsNullOrWhiteSpace(Codigo))
            {
                throw new ArgumentException("Ingrese el código del traslado.");
            }
            if (IdBodegaOrigen <= 0 || IdBodegaDestino <= 0)
            {
                throw new ArgumentException("Seleccione las bodegas de origen y destino.");
            }
            if (IdBodegaOrigen == IdBodegaDestino)
            {
                throw new ArgumentException("La bodega de origen debe ser distinta de la bodega de destino.");
            }
            if (TablaDetalles == null || TablaDetalles.Rows.Count == 0)
            {
                throw new ArgumentException("Agregue al menos un producto al traslado.");
            }
            foreach (DataRow Fila in TablaDetalles.Rows)
            {
                if (Convert.ToInt32(Fila["idProducto"]) <= 0 || Convert.ToInt32(Fila["cantidad"]) <= 0)
                {
                    throw new ArgumentException("Los productos y cantidades deben ser válidos.");
                }
            }
            if (Estado != "SOLICITADO" && Estado != "EN_TRANSITO" && Estado != "RECIBIDO" && Estado != "CANCELADO")
            {
                throw new ArgumentException("Seleccione un estado de traslado válido.");
            }

            ClsEntidadTraslado Traslado = new ClsEntidadTraslado
            {
                Codigo = Codigo.Trim(),
                IdBodegaOrigen = IdBodegaOrigen,
                IdBodegaDestino = IdBodegaDestino,
                IdTransporte = IdTransporte,
                FechaSolicitud = DateTime.Now,
                FechaSalida = FechaSalida,
                Estado = Estado
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
// Autor: José Xavier Bolaños Tenas, carné 0901-23-2128.
// Propósito: representar los datos de cabecera y detalle de un traslado.

using System;
using System.Collections.Generic;

namespace CapaModelo_Traslados_Logistica.Entidades
{
    public class ClsEntidadTraslado
    {
        public string Codigo { get; set; }
        public int IdBodegaOrigen { get; set; }
        public int IdBodegaDestino { get; set; }
        public int? IdTransporte { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public List<ClsEntidadDetalleTraslado> Detalles { get; set; }
            = new List<ClsEntidadDetalleTraslado>();
    }
}
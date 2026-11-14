using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_TransporteInterno_Logistica.Entidades
{
    public class ClsTransporte
    {
        public int IdTransporte { get; set; }

        public string NroPlacaTransporte { get; set; }

        public string MarcaTransporte { get; set; }

        public string ModeloTransporte { get; set; }

        public int AnioTransporte { get; set; }

        public bool EsRefrigeradoTransporte { get; set; }

        public int FkEstadoCodigo { get; set; }

        public int FkTipoTransporteCodigo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

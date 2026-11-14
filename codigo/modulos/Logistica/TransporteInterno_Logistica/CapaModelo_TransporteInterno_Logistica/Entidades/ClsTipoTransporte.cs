using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_TransporteInterno_Logistica.Entidades
{
    public class ClsTipoTransporte
    {
        public int IdTipoTransporte { get; set; }

        public string NombreTipoTransporte { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

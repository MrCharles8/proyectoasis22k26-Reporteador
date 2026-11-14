using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_TransporteInterno_Logistica.Entidades
{
    public class ClsCamaraRefrigeracion
    {
        public int IdCamaraRefrigeracion { get; set; }

        public int FkTransporteCodigo { get; set; }

        public string MarcaEquipoCamaraRefrigeracion
        {
            get;
            set;
        }

        public decimal TempMinimaCelsiusCamaraRefrigeracion
        {
            get;
            set;
        }

        public decimal TempMaximaCelsiusCamaraRefrigeracion
        {
            get;
            set;
        }

        public string EstadoOperativoCamaraRefrigeracion
        {
            get;
            set;
        }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

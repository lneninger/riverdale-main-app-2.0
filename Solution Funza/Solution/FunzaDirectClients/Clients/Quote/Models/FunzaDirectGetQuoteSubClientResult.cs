using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote.Models
{
    public class FunzaDirectGetQuoteSubClientResult
    {
        public int Id { get; set; }

        public string Codigo { get; set; }//": "3-1501",

        public string Nombre { get; set; }//": "Generic",

        public decimal Margen { get; set; }//": 0.08,

        public bool Estado { get; set; }//": true,

        public int ClienteId { get; set; }//": 3,

        public string ClienteNombre { get; set; }//": "RIVERDALE FARMS, LLC.",
    }
}

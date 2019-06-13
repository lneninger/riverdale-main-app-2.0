using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote.Models
{
    public class FunzaDirectGetQuoteSubClientResult
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public decimal Margen { get; set; }

        public bool Estado { get; set; }

        public int? ClienteId { get; set; }

        public string ClienteNombre { get; set; }
    }
}

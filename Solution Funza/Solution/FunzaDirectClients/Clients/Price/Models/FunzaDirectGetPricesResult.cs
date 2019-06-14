using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.Clients.Price.Models
{
    public class FunzaDirectGetPricesResult
    {
        public int id { get; set; }

        public int valor { get; set; }

        public int temporadaId { get; set; }

        public bool activo { get; set; }

        public int productoId { get; set; }

        public string codigo { get; set; }

        public FunzaDirectGetPricesSeasonResult Temporada { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.Clients.Price.Models
{
    public class FunzaDirectGetPricesSeasonResult
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public bool activo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Season.Models
{
    public class FunzaDirectGetSeasonsResult
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; }
    }
}

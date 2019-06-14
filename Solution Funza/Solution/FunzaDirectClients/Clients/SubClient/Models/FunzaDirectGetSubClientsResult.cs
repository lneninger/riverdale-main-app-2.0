using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.SubClient.Models
{
    public class FunzaDirectGetSubClientsResult
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string Codigo { get; set; }

        public string Name { get; set; }

        public int Margen { get; set; }

        public bool Estado { get; set; }

        public IEnumerable<FunzaDirectGetSubClientsUserReleationResult> UsersRelation { get; set; }

        public int? AdjustRequestUserId { get; set; }//": 23,

        public int? PasoCreacion { get; set; }//": 5,


        public FunzaDirectGetQuoteSubClientResult SubCliente { get; set; }
    }
}

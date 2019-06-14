using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.GoodSeason.Models
{
    public class FunzaDirectGetGoodPricesResult
    {
        public int Id { get; set; }//": 0

        public string Codigo { get; set; }//": "string",

        public string Categoria { get; set; }//": "string",

        public int IdCategoria { get; set; }//": 0,

        public string Descripcion { get; set; }//": "string",

        public string UnidadMedida { get; set; }//": "string",

        public bool Activo { get; set; }//": true,

        public int InsumoId { get; set; }//": 0,

        public int Valor { get; set; }//": 0,
    }
}

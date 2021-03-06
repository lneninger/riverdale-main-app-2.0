﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Quote.Models
{
    public class FunzaDirectGetQuoteResult
    {
        public string Titulo { get; set; }//": "Sunlight ",

        public int? Estado { get; set; }//": 4,

        public int? AdjustRequestUserId { get; set; }//": 23,

        public int? PasoCreacion { get; set; }//": 5,

        public string Codigo { get; set; }//": "BQ3064",

        public FunzaDirectGetQuoteSubClientResult SubCliente { get; set; }
    }
}

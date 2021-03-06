﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.Clients.Price.Models
{
    public class DirectGetPricesResult
    {
        public int Id { get; set; }

        public int Valor { get; set; }

        public int TemporadaId { get; set; }

        public bool Activo { get; set; }

        public int ProductoId { get; set; }

        public string Codigo { get; set; }

        public DirectGetPricesSeasonResult Temporada { get; set; }
    }
}

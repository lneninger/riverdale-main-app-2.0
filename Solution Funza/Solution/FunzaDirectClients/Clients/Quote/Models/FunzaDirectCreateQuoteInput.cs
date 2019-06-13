using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.InternalClients.Quote.Models
{
    public class FunzaDirectCreateQuoteInput
    {
        /// <summary>
        /// Gets or sets the titulo.
        /// </summary>
        /// <value>
        /// The titulo.
        /// </value>
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets the tipo producto identifier.
        /// </summary>
        /// <value>
        /// The tipo producto identifier.
        /// </value>
        public int TipoProductoId { get; set; }

        /// <summary>
        /// Gets or sets the temporada identifier.
        /// </summary>
        /// <value>
        /// The temporada identifier.
        /// </value>
        public int TemporadaId { get; set; }
    }
}

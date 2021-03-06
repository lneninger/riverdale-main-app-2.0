﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaInternalClients.Quote.Models
{
    public class InternalBridgeCreateQuoteInput
    {
        /// <summary>
        /// Gets or sets the internal identifier.
        /// </summary>
        /// <value>
        /// The internal identifier.
        /// </value>
        public int InternalId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        public int SeasonId { get; set; }
        public int ProductTypeId { get; set; }
    }
}

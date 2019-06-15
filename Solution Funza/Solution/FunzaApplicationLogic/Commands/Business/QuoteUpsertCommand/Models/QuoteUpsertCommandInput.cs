using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaInternalClients.Quote.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models
{
    public class QuoteUpsertCommandInput : BaseFilter
    {
        public int InternalId { get; set; }
        public string Title { get; set; }

        public static QuoteUpsertCommandInput Map(InternalBridgeCreateQuoteInput model)
        {
            var result = new QuoteUpsertCommandInput()
            {
                InternalId = model.InternalId,
                Title = model.Title,
            };

            return result;
        }
    }
}

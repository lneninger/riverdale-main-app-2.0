using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaInternalClients.Quote.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models
{
    public class QuoteUpsertCommandInput : BaseFilter
    {
        public int FunzaId { get; set; }
        public string Title { get; set; }

        public static QuoteUpsertCommandInput Map(InternalBridgeCreateQuoteInput model)
        {
            var result = new QuoteUpsertCommandInput()
            {
                FunzaId = model.InternalId,
                Title = model.Title,
            };

            return result;
        }
    }
}

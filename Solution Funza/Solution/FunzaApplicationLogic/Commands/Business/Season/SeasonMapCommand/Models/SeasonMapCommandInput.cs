using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaInternalClients.Quote.Models;
using FunzaInternalClients.Season.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Commands.Funza.Season.SeasonMapCommand.Models
{
    public class SeasonMapCommandInput : BaseFilter
    {
        public int InternalId { get; set; }
        public int FunzaId { get; set; }

        public static SeasonMapCommandInput Map(InternalBridgeSeasonMapInput model)
        {
            var result = new SeasonMapCommandInput()
            {
                InternalId = model.InternalId,
                FunzaId = model.FunzaId,
            };

            return result;
        }
    }
}

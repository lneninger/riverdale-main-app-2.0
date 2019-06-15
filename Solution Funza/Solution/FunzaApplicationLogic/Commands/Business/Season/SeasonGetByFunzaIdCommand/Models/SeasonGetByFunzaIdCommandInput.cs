using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaInternalClients.Quote.Models;
using FunzaInternalClients.Season.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Commands.Funza.Season.SeasonGetByFunzaIdCommand.Models
{
    public class SeasonGetByFunzaIdCommandInput : BaseFilter
    {
        public int InternalId { get; set; }
        public int FunzaId { get; set; }

        public static SeasonGetByFunzaIdCommandInput Map(InternalBridgeSeasonMapInput model)
        {
            var result = new SeasonGetByFunzaIdCommandInput()
            {
                InternalId = model.InternalId,
                FunzaId = model.FunzaId,
            };

            return result;
        }
    }
}

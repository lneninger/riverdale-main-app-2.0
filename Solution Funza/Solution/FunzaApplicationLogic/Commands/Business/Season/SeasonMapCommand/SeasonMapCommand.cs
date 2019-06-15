using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using Framework.Core.Messages;
using Framework.Commands;
using FunzaDirectClients.Clients.Quote;
using FunzaApplicationLogic.Commands.Funza.Season.SeasonCommand;
using FunzaApplicationLogic.Commands.Funza.Season.SeasonMapCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.Season.SeasonMapCommand
{
    public class SeasonMapCommand : AbstractDBCommand<DomainModel.Season, ISeasonDBRepository>, ISeasonMapCommand
    {
        public IQuoteClient QuoteClient { get; set; }

        public SeasonMapCommand(IDbContextScopeFactory dbContextScopeFactory, ISeasonDBRepository repository, IQuoteClient quoteClient) : base(dbContextScopeFactory, repository)
        {
            this.QuoteClient = quoteClient;
        }



        public OperationResponse<SeasonMapCommandOutput> Execute(SeasonMapCommandInput input)
        {
            var result = new OperationResponse<SeasonMapCommandOutput>();
            try
            {
               
                using (var dbContextScope = this.DbContextScopeFactory.Create())
                {
                    var quote = this.Repository.GetByFunzaId(input.FunzaId);

                    if (quote != null)
                    {

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}

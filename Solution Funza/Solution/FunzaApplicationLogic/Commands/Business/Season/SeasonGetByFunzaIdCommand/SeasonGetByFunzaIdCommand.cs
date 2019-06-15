using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using Framework.Core.Messages;
using Framework.Commands;
using FunzaDirectClients.Clients.Quote;
using FunzaApplicationLogic.Commands.Funza.Season.SeasonGetByFunzaIdCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.Season.SeasonGetByFunzaIdCommand
{
    public class SeasonGetByFunzaIdCommand : AbstractDBCommand<DomainModel.Season, ISeasonDBRepository>, ISeasonGetByFunzaIdCommand
    {
        public IQuoteClient QuoteClient { get; set; }

        public SeasonGetByFunzaIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISeasonDBRepository repository, IQuoteClient quoteClient) : base(dbContextScopeFactory, repository)
        {
            this.QuoteClient = quoteClient;
        }



        public OperationResponse<SeasonGetByFunzaIdCommandOutput> Execute(SeasonGetByFunzaIdCommandInput input)
        {
            var result = new OperationResponse<SeasonGetByFunzaIdCommandOutput>();
            try
            {
               
                using (var dbContextScope = this.DbContextScopeFactory.Create())
                {
                    var entity = this.Repository.GetByFunzaId(input.FunzaId);

                    if (entity != null)
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

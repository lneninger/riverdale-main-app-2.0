using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;
using DomainModel;
using FunzaDirectClients.Clients.Quote;

namespace FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand
{
    public class QuoteUpsertCommand : AbstractDBCommand<Quote, IQuoteDBRepository>, IQuoteUpsertCommand
    {
        public IQuoteClient QuoteClient { get; set; }

        public QuoteUpsertCommand(IDbContextScopeFactory dbContextScopeFactory, IQuoteDBRepository repository, IQuoteClient quoteClient) : base(dbContextScopeFactory, repository)
        {
            this.QuoteClient = quoteClient;
        }



        public OperationResponse<QuoteUpsertCommandOutput> Execute(QuoteUpsertCommandInput input)
        {
            var result = new OperationResponse<QuoteUpsertCommandOutput>();
            try
            {
               
                using (var dbContextScope = this.DbContextScopeFactory.Create())
                {
                    var quote = this.Repository.GetByInternalId(input.InternalId);

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

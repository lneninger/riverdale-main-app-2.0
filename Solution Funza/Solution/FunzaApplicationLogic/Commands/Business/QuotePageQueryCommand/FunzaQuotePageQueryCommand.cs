using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;
using DomainModel;

namespace FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand
{
    public class FunzaQuotePageQueryCommand : AbstractDBCommand<Quote, IQuoteDBRepository>, IFunzaQuotePageQueryCommand
    {
        public FunzaQuotePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IQuoteDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<QuotePageQueryCommandOutput>> Execute(PageQuery<QuotePageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

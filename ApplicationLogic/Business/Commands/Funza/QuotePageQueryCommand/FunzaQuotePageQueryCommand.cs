using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand
{
    public class FunzaQuotePageQueryCommand : AbstractDBCommand<DomainModel.Quote.AbstractQuote, IFunzaQuoteReferenceDBRepository>, IFunzaQuotePageQueryCommand
    {
        public FunzaQuotePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaQuoteReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<FunzaQuotePageQueryCommandOutputDTO>> Execute(PageQuery<FunzaQuotePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

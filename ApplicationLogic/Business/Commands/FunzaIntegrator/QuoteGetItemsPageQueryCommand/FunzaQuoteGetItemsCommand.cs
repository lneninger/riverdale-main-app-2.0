using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using ApplicationLogic.Repositories.Funza;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand
{
    public class FunzaQuoteGetItemsCommand : IFunzaQuoteGetItemsCommand
    {
        public FunzaQuoteGetItemsCommand(IQuoteRepository repository)
        {
            this.Repository = repository;
        }

        public IQuoteRepository Repository { get; }

        public OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>> Execute(PageQuery<FunzaQuoteGetItemsCommandInputDTO> input)
        {
            return this.Repository.PageQuery(input);
        }
    }
}

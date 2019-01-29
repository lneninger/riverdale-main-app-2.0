using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using ApplicationLogic.Repositories.Funza;
using ApplicationLogic.Business.Commons.FunzaManager;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand
{
    public class FunzaQuoteGetItemsCommand : IFunzaQuoteGetItemsCommand
    {
        public FunzaQuoteGetItemsCommand(IQuoteRepository repository, IFunzaManager funzaManager)
        {
            this.Repository = repository;
            this.FunzaManager = funzaManager;
        }

        public IFunzaManager FunzaManager { get; }
        public IQuoteRepository Repository { get; }

        public OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>> Execute(PageQuery<FunzaQuoteGetItemsCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>>();
            var settings = this.FunzaManager.GetAuthenticationSetting("full");
            return this.Repository.PageQuery(input, this.FunzaManager.FunzaSettings.GetQuotesURL, settings.TokenSettings.AccessToken);
        }
    }
}

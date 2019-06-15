using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Season.SeasonPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;
using DomainModel;

namespace FunzaApplicationLogic.Commands.Season.SeasonPageQueryCommand
{
    public class SeasonPageQueryCommand : AbstractDBCommand<Quote, ISeasonDBRepository>, ISeasonPageQueryCommand
    {
        public SeasonPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISeasonDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SeasonPageQueryCommandOutput>> Execute(PageQuery<SeasonPageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

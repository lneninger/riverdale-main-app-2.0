using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;
using DomainModel;

namespace FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand
{
    public class FunzaCategoryPageQueryCommand : AbstractDBCommand<Category, ICategoryDBRepository>, IFunzaCategoryPageQueryCommand
    {
        public FunzaCategoryPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ICategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<CategoryPageQueryCommandOutput>> Execute(PageQuery<CategoryPageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

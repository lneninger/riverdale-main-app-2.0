using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand
{
    public class FunzaCategoryPageQueryCommand : AbstractDBCommand<DomainModel.Funza.CategoryReference, IFunzaCategoryReferenceDBRepository>, IFunzaCategoryPageQueryCommand
    {
        public FunzaCategoryPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaCategoryReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<FunzaCategoryPageQueryCommandOutputDTO>> Execute(PageQuery<FunzaCategoryPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

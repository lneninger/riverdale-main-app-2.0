using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Size.SizePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;
using DomainModel;

namespace FunzaApplicationLogic.Commands.Size.SizePageQueryCommand
{
    public class SizePageQueryCommand : AbstractDBCommand<DomainModel.Size, ISizeDBRepository>, ISizePageQueryCommand
    {
        public SizePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SizePageQueryCommandOutput>> Execute(PageQuery<SizePageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

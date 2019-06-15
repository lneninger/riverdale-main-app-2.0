using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using DomainModel;
using FunzaApplicationLogic.Commands.ColorPageQueryCommand.Models;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.ColorPageQueryCommand
{
    public class FunzaColorPageQueryCommand : AbstractDBCommand<Color, IColorDBRepository>, IFunzaColorPageQueryCommand
    {
        public FunzaColorPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IColorDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<ColorPageQueryCommandOutput>> Execute(PageQuery<ColorPageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

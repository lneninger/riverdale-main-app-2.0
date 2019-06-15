using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand
{
    public class FunzaProductPageQueryCommand : AbstractDBCommand<DomainModel.Product, IProductDBRepository>, IFunzaProductPageQueryCommand
    {
        public FunzaProductPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<ProductPageQueryCommandOutput>> Execute(PageQuery<ProductPageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

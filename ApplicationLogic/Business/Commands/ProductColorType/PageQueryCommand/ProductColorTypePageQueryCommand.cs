using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand
{
    public class ProductColorTypePageQueryCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypePageQueryCommand
    {
        public ProductColorTypePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<ProductColorTypePageQueryCommandOutputDTO>> Execute(PageQuery<ProductColorTypePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

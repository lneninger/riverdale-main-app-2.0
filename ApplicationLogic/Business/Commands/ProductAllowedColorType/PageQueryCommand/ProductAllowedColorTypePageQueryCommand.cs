using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand
{
    public class ProductAllowedColorTypePageQueryCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductAllowedColorTypeDBRepository>, IProductAllowedColorTypePageQueryCommand
    {
        public ProductAllowedColorTypePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IProductAllowedColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>> Execute(PageQuery<ProductAllowedColorTypePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand
{
    public class ProductCategoryAllowedSizePageQueryCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductCategoryAllowedSizeDBRepository>, IProductCategoryAllowedSizePageQueryCommand
    {
        public ProductCategoryAllowedSizePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryAllowedSizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<ProductCategoryAllowedSizePageQueryCommandOutputDTO>> Execute(PageQuery<ProductCategoryAllowedSizePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

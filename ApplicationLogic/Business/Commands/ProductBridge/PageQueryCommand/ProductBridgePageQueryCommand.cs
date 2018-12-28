using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand
{
    public class ProductBridgePageQueryCommand : AbstractDBCommand<DomainModel.Product.CompositionProductBridge, IProductBridgeDBRepository>, IProductBridgePageQueryCommand
    {
        public ProductBridgePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<ProductBridgePageQueryCommandOutputDTO>> Execute(PageQuery<ProductBridgePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}

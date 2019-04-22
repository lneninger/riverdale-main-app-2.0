using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.ProductBridge.GetAllCommand
{
    public class ProductBridgeGetAllCommand : AbstractDBCommand<DomainModel.Product.CompositionProductBridge, IProductBridgeDBRepository>, IProductBridgeGetAllCommand
    {
        public ProductBridgeGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<ProductBridgeGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<ProductBridgeGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new ProductBridgeGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Stems = entityItem.CompositionItemAmount,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}

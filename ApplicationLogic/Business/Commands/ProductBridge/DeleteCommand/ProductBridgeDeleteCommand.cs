using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand
{
    public class ProductBridgeDeleteCommand : AbstractDBCommand<CompositionProductBridge, IProductBridgeDBRepository>, IProductBridgeDeleteCommand
    {
        public ProductBridgeDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductBridgeDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductBridgeDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductBridgeDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductId = getByIdResult.Bag.CompositionProductId,
                        RelatedProductId = getByIdResult.Bag.CompositionItemId
                    };
                }

                var deleteResult = this.Repository.Delete(getByIdResult.Bag);
                result.AddResponse(deleteResult);
                if (result.IsSucceed)
                {
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddException("Error deleting Product", ex);
                    }
                }
            }

            return result;
        }
    }
}

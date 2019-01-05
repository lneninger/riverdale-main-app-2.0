using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand
{
    public class ProductBridgeGetByIdCommand : AbstractDBCommand<DomainModel.Product.CompositionProductBridge, IProductBridgeDBRepository>, IProductBridgeGetByIdCommand
    {

        public ProductBridgeGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductBridgeGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductBridgeGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductBridgeGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Stems = getByIdResult.Bag.Stems,
                        ProductId = getByIdResult.Bag.CompositionProductId,
                        RelatedProductId = getByIdResult.Bag.CompositionItemId,
                    };
                }
            }

            return result;
        }
    }
}

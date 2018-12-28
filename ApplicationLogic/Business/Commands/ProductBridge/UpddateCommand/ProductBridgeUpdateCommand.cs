using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand
{
    public class ProductBridgeUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductBridgeDBRepository>, IProductBridgeUpdateCommand
    {
        public ProductBridgeUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductBridgeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductBridgeUpdateCommandOutputDTO> Execute(ProductBridgeUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<ProductBridgeUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.Stems = input.Stems;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new ProductBridgeUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                        };
                    }

                }
            }

            return result;
        }
    }
}

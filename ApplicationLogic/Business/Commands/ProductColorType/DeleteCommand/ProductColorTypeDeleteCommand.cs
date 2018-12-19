using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand
{
    public class ProductColorTypeDeleteCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeDeleteCommand
    {
        public ProductColorTypeDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductColorTypeDeleteCommandOutputDTO> Execute(string id)
        {
            var result = new OperationResponse<ProductColorTypeDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductColorTypeDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        IsBasicColor = getByIdResult.Bag.IsBasicColor,
                        HexCode = getByIdResult.Bag.HexCode,
                        Name = getByIdResult.Bag.Name
                    };
                }

                var deleteResult = this.Repository.Delete(id);
                result.AddResponse(deleteResult);
                if (result.IsSucceed)
                {
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddException("Error deleting Customer", ex);
                    }
                }
            }

            return result;
        }
    }
}

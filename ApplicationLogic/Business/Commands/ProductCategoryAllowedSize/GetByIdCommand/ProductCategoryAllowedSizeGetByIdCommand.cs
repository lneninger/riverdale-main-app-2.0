using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand
{
    public class ProductCategoryAllowedSizeGetByIdCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductCategoryAllowedSizeDBRepository>, IProductCategoryAllowedSizeGetByIdCommand
    {

        public ProductCategoryAllowedSizeGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryAllowedSizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryAllowedSizeGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductCategoryAllowedSizeGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    
                    result.Bag = new ProductCategoryAllowedSizeGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Size = getByIdResult.Bag.Size,
                        ProductCategoryId = getByIdResult.Bag.ProductCategoryId,
                    };
                }
            }

            return result;



        }
    }
}

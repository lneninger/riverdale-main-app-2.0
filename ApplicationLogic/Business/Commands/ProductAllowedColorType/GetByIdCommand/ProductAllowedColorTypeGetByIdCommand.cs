using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand
{
    public class ProductAllowedColorTypeGetByIdCommand : AbstractDBCommand<DomainModel.Product.ProductCategoryAllowedColorType, IProductAllowedColorTypeDBRepository>, IProductAllowedColorTypeGetByIdCommand
    {

        public ProductAllowedColorTypeGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductAllowedColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductAllowedColorTypeGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductAllowedColorTypeGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    
                    result.Bag = new ProductAllowedColorTypeGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        ProductColorTypeId = getByIdResult.Bag.ProductColorTypeId,
                        ProductCategoryId = getByIdResult.Bag.ProductCategoryId,
                    };
                }
            }

            return result;



        }
    }
}

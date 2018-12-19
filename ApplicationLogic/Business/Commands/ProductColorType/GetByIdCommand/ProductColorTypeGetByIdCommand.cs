using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand
{
    public class ProductColorTypeGetByIdCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeGetByIdCommand
    {

        public ProductColorTypeGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductColorTypeGetByIdCommandOutputDTO> Execute(string id)
        {
            var result = new OperationResponse<ProductColorTypeGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductColorTypeGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        HexCode = getByIdResult.Bag.HexCode,
                        IsBasicColor = getByIdResult.Bag.IsBasicColor,
                    };
                }
            }

            return result;
        }
    }
}

using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand
{
    public class ProductMediaGetByIdCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaGetByIdCommand
    {

        public ProductMediaGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductMediaGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductMediaGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new ProductMediaGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id
                    };
                }
            }

            return result;
        }
    }
}

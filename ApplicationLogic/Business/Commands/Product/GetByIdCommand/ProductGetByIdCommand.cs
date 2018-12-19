using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using ApplicationLogic.Business.Commands.Product.Commons;

namespace ApplicationLogic.Business.Commands.Product.GetByIdCommand
{
    public class ProductGetByIdCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductDBRepository>, IProductGetByIdCommand
    {

        public ProductGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithMedias(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    //var entry = this.Repository.Entry(getByIdResult.Bag);
                    //if (!entry.Collection(t => t.ProductMedias).IsLoaded)
                    //{
                    //    entry.Collection(t => t.ProductMedias).Load();
                    //}
                    result.Bag = new ProductGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        ProductTypeId = getByIdResult.Bag.ProductTypeId,
                        Medias = getByIdResult.Bag.ProductMedias.Select(m => new FileItemRefOutputDTO
                        {
                            Id = m.Id,
                            FullUrl = m.FileRepository.FullFilePath
                        })
                    };

                    if (result.Bag.ProductTypeEnum == ProductTypeEnum.COMP)
                    {
                    }
                }
            }

            return result;



        }
    }
}

using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.Product;
using DomainModel._Commons.Enums;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand
{
    public class ProductCategoryGetByIdCommand : AbstractDBCommand<DomainModel.Product.ProductCategory, IProductCategoryDBRepository>, IProductCategoryGetByIdCommand
    {

        public ProductCategoryGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IProductCategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductCategoryGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<ProductCategoryGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    
                    result.Bag = new ProductCategoryGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Identifier = getByIdResult.Bag.Identifier,
                        Name = getByIdResult.Bag.Name,
                        //Medias = getByIdResult.Bag.ProductCategoryMedias.Select(m => new FileItemRefOutputDTO
                        //{
                        //    Id = m.Id,
                        //    FileId = m.FileRepositoryId,
                        //    FullUrl = m.FileRepository.FullFilePath
                        //}).ToList(),
                        AllowedColors = getByIdResult.Bag.AllowedColorTypes.Select(m => new ProductCategoryGetByIdCommandOutputAllowedColorTypeItemDTO
                        {
                            Id = m.Id,
                            ProductColorTypeId = m.ProductColorTypeId,
                        }).ToList(),
                        AllowedSizes = getByIdResult.Bag.Sizes.Select(m => new ProductCategoryGetByIdCommandOutputAllowedSizeItemDTO
                        {
                            Id = m.Id,
                            Size = m.Size,
                        }).ToList()
                    };

                    
                }
            }

            return result;



        }
    }
}

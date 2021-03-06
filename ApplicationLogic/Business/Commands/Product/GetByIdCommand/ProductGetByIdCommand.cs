﻿using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.Product;
using DomainModel._Commons.Enums;

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
                    
                    result.Bag = new ProductGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        ProductTypeId = getByIdResult.Bag.ProductTypeId,
                        ProductCategoryId = getByIdResult.Bag.ProductCategoryId,
                        Medias = getByIdResult.Bag.ProductMedias.Where(m => m.IsDeleted  == null || m.IsDeleted == false).Select(m => new FileItemRefOutputDTO
                        {
                            Id = m.Id,
                            FileId = m.FileRepositoryId,
                            FullUrl = m.FileRepository.FullFilePath,
                            IsDeleted = (m.IsDeleted == true || m.FileRepository.IsDeleted == true)
                        }).ToList(),
                       
                    };

                    if (result.Bag.ProductTypeEnum == ProductTypeEnum.COMP)
                    {
                        result.Bag.RelatedProducts = ((CompositionProduct)getByIdResult.Bag).Items.Select(o => new ProductGetByIdCommandOutputRelatedProductItemDTO
                        {
                            Id = o.Id,
                            ProductId = o.CompositionProductId,
                            RelatedProductId = o.CompositionItemId,
                            ColorTypeId = o.ColorTypeId,
                            RelatedProductSizeId = o.ProductCategorySizeId,
                            RelatedProductAmount = o.CompositionItemAmount,
                            RelatedProductName = o.CompositionItem.Name,
                            RelatedProductTypeName = o.CompositionItem.ProductType.Name,
                            RelatedProductTypeDescription = o.CompositionItem.ProductType.Description,
                            RelatedProductPictureId = o.CompositionItem.ProductMedias.Where(m => m.IsDeleted == null || m.IsDeleted == false).Select(media => media.FileRepositoryId).FirstOrDefault()

                        }).ToList();
                    }
                    else if (result.Bag.ProductTypeEnum == ProductTypeEnum.FLW)
                    {
                        result.Bag.ProductCategoryId = ((FlowerProduct)getByIdResult.Bag).ProductCategoryId;

                    }
                }
            }

            return result;



        }
    }
}

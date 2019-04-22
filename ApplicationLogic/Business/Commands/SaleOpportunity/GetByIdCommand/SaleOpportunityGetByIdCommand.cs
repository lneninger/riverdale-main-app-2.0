using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.SaleOpportunity;
using System.Collections.Generic;
using DomainModel.Product;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand
{
    public class SaleOpportunityGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunity, ISaleOpportunityDBRepository>, ISaleOpportunityGetByIdCommand
    {

        public SaleOpportunityGetByIdCommand(
            IDbContextScopeFactory dbContextScopeFactory
            , ISaleOpportunityDBRepository repository
            , ISaleOpportunityTargetPriceProductDBRepository saleOpportunityTargetPriceProductRepository) : base(dbContextScopeFactory, repository)
        {
            this.SaleOpportunityTargetPriceProductRepository = saleOpportunityTargetPriceProductRepository;
        }

        public ISaleOpportunityTargetPriceProductDBRepository SaleOpportunityTargetPriceProductRepository { get; }

        public OperationResponse<SaleOpportunityGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithProducts(id);
                var allOpportunityTargetPriceProducts = this.SaleOpportunityTargetPriceProductRepository.GetAll().Bag;
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {

                    result.Bag = new SaleOpportunityGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        CustomerId = getByIdResult.Bag.CustomerId,
                        CustomerName = getByIdResult.Bag.Customer.Name,
                        TargetPrices = getByIdResult.Bag.SaleOpportunityTargetPrices.Select(targetPrice => new SaleOpportunityGetByIdCommandOutputTargetPriceItemDTO
                        {

                            Id = targetPrice.Id,
                            Name = targetPrice.Name,
                            SeasonName = targetPrice.SaleSeasonType.Name,
                            TargetPrice = targetPrice.TargetPrice,
                            SaleSeasonTypeId = targetPrice.SaleSeasonTypeId,
                            AlternativesAmount = targetPrice.AlternativesAmount,



                            SampleBoxes = targetPrice.SampleBoxes.Select(o => new SaleOpportunityGetByIdCommandOutputSampleBoxItemDTO
                            {
                                Id = o.Id,
                                SaleOpportunityTargetPriceId = o.SaleOpportunityTargetPriceId,
                                Name = o.Name,
                                Order = o.Order,
                                SampleBoxSaleOpportunityProductIds = o.SampleBoxProducts.Select(item => new SaleOpportunityGetByIdCommandOutputSampleBoxProductItemDTO
                                {
                                    Id = o.Id,
                                    SaleOpportunityTargetPriceProductId = item.SaleOpportunityTargetPriceProductId,
                                }).ToList()
                            }).ToList(),

                            SaleOpportunityTargetPriceProducts = targetPrice.SaleOpportunityTargetPriceProducts.Select(item => new SaleOpportunityGetByIdCommandOutputTargetPriceProductItemDTO
                            {
                                Id = item.Id,
                                ProductId = item.ProductId,
                                ProductAmount = item.ProductAmount,
                                ProductName = item.Product.Name,
                                ProductTypeId = item.Product.ProductTypeId,
                                ProductTypeName = item.Product.ProductType.Name,
                                ProductTypeDescription = item.Product.ProductType.Description,
                                ProductPictureId = item.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                                ProductColorTypeId = item.ProductColorTypeId,
                                ProductColorTypeName = item.ProductColorType?.Name,
                                OpportunityCount = allOpportunityTargetPriceProducts.Where(tpProduct => tpProduct.Product.Id == item.ProductId).Select(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunityId).Distinct().Count(),
                                FirstOpportunityId = allOpportunityTargetPriceProducts.Where(tpProduct => tpProduct.Product.Id == item.ProductId).OrderBy(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunity.CreatedAt).Select(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunityId).FirstOrDefault(),

                                RelatedProducts = ((CompositionProduct)item.Product).Items.Select(o => new SaleOpportunityGetByIdCommandOutputRelatedProductItemDTO
                                {
                                    Id = o.Id,
                                    ProductId = o.CompositionProductId,
                                    RelatedProductId = o.CompositionItemId,
                                    RelatedProductAmount = o.CompositionItemAmount,
                                    RelatedProductSizeId = o.ProductCategorySizeId,
                                    ColorTypeId = o.ColorTypeId,
                                    RelatedProductName = o.CompositionItem.Name,
                                    RelatedProductTypeName = o.CompositionItem.ProductType.Name,
                                    RelatedProductTypeDescription = o.CompositionItem.ProductType.Description,
                                    RelatedProductPictureId = o.CompositionItem.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                                    RelatedProductTypeId = o.CompositionItem.ProductTypeId,
                                    RelatedProductCategoryId = o.CompositionItem.ProductCategoryId

                                }).ToList()

                }).ToList()
                        }).ToList(),




                    };

                    //if (getByIdResult.Bag.ProductAllowedColorType != null)
                    //{
                    //    result.Bag.ProductColorTypeId = getByIdResult.Bag.ProductAllowedColorType.ProductColorTypeId;
                    //}

                    foreach(var TargetPrice in getByIdResult.Bag.SaleOpportunityTargetPrices)
                    {
                        var resultTargetPrice = result.Bag.TargetPrices.FirstOrDefault(resultTargetPriceItem => resultTargetPriceItem.Settings != null);
                        if (resultTargetPrice != null)
                        {
                            resultTargetPrice.Settings = new SaleOpportunityGetByIdCommandOutputSettingsDTO
                            {
                                Id = TargetPrice.SaleOpportunitySettings.Id,
                                Delivered = TargetPrice.SaleOpportunitySettings.Delivered,
                            };
                        }
                    }
                }
            }

            return result;



        }
    }
}

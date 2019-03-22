using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.SaleOpportunity;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand
{
    public class SaleOpportunityGetByIdCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunity, ISaleOpportunityDBRepository>, ISaleOpportunityGetByIdCommand
    {

        public SaleOpportunityGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<SaleOpportunityGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetByIdWithProducts(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {

                    result.Bag = new SaleOpportunityGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                        CustomerId = getByIdResult.Bag.CustomerId,
                        CustomerName = getByIdResult.Bag.Customer.Name,
                        TargetPrices = getByIdResult.Bag.SaleOpportunityTargetPrices.Select(TargetPrice => new SaleOpportunityGetByIdCommandOutputTargetPriceItemDTO
                        {

                            Id = TargetPrice.Id,
                            Name = TargetPrice.Name,
                            SeasonName = TargetPrice.SaleSeasonType.Name,
                            TargetPrice = TargetPrice.TargetPrice,
                            SaleSeasonTypeId = TargetPrice.SaleSeasonTypeId,
                            AlternativesAmount = TargetPrice.AlternativesAmount,

                            

                            SampleBoxes = TargetPrice.SampleBoxes.Select(o => new SaleOpportunityGetByIdCommandOutputSampleBoxItemDTO
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

                            SaleOpportunityTargetPriceProducts = TargetPrice.SaleOpportunityTargetPriceProducts.Select(item => new SaleOpportunityGetByIdCommandOutputTargetPriceProductItemDTO
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
                                ProductColorTypeName = item.ProductColorType?.Name
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

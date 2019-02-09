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
                        SeasonName = getByIdResult.Bag.SaleSeasonType.Name,
                        TargetPrice = getByIdResult.Bag.TargetPrice,

                        SampleBoxes = getByIdResult.Bag.SampleBoxes.Select(o => new SaleOpportunityGetByIdCommandOutputSampleBoxItemDTO
                        {
                            Id = o.Id,
                            SaleOpportunityId = o.SaleOpportunityId,
                            SampleBoxProducts = o.SampleBoxProducts.Select(item => new SaleOpportunityGetByIdCommandOutputSampleBoxProductItemDTO {
                                Id = o.Id,
                                ProductId = item.ProductId,
                                ProductAmount = item.ProductAmount,
                                ProductName = item.Product.Name,
                                ProductTypeId = item.Product.ProductTypeId,
                                ProductTypeName = item.Product.ProductType.Name,
                                ProductTypeDescription = item.Product.ProductType.Description,
                                ProductPictureId = item.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                                ProductColorTypeId = item.ProductAllowedColorType?.ProductColorTypeId
                            }).ToList()
                        }).ToList()

                    };

                    //if (getByIdResult.Bag.ProductAllowedColorType != null)
                    //{
                    //    result.Bag.ProductColorTypeId = getByIdResult.Bag.ProductAllowedColorType.ProductColorTypeId;
                    //}

                    if (getByIdResult.Bag.SaleOpportunitySettings != null)
                    {
                        result.Bag.Settings = new SaleOpportunityGetByIdCommandOutputSettingsDTO
                        {
                            Delivered = getByIdResult.Bag.SaleOpportunitySettings.Delivered
                        };
                    }
                }
            }

            return result;



        }
    }
}

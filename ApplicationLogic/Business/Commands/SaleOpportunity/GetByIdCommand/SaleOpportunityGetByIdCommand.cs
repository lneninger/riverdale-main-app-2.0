using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Business.Commons.DTOs;
using DomainModel.SaleOpportunity;

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
                        CustomerName = getByIdResult.Bag.Customer.Name,
                        SeasonName = getByIdResult.Bag.SaleSeasonType.Name,
                        TargetPrice = getByIdResult.Bag.TargetPrice,

                        RelatedProducts = getByIdResult.Bag.SaleOpportunityProducts.Select(o => new SaleOpportunityGetByIdCommandOutputRelatedSaleOpportunityItemDTO
                        {
                            Id = o.Id,
                            SaleOpportunityId = o.SaleOpportunityId,
                            ProductId = o.ProductId,
                            ProductAmount = o.ProductAmount,
                            ProductName = o.Product.Name,
                            ProductTypeId = o.Product.ProductTypeId,
                            ProductTypeName = o.Product.ProductType.Name,
                            ProductTypeDescription = o.Product.ProductType.Description,
                            ProductPictureId = o.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                            ProductColorTypeId = o.ProductAllowedColorType?.ProductColorTypeId
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

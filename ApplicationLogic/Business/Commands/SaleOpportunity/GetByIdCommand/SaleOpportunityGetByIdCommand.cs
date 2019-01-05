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
                        RelatedProducts = getByIdResult.Bag.SaleOpportunityProducts.Select(o => new SaleOpportunityGetByIdCommandOutputRelatedSaleOpportunityItemDTO
                        {
                            Id = o.Id,
                            SaleOpportunityId = o.SaleOpportunityId,
                            ProductId = o.ProductId,
                            ProductAmount = o.ProductAmount,
                            ProductName = o.Product.Name,
                            ProductTypeName = o.Product.ProductType.Name,
                            ProductTypeDescription = o.Product.ProductType.Description,
                            ProductPictureId = o.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault()

                        }).ToList()
                    };

                    
                }
            }

            return result;



        }
    }
}

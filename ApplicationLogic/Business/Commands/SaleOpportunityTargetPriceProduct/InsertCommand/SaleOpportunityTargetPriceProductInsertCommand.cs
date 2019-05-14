using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand
{
    public class SaleOpportunityTargetPriceProductInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPriceProduct, ISaleOpportunityTargetPriceProductDBRepository>, ISaleOpportunityTargetPriceProductInsertCommand
    {
        public SaleOpportunityTargetPriceProductInsertCommand(
            IDbContextScopeFactory dbContextScopeFactory
            , ISaleOpportunityTargetPriceProductDBRepository repository
            , ISaleOpportunityTargetPriceProductDBRepository saleOpportunityTargetPriceProductRepository
            ) : base(dbContextScopeFactory, repository)
        {
            this.SaleOpportunityTargetPriceProductRepository = saleOpportunityTargetPriceProductRepository;
        }

        public ISaleOpportunityTargetPriceProductDBRepository SaleOpportunityTargetPriceProductRepository { get; }

        public OperationResponse<SaleOpportunityTargetPriceProductInsertCommandOutputDTO> Execute(SaleOpportunityTargetPriceProductInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceProductInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SaleOpportunityTargetPriceProduct
                {
                    
                    SaleOpportunityTargetPriceId = input.TargetPriceId,
                    ProductColorTypeId = input.ProductColorTypeId,
                };

                if (input.ProductId.HasValue)
                {
                    entity.ProductId = input.ProductId.Value;
                }
                else
                {
                    entity.Product = new CompositionProduct
                    {
                        Name = input.Name,
                    };
                }
                

                try
                {
                    var insertResult = this.Repository.Insert(entity);
                    result.AddResponse(insertResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error Adding Product", ex);
                }

                if (result.IsSucceed)
                {
                    //this.Repository.Detach(entity.Id);
                    var getByIdResult = this.Repository.GetById(entity.Id, true);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        var allOpportunityTargetPriceProducts = this.SaleOpportunityTargetPriceProductRepository.GetAll().Bag;

                        result.Bag = new SaleOpportunityTargetPriceProductInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            ProductId = getByIdResult.Bag.ProductId,
                            TargetPriceId = getByIdResult.Bag.SaleOpportunityTargetPriceId,
                            ProductAmount = getByIdResult.Bag.ProductAmount,
                            ProductName = getByIdResult.Bag.Product.Name,
                            ProductTypeId = getByIdResult.Bag.Product.ProductTypeId,
                            ProductTypeName = getByIdResult.Bag.Product.ProductType.Name,
                            ProductTypeDescription = getByIdResult.Bag.Product.ProductType.Description,
                            ProductPictureId = getByIdResult.Bag.Product.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault(),
                            OpportunityCount = allOpportunityTargetPriceProducts.Where(tpProduct => tpProduct.Product.Id == getByIdResult.Bag.ProductId).Select(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunityId).Distinct().Count(),
                            FirstOpportunityId = allOpportunityTargetPriceProducts.Where(tpProduct => tpProduct.Product.Id == getByIdResult.Bag.ProductId).OrderBy(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunity.CreatedAt).Select(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunityId).FirstOrDefault(),
                            FirstOpportunityName = allOpportunityTargetPriceProducts.Where(tpProduct => tpProduct.Product.Id == getByIdResult.Bag.ProductId).OrderBy(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunity.CreatedAt).Select(tpProduct => tpProduct.SaleOpportunityTargetPrice.SaleOpportunity.Name).FirstOrDefault(),
                        };
                    }

                }
            }

            return result;
        }
    }
}

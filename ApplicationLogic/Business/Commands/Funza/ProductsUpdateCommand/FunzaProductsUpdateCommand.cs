using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;
using DomainModel.Funza;

namespace ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand
{
    public class FunzaProductsUpdateCommand : AbstractDBCommand<DomainModel.Product.AbstractProduct, IProductDBRepository>, IFunzaProductsUpdateCommand
    {
        public FunzaProductsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaProductReferenceDBRepository funzaProductReferenceDBRepository, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
            this.FunzaProductReferenceDBRepository = funzaProductReferenceDBRepository;
        }

        public IFunzaProductReferenceDBRepository FunzaProductReferenceDBRepository { get; }

        public OperationResponse<FunzaProductsUpdateCommandOutputDTO> Execute(IEnumerable<FunzaProductsUpdateCommandInputDTO> input)
        {
            var result = new OperationResponse<FunzaProductsUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Funza.ProductReference> getByIdResult;
                OperationResponse<DomainModel.Funza.ProductReference> prepareToSaveResult;
                DomainModel.Funza.ProductReference entity = null;

                try
                {
                    
                    foreach (var dtoItem in input)
                    {
                        getByIdResult = this.FunzaProductReferenceDBRepository.GetById(dtoItem.Id);
                        // Add
                        if (!getByIdResult.IsSucceed)
                        {
                            entity = this.MapDTO(dtoItem);
                            prepareToSaveResult = this.FunzaProductReferenceDBRepository.Add(entity);
                            result.AddResponse(prepareToSaveResult);
                        }
                    }

                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error Adding Product", ex);
                }

               
            }

            return result;
        }

        private ProductReference MapDTO(FunzaProductsUpdateCommandInputDTO dtoItem)
        {
            var result = new ProductReference
            {
                Active = dtoItem.Active,
                CategoryId = dtoItem.CategoryId,
                CategoryName = dtoItem.CategoryName,
                Code = dtoItem.Code,
                ColorId = dtoItem.ColorId,
                Description = dtoItem.Description,
                GradeId = dtoItem.GradeId,
                Observations = dtoItem.Observations,
                ProductTypeId = dtoItem.ProductTypeId,
                ProductTypeName = dtoItem.ProductTypeName,
                ReferenceCode = dtoItem.ReferenceCode,
                ReferenceDescription = dtoItem.ReferenceDescription,
                ReferenceId = dtoItem.ReferenceId,
                ReferenceTypeId = dtoItem.ReferenceTypeId,
                ReferenceTypeName = dtoItem.ReferenceTypeName,
                SendQuotator = dtoItem.SendQuotator,
                SpecieId = dtoItem.SpecieId,
                FunzaUpdatedDate = dtoItem.FunzaUpdatedDate,
                VarieryId = dtoItem.VarieryId,
            };

            return result;
        }
    }
}

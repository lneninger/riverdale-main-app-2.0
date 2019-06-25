using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Funza;
using Framework.Commands;
using DomainModel;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand
{
    public class FunzaProductsUpdateCommand : AbstractDBCommand<DomainModel.Product, IProductDBRepository>, IFunzaProductsUpdateCommand
    {
        public FunzaProductsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductsUpdateCommandOutput> Execute(SyncCommandEntityWrapperInput<ProductsUpdateCommandInput> input)
        {
            var result = new OperationResponse<ProductsUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Product> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Product entity = null;

                try
                {
                    foreach (var dtoItem in input.SyncItems)
                    {
                        getByFunzaIdResult = this.Repository.GetByFunzaId(dtoItem.Id);
                        bool addEntity = false;
                        if (!getByFunzaIdResult.IsSucceed)
                        {
                            addEntity = true;
                        }
                        else if (getByFunzaIdResult.Bag == null)
                        {
                            addEntity = true;
                        }

                        entity = getByFunzaIdResult.Bag;
                        entity = this.MapDTO(dtoItem, input.IntegrationId, entity);

                        if (addEntity)
                        {
                            prepareToSaveResult = this.Repository.Add(entity);
                            result.AddResponse(prepareToSaveResult);
                        }
                    }

                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();
                    }

                    result.AddResponse(this.Repository.DeleteNotInIntegration(input.IntegrationId));


                }
                catch (Exception ex)
                {
                    result.AddError("Error Sync Funza Products", ex);
                }
            }

            return result;
        }

        private Product MapDTO(ProductsUpdateCommandInput dtoItem, Guid integrationId, Product entity = null)
        {
            var result = entity ?? new Product();

            result.FunzaId = dtoItem.Id;
            result.IntegrationId = dtoItem.IntegrationId;

            result.Active = dtoItem.Active;
            result.CategoryId = dtoItem.CategoryId;
            result.CategoryName = dtoItem.CategoryName;
            result.Code = dtoItem.Code;
            result.ColorId = dtoItem.ColorId;
            result.Description = dtoItem.Description;
            result.SizeId = dtoItem.GradeId;
            result.Comments = dtoItem.Comments;
            result.ProductTypeId = dtoItem.ProductTypeId;
            result.ProductTypeName = dtoItem.ProductTypeName;
            result.ReferenceCode = dtoItem.ReferenceCode;
            result.ReferenceDescription = dtoItem.ReferenceDescription;
            result.ReferenceId = dtoItem.ReferenceId;
            result.ReferenceTypeId = dtoItem.ReferenceTypeId;
            result.ReferenceTypeName = dtoItem.ReferenceTypeName;
            result.SendQuotator = dtoItem.SendQuotator;
            result.SpecieId = dtoItem.SpecieId;
            result.FunzaUpdatedDate = dtoItem.FunzaUpdatedDate;
            result.VariatyId = dtoItem.VarietyId;

            return result;
        }
    }
}

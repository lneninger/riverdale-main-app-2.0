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

namespace FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand
{
    public class FunzaProductsUpdateCommand : AbstractDBCommand<DomainModel.Product, IProductDBRepository>, IFunzaProductsUpdateCommand
    {
        public FunzaProductsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ProductsUpdateCommandOutput> Execute(IEnumerable<ProductsUpdateCommandInput> input)
        {
            var result = new OperationResponse<ProductsUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Product> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Product entity = null;

                try
                {

                    foreach (var dtoItem in input)
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
                        entity = this.MapDTO(dtoItem, entity);

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
                }
                catch (Exception ex)
                {
                    result.AddError("Error Sync Funza Products", ex);
                }
            }

            return result;
        }

        private Product MapDTO(ProductsUpdateCommandInput dtoItem, Product entity = null)
        {
            var result = entity ?? new Product();

            result.FunzaId = dtoItem.Id;
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

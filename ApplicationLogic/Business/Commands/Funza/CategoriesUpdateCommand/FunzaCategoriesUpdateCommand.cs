using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.CategoriesUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;
using DomainModel.Funza;

namespace ApplicationLogic.Business.Commands.Funza.CategoriesUpdateCommand
{
    public class FunzaCategoriesUpdateCommand : AbstractDBCommand<DomainModel.Funza.ProductReference, IFunzaCategoryReferenceDBRepository>, IFunzaCategoriesUpdateCommand
    {
        public FunzaCategoriesUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaCategoryReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FunzaCategoriesUpdateCommandOutputDTO> Execute(IEnumerable<FunzaCategoriesUpdateCommandInputDTO> input)
        {
            var result = new OperationResponse<FunzaCategoriesUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Funza.CategoryReference> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Funza.CategoryReference entity = null;

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
                    result.AddError("Error Sync Funza Categories", ex);
                }
            }

            return result;
        }

        private CategoryReference MapDTO(FunzaCategoriesUpdateCommandInputDTO dtoItem, DomainModel.Funza.CategoryReference entity = null)
        {
            var result = entity ?? new CategoryReference();

            result.FunzaId = dtoItem.Id;
            result.FunzaCreatedBy = dtoItem.CreatedBy;
            result.FunzaCreatedDate = dtoItem.CreatedDate;
            result.Name = dtoItem.Name;
            result.ToOrder = dtoItem.ToOrder;
            result.ToStem = dtoItem.ToStem;
            result.FunzaUpdatedBy = dtoItem.UpdatedBy;
            result.FunzaUpdatedDate = dtoItem.UpdatedDate;

            return result;
        }
    }
}

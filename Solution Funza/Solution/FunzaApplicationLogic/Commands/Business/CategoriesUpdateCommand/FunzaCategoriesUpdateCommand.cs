using ApplicationLogic.Repositories.DB;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using Framework.Commands;
using Framework.Core.Messages;
using FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models;
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand
{
    public class FunzaCategoriesUpdateCommand : AbstractDBCommand<DomainModel.Category, ICategoryDBRepository>, IFunzaCategoriesUpdateCommand
    {
        public FunzaCategoriesUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ICategoryDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FunzaCategoriesUpdateCommandOutputDTO> Execute(IEnumerable<FunzaCategoriesUpdateCommandInputDTO> input)
        {
            var result = new OperationResponse<FunzaCategoriesUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Category> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Category entity = null;

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

        private Category MapDTO(FunzaCategoriesUpdateCommandInputDTO dtoItem, Category entity = null)
        {
            var result = entity ?? new Category();

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

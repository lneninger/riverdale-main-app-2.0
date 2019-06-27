using ApplicationLogic.Repositories.DB;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using Framework.Commands;
using Framework.Core.Messages;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;
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

        public OperationResponse<CategoriesUpdateCommandOutput> Execute(SyncCommandEntityWrapperInput<CategoriesUpdateCommandInput> input)
        {
            var result = new OperationResponse<CategoriesUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Category> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Category entity = null;

                try
                {
                    foreach (var dtoItem in input.SyncItems)
                    {
                        getByFunzaIdResult = this.Repository.GetByFunzaId(dtoItem.FunzaId);
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



                }
                catch (Exception ex)
                {
                    result.AddError("Error Sync Funza Product Categories", ex);
                }
            }

            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                result.AddResponse(this.Repository.DeleteNotInIntegration(input.IntegrationId));
            }

            return result;
        }

        private Category MapDTO(CategoriesUpdateCommandInput dtoItem, Guid integrationId, Category entity = null)
        {
            var result = entity ?? new Category();

            result.FunzaId = dtoItem.Id;
            result.IntegrationId = dtoItem.IntegrationId;

            result.FunzaCreatedBy = dtoItem.FunzaCreatedBy;
            result.FunzaCreatedDate = dtoItem.FunzaCreatedDate;
            result.Name = dtoItem.Name;
            result.ToOrder = dtoItem.ToOrder;
            result.ToStem = dtoItem.ToStem;
            result.FunzaUpdatedBy = dtoItem.FunzaUpdatedBy;
            result.FunzaUpdatedDate = dtoItem.FunzaUpdatedDate;

            return result;
        }
    }
}

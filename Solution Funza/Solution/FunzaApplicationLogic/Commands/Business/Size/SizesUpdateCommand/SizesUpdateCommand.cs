using ApplicationLogic.Repositories.DB;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using Framework.Commands;
using Framework.Core.Messages;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;
using FunzaApplicationLogic.Commands.Funza.Size.SizesUpdateCommand;
using FunzaApplicationLogic.Commands.Size.SizeUpdateCommand.Models;
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Size.SizeUpdateCommand
{
    public class SizesUpdateCommand : AbstractDBCommand<DomainModel.Category, ISizeDBRepository>, ISizesUpdateCommand
    {
        public SizesUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ISizeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SizesUpdateCommandOutput> Execute(SyncCommandEntityWrapperInput<SizesUpdateCommandInput> input)
        {
            var result = new OperationResponse<SizesUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Size> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Size entity = null;

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

        private DomainModel.Size MapDTO(SizesUpdateCommandInput dtoItem, Guid integrationId, DomainModel.Size entity = null)
        {
            var result = entity ?? new DomainModel.Size();

            result.FunzaId = dtoItem.Id;
            result.IntegrationId = dtoItem.IntegrationId;

            result.FunzaCreatedBy = dtoItem.FunzaCreatedBy;
            result.FunzaCreatedDate = dtoItem.FunzaCreatedDate;
            result.Name = dtoItem.Name;
            result.AdmitValidation = dtoItem.AdmitValidation;
            result.AllowCause = dtoItem.AllowCause;
            result.Description = dtoItem.Description;
            result.EnglishName = dtoItem.EnglishName;
            result.Exportable = dtoItem.Exportable;
            result.FunzaCreatedBy = dtoItem.FunzaCreatedBy;
            result.FunzaCreatedDate = dtoItem.FunzaCreatedDate;
            result.Order = dtoItem.Order;
            result.State = dtoItem.State;
            result.Version = dtoItem.Version;

            return result;
        }
    }
}

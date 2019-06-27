using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand
{
    public class FunzaColorsUpdateCommand : AbstractDBCommand<Color, IColorDBRepository>, IFunzaColorsUpdateCommand
    {
        public FunzaColorsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IColorDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<ColorsUpdateCommandOutput> Execute(SyncCommandEntityWrapperInput<ColorsUpdateCommandInput> input)
        {
            var result = new OperationResponse<ColorsUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Color> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Color entity = null;

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

                    result.AddResponse(this.Repository.DeleteNotInIntegration(input.IntegrationId));


                }
                catch (Exception ex)
                {
                    result.AddError("Error Sync Funza Products", ex);
                }
            }

            return result;
        }

        private Color MapDTO(ColorsUpdateCommandInput dtoItem, Guid integrationId, Color entity = null)
        {
            var result = entity ?? new Color();

            result.FunzaId = dtoItem.FunzaId;
            result.IntegrationId = dtoItem.IntegrationId;

            result.Hexagecimal = dtoItem.ValueRGB;
            result.Image = dtoItem.Image;
            result.Name = dtoItem.Name;
            result.NameEnglish = dtoItem.NameEnglish;
            result.Status = dtoItem.Status;
            result.Version = dtoItem.Version;

            result.FunzaCreatedBy = dtoItem.CreatedBy;
            result.FunzaCreatedDate = dtoItem.FunzaCreatedDate;
            result.FunzaUpdatedBy = dtoItem.UpdatedBy;
            result.FunzaUpdatedDate = dtoItem.FunzaUpdatedDate;
            return result;
        }
    }
}

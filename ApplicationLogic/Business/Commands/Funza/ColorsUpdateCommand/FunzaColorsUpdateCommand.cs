using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.ColorsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel._Commons.Enums;
using DomainModel.Funza;

namespace ApplicationLogic.Business.Commands.Funza.ColorsUpdateCommand
{
    public class FunzaColorsUpdateCommand : AbstractDBCommand<DomainModel.Funza.ColorReference, IFunzaColorReferenceDBRepository>, IFunzaColorsUpdateCommand
    {
        public FunzaColorsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaColorReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FunzaColorsUpdateCommandOutputDTO> Execute(IEnumerable<FunzaColorsUpdateCommandInputDTO> input)
        {
            var result = new OperationResponse<FunzaColorsUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                OperationResponse<DomainModel.Funza.ColorReference> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Funza.ColorReference entity = null;

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

        private ColorReference MapDTO(FunzaColorsUpdateCommandInputDTO dtoItem, DomainModel.Funza.ColorReference entity = null)
        {
            var result = entity ?? new ColorReference();

            result.FunzaId = dtoItem.Id;

            result.Hexagecimal = dtoItem.Hexagecimal;
            result.Image = dtoItem.Image;
            result.Name = dtoItem.Name;
            result.NameEnglish = dtoItem.NameEnglish;
            result.State = dtoItem.State;
            result.Version = dtoItem.Version;

            result.FunzaCreatedBy = dtoItem.CreatedBy;
            result.FunzaCreatedDate = dtoItem.CreatedDate;
            result.FunzaUpdatedBy = dtoItem.UpdatedBy;
            result.FunzaUpdatedDate = dtoItem.UpdatedDate;
            return result;
        }
    }
}

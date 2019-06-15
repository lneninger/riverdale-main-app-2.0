using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand
{
    public class FunzaColorsUpdateCommand : AbstractDBCommand<Color, IColorDBRepository>, IFunzaColorsUpdateCommand
    {
        public FunzaColorsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IColorDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FunzaColorsUpdateCommandOutputDTO> Execute(IEnumerable<FunzaColorsUpdateCommandInputDTO> input)
        {
            var result = new OperationResponse<FunzaColorsUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                OperationResponse<Color> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                Color entity = null;

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

        private Color MapDTO(FunzaColorsUpdateCommandInputDTO dtoItem, Color entity = null)
        {
            var result = entity ?? new Color();

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

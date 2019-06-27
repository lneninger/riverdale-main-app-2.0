using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand
{
    public class FunzaPackingsUpdateCommand : AbstractDBCommand<DomainModel.Product, IPackingDBRepository>, IFunzaPackingsUpdateCommand
    {
        public FunzaPackingsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IPackingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PackingsUpdateCommandOutput> Execute(SyncCommandEntityWrapperInput<PackingsUpdateCommandInput> input)
        {
            var result = new OperationResponse<PackingsUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Packing> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Packing entity = null;

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
                    result.AddError("Error Sync Funza Packings", ex);
                }
            }

            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                result.AddResponse(this.Repository.DeleteNotInIntegration(input.IntegrationId));
            }

            return result;
        }

        private Packing MapDTO(PackingsUpdateCommandInput dtoItem, DomainModel.Packing entity = null)
        {
            var result = entity ?? new Packing();

            result.FunzaId = dtoItem.Id;
            result.FunzaCreatedBy = dtoItem.FunzaCreatedBy;
            result.FunzaCreatedDate = dtoItem.FunzaCreatedDate;
            result.FunzaUpdatedBy = dtoItem.FunzaUpdatedBy;
            result.FunzaUpdatedDate = dtoItem.FunzaUpdatedDate;
            result.Name = dtoItem.Name;
            result.NameEnglish = dtoItem.NameEnglish;
            result.Description = dtoItem.Description;
            result.EquivalentsFull = dtoItem.EquivalentsFull;
            result.Length = dtoItem.Length;
            result.Width = dtoItem.Width;
            result.Height = dtoItem.Height;
            result.Volume = dtoItem.Volume;
            result.Weight = dtoItem.Weight;
            result.State = dtoItem.Status;
            result.Image = dtoItem.Image;
            result.CargoMasterCode = dtoItem.CargoMasterCode;
            result.VolumeDescripcion = dtoItem.VolumeDescription;
            result.VolumeEquivalentFull = dtoItem.VolumeEquivalentFull;
            result.SentToQuotator = dtoItem.SentToQuotator;
            result.EquivalentFullQuotator = dtoItem.EquivalentFullQuotator;
            //result.DefinitiveInvoiceCargo = dtoItem.DefinitiveInvoiceCargo;
            //result.DefinitiveInvoiceItems = dtoItem.DefinitiveInvoiceItems;
            //result.NoteItems = dtoItem.NoteItems;

            return result;
        }
    }
}

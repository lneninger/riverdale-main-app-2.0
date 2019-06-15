using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using DomainModel._Commons.Enums;
using DomainModel.Funza;

namespace FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand
{
    public class FunzaPackingsUpdateCommand : AbstractDBCommand<DomainModel.Funza.Product, IPackingDBRepository>, IFunzaPackingsUpdateCommand
    {
        public FunzaPackingsUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IPackingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PackingsUpdateCommandOutput> Execute(IEnumerable<PackingsUpdateCommandInput> input)
        {
            var result = new OperationResponse<PackingsUpdateCommandOutput>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Funza.Packing> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Funza.Packing entity = null;

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
                    result.AddError("Error Sync Funza Packings", ex);
                }
            }

            return result;
        }

        private Packing MapDTO(PackingsUpdateCommandInput dtoItem, DomainModel.Funza.Packing entity = null)
        {
            var result = entity ?? new Packing();

            result.FunzaId = dtoItem.Id;
            result.FunzaCreatedBy = dtoItem.CreatedBy;
            result.FunzaCreatedDate = dtoItem.CreatedDate;
            result.FunzaUpdatedBy = dtoItem.UpdatedBy;
            result.FunzaUpdatedDate = dtoItem.UpdatedDate;
            result.Name = dtoItem.Name;
            result.NameEnglish = dtoItem.NameEnglish;
            result.Description = dtoItem.Description;
            result.EquivalentsFull = dtoItem.EquivalentsFull;
            result.Length = dtoItem.Length;
            result.Width = dtoItem.Width;
            result.Height = dtoItem.Height;
            result.Volume = dtoItem.Volume;
            result.Weight = dtoItem.Weight;
            result.State = dtoItem.State;
            result.Image = dtoItem.Image;
            result.CargoMasterCode = dtoItem.CargoMasterCode;
            result.VolumeDescripcion = dtoItem.VolumeDescripcion;
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

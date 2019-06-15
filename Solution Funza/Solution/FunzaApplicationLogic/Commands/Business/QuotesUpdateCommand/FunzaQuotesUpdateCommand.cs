using FunzaApplicationLogic.Commands.Funza.QuotesUpdateCommand.Models;
using ApplicationLogic.Repositories.DB;
using DomainModel.Funza;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.QuotesUpdateCommand
{
    public class FunzaQuotesUpdateCommand : AbstractDBCommand<DomainModel.Funza.QuoteReference, IQuoteDBRepository>, IFunzaQuotesUpdateCommand
    {
        public FunzaQuotesUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IQuoteDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FunzaQuotesUpdateCommandOutputDTO> Execute(IEnumerable<FunzaQuotesUpdateCommandInputDTO> input)
        {
            var result = new OperationResponse<FunzaQuotesUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                OperationResponse<DomainModel.Funza.QuoteReference> getByFunzaIdResult;
                OperationResponse prepareToSaveResult;
                DomainModel.Funza.QuoteReference entity = null;

                try
                {

                    foreach (var dtoItem in input)
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
                    result.AddError("Error Sync Funza Quotes", ex);
                }
            }

            return result;
        }

        private QuoteReference MapDTO(FunzaQuotesUpdateCommandInputDTO dtoItem, DomainModel.Funza.QuoteReference entity = null)
        {
            var result = entity ?? new QuoteReference();

            result.FunzaId = dtoItem.FunzaId;
            result.AdjustRequestUserId = dtoItem.AdjustRequestUserId;
            result.Code = dtoItem.Code;
            result.ComboId = dtoItem.ComboId;
            result.Comments = string.Join("#||#", dtoItem.Comments);
            result.ConfirmationPackingPrice = dtoItem.ConfirmationPackingPrice;
            result.ConfirmationPriceLabor = dtoItem.ConfirmationPriceLabor;
            result.CreatedByUserName = dtoItem.CreatedByUserName;
            result.CreateStep = dtoItem.CreateStep;
            result.CreationTime = dtoItem.CreationTime;
            result.CreatorUserId = dtoItem.CreatorUserId;
            result.FinalPrice = dtoItem.FinalPrice;
            result.LaborDiscount = dtoItem.LaborDiscount;
            result.LastModificationTime = dtoItem.LastModificationTime;
            result.Margen = dtoItem.Margen;
            result.PackingDescount = dtoItem.PackingDescount;
            result.PackingId = dtoItem.PackingId;
            result.PackingName = dtoItem.PackingName;
            result.PackingPrice = dtoItem.PackingPrice;

            return result;
        }
    }
}

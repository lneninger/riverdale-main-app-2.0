using ApplicationLogic.Business.Commands.Funza.QuotesUpdateCommand.Models;
using DomainModel.Funza;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.QuotesUpdateCommand
{
    public class FunzaQuotesUpdateCommand : AbstractDBCommand<DomainModel.Funza.QuoteReference, IFunzaQuoteReferenceDBRepository>, IFunzaQuotesUpdateCommand
    {
        public FunzaQuotesUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaQuoteReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
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
                    result.AddError("Error Sync Funza Quotes", ex);
                }
            }

            return result;
        }

        private QuoteReference MapDTO(FunzaQuotesUpdateCommandInputDTO dtoItem, DomainModel.Funza.QuoteReference entity = null)
        {
            var result = entity ?? new QuoteReference();

            result.FunzaId = dtoItem.Id;
            result.Active = dtoItem.Active;
            result.CategoryId = dtoItem.CategoryId;
            result.CategoryName = dtoItem.CategoryName;
            result.Code = dtoItem.Code;
            result.ColorId = dtoItem.ColorId;
            result.Description = dtoItem.Description;
            result.GradeId = dtoItem.GradeId;
            result.Comments = dtoItem.Comments;
            result.QuoteTypeId = dtoItem.QuoteTypeId;
            result.QuoteTypeName = dtoItem.QuoteTypeName;
            result.ReferenceCode = dtoItem.ReferenceCode;
            result.ReferenceDescription = dtoItem.ReferenceDescription;
            result.ReferenceId = dtoItem.ReferenceId;
            result.ReferenceTypeId = dtoItem.ReferenceTypeId;
            result.ReferenceTypeName = dtoItem.ReferenceTypeName;
            result.SendQuotator = dtoItem.SendQuotator;
            result.SpecieId = dtoItem.SpecieId;
            result.FunzaUpdatedDate = dtoItem.FunzaUpdatedDate;
            result.VarieryId = dtoItem.VarieryId;

            return result;
        }
    }
}

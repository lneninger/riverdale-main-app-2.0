﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models;
using Framework.Core.Messages;
using DomainModel.Product;
using System.Linq;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand
{
    public class SaleOpportunityTargetPriceInsertCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice, ISaleOpportunityTargetPriceDBRepository>, ISaleOpportunityTargetPriceInsertCommand
    {
        public SaleOpportunityTargetPriceInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<SaleOpportunityTargetPriceInsertCommandOutputDTO> Execute(SaleOpportunityTargetPriceInsertCommandInputDTO input)
        {
            var result = new OperationResponse<SaleOpportunityTargetPriceInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.SaleOpportunity.SaleOpportunityTargetPrice
                {
                    SaleOpportunityId = input.SaleOpportunityId,
                    AlterenativesAmount = input.AlterenativesAmount,
                    TargetPrice = input.TargetPrice,
                    SaleSeasonTypeId = input.SaleSeasonTypeId,
                };

                try
                {
                    var insertResult = this.Repository.Insert(entity);
                    result.AddResponse(insertResult);
                    if (result.IsSucceed)
                    {
                        dbContextScope.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    result.AddError("Error adding Sample Box", ex);
                }

                if (result.IsSucceed)
                {
                    //this.Repository.Detach(entity.Id);
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new SaleOpportunityTargetPriceInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            TargetPrice = getByIdResult.Bag.TargetPrice,
                            SaleSeasonTypeId = getByIdResult.Bag.SaleSeasonTypeId,
                            AlterenativesAmount = getByIdResult.Bag.AlterenativesAmount,
                            SaleOpportunityId = getByIdResult.Bag.SaleOpportunityId,
                        };
                    }

                }
            }

            return result;
        }
    }
}
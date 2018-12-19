using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand
{
    public class CustomerFreightoutInsertCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutInsertCommand
    {
        public CustomerFreightoutInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerFreightoutInsertCommandOutputDTO> Execute(CustomerFreightoutInsertCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerFreightoutInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.CustomerFreightout
                {
                    Cost = input.Cost ?? 0,
                    CustomerFreightoutRateTypeId = input.CustomerFreightoutRateTypeId,
                    CustomerId = input.CustomerId,
                    DateFrom = input.DateFrom ?? DateTime.UtcNow,
                    DateTo = input.DateTo ?? DateTime.UtcNow,
                    SecondLeg = input.SecondLeg ?? 0,
                    SurchargeHourly = input.SurchargeHourly,
                    SurchargeYearly = input.SurchargeYearly,
                    WProtect = input.WProtect ?? 0,
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
                    result.AddError("Error Adding Customer Freightout", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new CustomerFreightoutInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            CustomerId = getByIdResult.Bag.CustomerId,
                            CustomerName = getByIdResult.Bag.Customer.Name,
                            Cost = getByIdResult.Bag.Cost,
                            CustomerFreightoutRateTypeId = getByIdResult.Bag.CustomerFreightoutRateTypeId,
                            DateFrom = getByIdResult.Bag.DateFrom,
                            DateTo = getByIdResult.Bag.DateTo,
                            SecondLeg = getByIdResult.Bag.SecondLeg,
                            SurchargeHourly = getByIdResult.Bag.SurchargeHourly,
                            SurchargeYearly = getByIdResult.Bag.SurchargeYearly,
                            WProtect = getByIdResult.Bag.WProtect,
                        };
                    }

                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand
{
    public class CustomerFreightoutUpdateCommand : AbstractDBCommand<DomainModel.Company.Customer.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutUpdateCommand
    {
        public CustomerFreightoutUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerFreightoutUpdateCommandOutputDTO> Execute(CustomerFreightoutUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerFreightoutUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    getByIdResult.Bag.Cost = input.Cost;
                    getByIdResult.Bag.CustomerFreightoutRateTypeId = input.CustomerFreightoutRateTypeId;
                    getByIdResult.Bag.CustomerId = input.CustomerId;
                    getByIdResult.Bag.DateFrom = input.DateFrom;
                    getByIdResult.Bag.DateTo = input.DateTo;
                    getByIdResult.Bag.SecondLeg = input.SecondLeg;
                    getByIdResult.Bag.SurchargeHourly = input.SurchargeHourly;
                    getByIdResult.Bag.SurchargeYearly = input.SurchargeYearly;
                    getByIdResult.Bag.WProtect = input.WProtect;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new CustomerFreightoutUpdateCommandOutputDTO
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

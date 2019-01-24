using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand
{
    public class CustomerFreightoutGetByIdCommand : AbstractDBCommand<DomainModel.Company.Customer.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutGetByIdCommand
    {

        public CustomerFreightoutGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerFreightoutGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<CustomerFreightoutGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new CustomerFreightoutGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        CustomerId = getByIdResult.Bag.CustomerId,
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

            return result;
        }
    }
}

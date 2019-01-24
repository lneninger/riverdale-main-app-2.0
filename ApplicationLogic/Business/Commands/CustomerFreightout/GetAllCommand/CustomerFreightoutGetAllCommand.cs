using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand
{
    public class CustomerFreightoutGetAllCommand : AbstractDBCommand<DomainModel.Company.Customer.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutGetAllCommand
    {
        public CustomerFreightoutGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<CustomerFreightoutGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<CustomerFreightoutGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new CustomerFreightoutGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Cost = entityItem.Cost,
                        CustomerFreightoutRateTypeId = entityItem.CustomerFreightoutRateTypeId,
                        CustomerId = entityItem.CustomerId,
                        DateFrom = entityItem.DateFrom,
                        DateTo = entityItem.DateTo,
                        SecondLeg = entityItem.SecondLeg,
                        SurchargeHourly = entityItem.SurchargeHourly,
                        SurchargeYearly = entityItem.SurchargeYearly,
                        WProtect = entityItem.WProtect,

                    }).ToList();
                }
            }

            return result;
        }
    }
}

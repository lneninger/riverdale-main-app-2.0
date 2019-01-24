using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand
{
    public class CustomerFreightoutDeleteCommand : AbstractDBCommand<DomainModel.Company.Customer.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutDeleteCommand
    {
        public CustomerFreightoutDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerFreightoutDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<CustomerFreightoutDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new CustomerFreightoutDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        CustomerName = getByIdResult.Bag.Customer.Name,
                        SecondLeg = getByIdResult.Bag.SecondLeg,
                        SurchargeHourly = getByIdResult.Bag.SurchargeHourly,
                        SurchargeYearly = getByIdResult.Bag.SurchargeYearly,
                    };
                }

                var deleteResult = this.Repository.Delete(id);
                result.AddResponse(deleteResult);
                if (result.IsSucceed)
                {
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddException("Error deleting Customer Freightout", ex);
                    }
                }
            }

            return result;
        }
    }
}

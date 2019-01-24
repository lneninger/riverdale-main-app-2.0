using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Customer.DeleteCommand
{
    public class CustomerDeleteCommand : AbstractDBCommand<DomainModel.Company.Customer.Customer, ICustomerDBRepository>, ICustomerDeleteCommand
    {
        public CustomerDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerDeleteCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<CustomerDeleteCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new CustomerDeleteCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        Name = getByIdResult.Bag.Name,
                    };
                }

                var deleteResult = this.Repository.Delete(getByIdResult.Bag);
                result.AddResponse(deleteResult);
                if (result.IsSucceed)
                {
                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddException("Error deleting Customer", ex);
                    }
                }
            }

            return result;
        }
    }
}

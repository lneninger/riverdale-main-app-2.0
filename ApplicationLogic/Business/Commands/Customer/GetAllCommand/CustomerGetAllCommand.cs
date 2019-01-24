using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Linq;

namespace ApplicationLogic.Business.Commands.Customer.GetAllCommand
{
    public class CustomerGetAllCommand : AbstractDBCommand<DomainModel.Company.Customer.Customer, ICustomerDBRepository>, ICustomerGetAllCommand
    {
        public CustomerGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<CustomerGetAllCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<CustomerGetAllCommandOutputDTO>>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getAllResult = this.Repository.GetAll();
                result.AddResponse(getAllResult);
                if (result.IsSucceed)
                {
                    result.Bag = getAllResult.Bag.Select(entityItem => new CustomerGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        Name = entityItem.Name,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }

            return result;
        }
    }
}

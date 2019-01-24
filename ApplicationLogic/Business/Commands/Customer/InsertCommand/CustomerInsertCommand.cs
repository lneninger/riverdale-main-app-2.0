using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand
{
    public class CustomerInsertCommand : AbstractDBCommand<DomainModel.Company.Customer.Customer, ICustomerDBRepository>, ICustomerInsertCommand
    {
        public CustomerInsertCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerInsertCommandOutputDTO> Execute(CustomerInsertCommandInputDTO input)
        {
            var result = new OperationResponse<CustomerInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var entity = new DomainModel.Company.Customer.Customer
                {
                    Name = input.Name,
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
                    result.AddError("Error Adding Customer", ex);
                }

                if (result.IsSucceed)
                {
                    var getByIdResult = this.Repository.GetById(entity.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new CustomerInsertCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            Name = getByIdResult.Bag.Name
                        };
                    }

                }
            }

            return result;
        }
    }
}

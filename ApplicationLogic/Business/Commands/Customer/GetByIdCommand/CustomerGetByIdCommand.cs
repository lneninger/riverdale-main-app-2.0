﻿using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand
{
    public class CustomerGetByIdCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerGetByIdCommand
    {

        public CustomerGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<CustomerGetByIdCommandOutputDTO> Execute(int id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}

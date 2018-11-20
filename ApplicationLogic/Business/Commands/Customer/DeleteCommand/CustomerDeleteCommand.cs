﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using FocusServices.Business.Commands.Customer.DeleteCommand.Models;

namespace FocusServices.Business.Commands.Customer.DeleteCommand
{
    public class CustomerDeleteCommand : AbstractDBCommand<DomainModel.Customer, ICustomerDBRepository>, ICustomerDeleteCommand
    {
        public CustomerDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerDeleteCommandOutputDTO Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}

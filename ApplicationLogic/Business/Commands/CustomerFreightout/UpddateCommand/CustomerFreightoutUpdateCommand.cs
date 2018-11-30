﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using FocusApplication.Repositories.DB;
using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand
{
    public class CustomerFreightoutUpdateCommand : AbstractDBCommand<DomainModel.CustomerFreightout, ICustomerFreightoutDBRepository>, ICustomerFreightoutUpdateCommand
    {
        public CustomerFreightoutUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, ICustomerFreightoutDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public CustomerFreightoutUpdateCommandOutputDTO Execute(CustomerFreightoutUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}

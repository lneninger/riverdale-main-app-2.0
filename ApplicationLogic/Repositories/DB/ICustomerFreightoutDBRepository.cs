﻿using DomainModel;
using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Repositories.DB
{
    public interface ICustomerFreightoutDBRepository: IDBRepository
    {
        IEnumerable<CustomerFreightoutGetAllCommandOutputDTO> GetAll();
        PageResult<CustomerFreightoutPageQueryCommandOutputDTO> PageQuery(PageQuery<CustomerFreightoutPageQueryCommandInputDTO> input);
        CustomerFreightoutGetByIdCommandOutputDTO GetById(int id);
        CustomerFreightoutInsertCommandOutputDTO Insert(CustomerFreightoutInsertCommandInputDTO input);
        CustomerFreightoutUpdateCommandOutputDTO Update(CustomerFreightoutUpdateCommandInputDTO input);
        CustomerFreightoutDeleteCommandOutputDTO Delete(int id);
    }
}

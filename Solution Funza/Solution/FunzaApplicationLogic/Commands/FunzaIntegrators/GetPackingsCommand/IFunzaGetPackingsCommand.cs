﻿using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using Framework.Commands;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaDirectClients.Clients.Packing.Models;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand
{
    public interface IFunzaGetPackingsCommand : ICommandFuncAsync<PageQuery<GetPackingsCommandInput>, OperationResponse<IEnumerable<DirectGetPackingsResult>>>
    {
    }
}
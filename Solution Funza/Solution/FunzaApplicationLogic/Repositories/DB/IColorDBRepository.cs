﻿using System;
using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.ColorPageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface IColorDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Color> GetById(int id);

        OperationResponse Add(Color entity);

        OperationResponse<Color> GetByFunzaId(int id);

        OperationResponse<PageResult<ColorPageQueryCommandOutput>> PageQuery(PageQuery<ColorPageQueryCommandInput> input);

        OperationResponse DeleteNotInIntegration(Guid integrationId);
    }
}

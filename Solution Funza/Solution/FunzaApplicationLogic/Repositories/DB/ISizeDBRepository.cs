using System;
using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.ColorPageQueryCommand.Models;
using FunzaApplicationLogic.Commands.Size.SizePageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISizeDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Size> GetById(int id);

        OperationResponse Add(Size entity);

        OperationResponse<Size> GetByFunzaId(string id);

        OperationResponse<PageResult<SizePageQueryCommandOutput>> PageQuery(PageQuery<SizePageQueryCommandInput> input);

        OperationResponse DeleteNotInIntegration(Guid integrationId);

        OperationResponse<Size> GetByFunzaId(int id);
    }
}

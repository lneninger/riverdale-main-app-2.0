using DomainModel;
using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.InsertCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface IAppUserRoleDBRepository: IDBRepository
    {
        IEnumerable<AppUserRoleGetAllCommandOutputDTO> GetAll();
        PageResult<AppUserRolePageQueryCommandOutputDTO> PageQuery(PageQuery<AppUserRolePageQueryCommandInputDTO> input);
        AppUserRoleGetByIdCommandOutputDTO GetById(string id);
        OperationResponse<AppUserRoleInsertCommandOutputDTO> Insert(AppUserRoleInsertCommandInputDTO input);
        AppUserRoleUpdateCommandOutputDTO Update(AppUserRoleUpdateCommandInputDTO input);
        AppUserRoleDeleteCommandOutputDTO Delete(string id);
    }
}

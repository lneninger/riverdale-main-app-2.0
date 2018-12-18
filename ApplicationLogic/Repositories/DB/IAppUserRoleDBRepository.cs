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
using Framework.Core.Messages;
using ApplicationLogic.Business.Commands.AppUserRole.GetByNameCommand.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IAppUserRoleDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<AppUserRoleGetAllCommandOutputDTO>> GetAll();
        OperationResponse<PageResult<AppUserRolePageQueryCommandOutputDTO>> PageQuery(PageQuery<AppUserRolePageQueryCommandInputDTO> input);
        OperationResponse<AppUserRoleGetByNameCommandOutputDTO> GetByName(string name);
        OperationResponse<AppUserRoleGetByIdCommandOutputDTO> GetById(string id);
        OperationResponse<AppUserRoleInsertCommandOutputDTO> Insert(AppUserRoleInsertCommandInputDTO input);
        OperationResponse<AppUserRoleUpdateCommandOutputDTO> Update(AppUserRoleUpdateCommandInputDTO input);
        OperationResponse<AppUserRoleDeleteCommandOutputDTO> Delete(string id);
    }
}

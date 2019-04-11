using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetByNameCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.InsertCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using DomainModel.Identity;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IAppUserRoleDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<AppUserRoleGetAllCommandOutputDTO>> GetAll();
        OperationResponse<PageResult<AppUserRolePageQueryCommandOutputDTO>> PageQuery(PageQuery<AppUserRolePageQueryCommandInputDTO> input);
        OperationResponse<AppUserRoleGetByNameCommandOutputDTO> GetByName(string name);
        OperationResponse<IdentityRole> GetById(string id);
        OperationResponse<IEnumerable<AppUser>> GetUsersByRoleId(string id);
        OperationResponse<IEnumerable<IdentityRoleClaim<string>>> GetPermissionsByRoleId(string id);
        OperationResponse<AppUserRoleInsertCommandOutputDTO> Insert(AppUserRoleInsertCommandInputDTO input);
        OperationResponse<AppUserRoleUpdateCommandOutputDTO> Update(AppUserRoleUpdateCommandInputDTO input);
        OperationResponse<AppUserRoleDeleteCommandOutputDTO> Delete(string id);
    }
}

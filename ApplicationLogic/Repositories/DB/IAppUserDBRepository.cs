using ApplicationLogic.Business.Commands.AppUser.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Repositories.DB
{
    public interface IAppUserDBRepository : IDBRepository
    {
        IEnumerable<AppUserGetAllCommandOutputDTO> GetAll();

        AppUserGetByIdCommandOutputDTO GetById(string id);

        PageResult<AppUserPageQueryCommandOutputDTO> PageQuery(PageQuery<AppUserPageQueryCommandInputDTO> input);

        AppUserRegisterCommandOutputDTO Insert(AppUserRegisterCommandInputDTO input);

        AppUserUpdateCommandOutputDTO Update(AppUserUpdateCommandInputDTO input);

        AppUserDeleteCommandOutputDTO Delete(string id);

    }
}

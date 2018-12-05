using ApplicationLogic.Business.Commands.AppUser.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Repositories.DB
{
    public interface IAppUserDBRepository : IDBRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<AppUserGetAllCommandOutputDTO> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AppUserGetByIdCommandOutputDTO GetById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PageResult<AppUserPageQueryCommandOutputDTO> PageQuery(PageQuery<AppUserPageQueryCommandInputDTO> input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ExistsByEmail(string email);

        bool ExistsByUserName(string userName);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        OperationResponse<AppUserRegisterCommandOutputDTO> Insert(AppUserRegisterCommandInputDTO input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        OperationResponse<AppUserAuthenticateCommandOutputDTO> Authenticate(AppUserAuthenticateCommandInputDTO input);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        OperationResponse<AppUserUpdateCommandOutputDTO> Update(AppUserUpdateCommandInputDTO input);

        /// <summary>
        /// MARK user as deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OperationResponse<AppUserDeleteCommandOutputDTO> Delete(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool ExistsByEmailOrUserName(string email, string userName);
    }
}

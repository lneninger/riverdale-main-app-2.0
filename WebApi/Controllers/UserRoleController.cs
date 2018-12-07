﻿using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand;
using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand;
using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand;
using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.InsertCommand;
using ApplicationLogic.Business.Commands.AppUserRole.InsertCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand;
using ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand;
using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using CommunicationModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// UserRole API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/userrole")]
    public class UserRoleController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleController"/> class.
        /// </summary>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public UserRoleController(IAppUserRolePageQueryCommand pageQueryCommand, IAppUserRoleGetAllCommand getAllCommand, IAppUserRoleGetByIdCommand getByIdCommand, IAppUserRoleInsertCommand insertCommand, IAppUserRoleUpdateCommand updateCommand, IAppUserRoleDeleteCommand deleteCommand)
        {
            this.PageQueryCommand = pageQueryCommand;
            this.GetAllCommand = getAllCommand;
            this.GetByIdCommand = getByIdCommand;
            this.InsertCommand = insertCommand;
            this.UpdateCommand = updateCommand;
            this.DeleteCommand = deleteCommand;
        }

        /// <summary>
        /// Gets the get all command.
        /// </summary>
        /// <value>
        /// The get all command.
        /// </value>
        public IAppUserRoleGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IAppUserRolePageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IAppUserRoleGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public IAppUserRoleInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public IAppUserRoleUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public IAppUserRoleDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<AppUserRolePageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<AppUserRolePageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<AppUserRoleGetAllCommandOutputDTO>))]
        public IActionResult Get()
        {
            var appResult = this.GetAllCommand.Execute();
            return this.Ok(appResult);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(AppUserRoleGetByIdCommandOutputDTO))]
        public IActionResult Get(string id)
        {
            var result = this.GetByIdCommand.Execute(id);
            return this.Ok(result);
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(AppUserRoleInsertCommandOutputDTO))]
        public IActionResult Post([FromBody]AppUserRoleInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(AppUserRoleUpdateCommandOutputDTO))]
        public IActionResult Put([FromBody]AppUserRoleUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(AppUserRoleDeleteCommandOutputDTO))]
        public IActionResult Delete(string id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

using ApplicationLogic.Business.Commands.AppUser.DeleteCommand;
using ApplicationLogic.Business.Commands.AppUser.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetAllCommand;
using ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.PageQueryCommand;
using ApplicationLogic.Business.Commands.AppUser.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.UpdateCommand;
using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// AppUser API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="registerCommand">The register command</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public UserController(IAppUserPageQueryCommand pageQueryCommand, IAppUserGetAllCommand getAllCommand, IAppUserGetByIdCommand getByIdCommand, IAppUserRegisterCommand registerCommand, IAppUserUpdateCommand updateCommand, IAppUserDeleteCommand deleteCommand)
        {
            this.PageQueryCommand = pageQueryCommand;
            this.GetAllCommand = getAllCommand;
            this.GetByIdCommand = getByIdCommand;
            this.RegisterCommand = registerCommand;
            this.UpdateCommand = updateCommand;
            this.DeleteCommand = deleteCommand;
        }

        /// <summary>
        /// Gets the get all command.
        /// </summary>
        /// <value>
        /// The get all command.
        /// </value>
        public IAppUserGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IAppUserPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IAppUserGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public IAppUserRegisterCommand RegisterCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public IAppUserUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public IAppUserDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<AppUserPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<AppUserPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<AppUserGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(AppUserGetByIdCommandOutputDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(AppUserRegisterCommandOutputDTO))]
        public IActionResult Post([FromBody]AppUserRegisterCommandInputDTO model)
        {
            var appResult = this.RegisterCommand.Execute(model);
            return this.Ok(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(AppUserUpdateCommandOutputDTO))]
        public IActionResult Put([FromBody]AppUserUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return this.Ok(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(AppUserDeleteCommandOutputDTO))]
        public IActionResult Delete(string id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return this.Ok(appResult);
        }
        
    }
}

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
using ApplicationLogic.Business.Commands.Security;
using DomainModel.Identity;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;
using Framework.Web.Helpers;
using Microsoft.AspNetCore.Identity;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using RiverdaleMainApp2_0.Auth.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// AppUser API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/user")]
    public class UserClaimController : Controller
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
        public UserClaimController(UserManager<AppUser> userManager, IAppUserPageQueryCommand pageQueryCommand, IAppUserGetAllCommand getAllCommand, IAppUserGetByIdCommand getByIdCommand, IAppUserRegisterCommand registerCommand, IAppUserUpdateCommand updateCommand, IAppUserDeleteCommand deleteCommand)
        {
            this.UserManager = userManager;
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>
        /// The user manager.
        /// </value>
        public UserManager<AppUser> UserManager { get; }

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
        /// Posts the user manager.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [HttpPost("forUser")]
        public async Task<IActionResult> Post([FromBody]AppUserClaimInsertCommandInputDTO input)
        {
            var result = new OperationResponse<AppUserClaimInsertCommandInputDTO>();
            if (!ModelState.IsValid)
            {
                result.AddModelState(ModelState);
                //return BadRequest(ModelState);
            }
            else
            {
                var user = this.UserManager.FindByIdAsync(input.UserId);
                if (user != null)
                {
                    await this.UserManager.AddClaimAsync(new AppUser(), new System.Security.Claims.Claim(RiverdaleMainApp2_0.Auth.Constants.Strings.JwtClaimIdentifiers.Permissions, input.Claim));
                }
                else
                {

                }
            }

            return new OkObjectResult("Account created");
        }


        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(AppUserUpdateCommandOutputDTO))]
        public IActionResult Put([FromBody]AppUserUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
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
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

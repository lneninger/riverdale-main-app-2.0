using ApplicationLogic.Business.Commands.Grower.DeleteCommand;
using ApplicationLogic.Business.Commands.Grower.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Grower.GetAllCommand;
using ApplicationLogic.Business.Commands.Grower.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.Grower.GetByIdCommand;
using ApplicationLogic.Business.Commands.Grower.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.Grower.InsertCommand;
using ApplicationLogic.Business.Commands.Grower.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Grower.PageQueryCommand;
using ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Grower.UpdateCommand;
using ApplicationLogic.Business.Commands.Grower.UpdateCommand.Models;
using ApplicationLogic.SignalR;
using CommunicationModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Authorization = Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiverdaleMainApp2_0.Auth;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Framework.SignalR;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Grower API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/grower")]
    public class GrowerController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GrowerController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public GrowerController(IHubContext<GlobalHub, IGlobalHub> hubContext, IGrowerPageQueryCommand pageQueryCommand, IGrowerGetAllCommand getAllCommand, IGrowerGetByIdCommand getByIdCommand, IGrowerInsertCommand insertCommand, IGrowerUpdateCommand updateCommand, IGrowerDeleteCommand deleteCommand): base(/*hubContext*/)
        {
            this.SignalRHubContext = hubContext;
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
        public IGrowerGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IGrowerPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IGrowerGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public IGrowerInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public IGrowerUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public IGrowerDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<GrowerPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<GrowerPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<GrowerGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(GrowerGetByIdCommandOutputDTO))]
        public IActionResult Get(int id)
        {
            var result = this.GetByIdCommand.Execute(id);

            return this.Ok(result);
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(GrowerInsertCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.Grower_Manage)]
        public IActionResult Post([FromBody]GrowerInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            if(appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), nameof(DomainModel.Company.Grower.Grower), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }

            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(GrowerUpdateCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.Grower_Modify, Roles = Constants.Strings.JwtClaims.Administrator)]
        public IActionResult Put([FromBody]GrowerUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(GrowerDeleteCommandOutputDTO))]
        public IActionResult Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

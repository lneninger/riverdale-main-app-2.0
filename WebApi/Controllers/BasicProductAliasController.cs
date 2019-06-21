using ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand;
using ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand;
using ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand;
using ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand;
using ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand;
using ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand;
using ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand.Models;
using ApplicationLogic.SignalR;
using CommunicationModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Authorization = Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiverdaleMainApp2_0.Auth;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Framework.SignalR;
using DomainModel.Product;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// BasicProductAlias API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/basicproductalias")]
    public class BasicProductAliasController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicProductAliasController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public BasicProductAliasController(IHubContext<GlobalHub, IGlobalHub> hubContext, IBasicProductAliasPageQueryCommand pageQueryCommand, IBasicProductAliasGetAllCommand getAllCommand, IBasicProductAliasGetByIdCommand getByIdCommand, IBasicProductAliasInsertCommand insertCommand, IBasicProductAliasUpdateCommand updateCommand, IBasicProductAliasDeleteCommand deleteCommand): base(/*hubContext*/)
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
        public IBasicProductAliasGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IBasicProductAliasPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IBasicProductAliasGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public IBasicProductAliasInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public IBasicProductAliasUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public IBasicProductAliasDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<BasicProductAliasPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<BasicProductAliasPageQueryCommandInputDTO> input)
        {
            var appResult = this.PageQueryCommand.Execute(input);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), nameof(BasicProductAlias), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }

            return this.Ok(appResult);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<BasicProductAliasGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(BasicProductAliasGetByIdCommandOutputDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(BasicProductAliasInsertCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.BasicProductAlias_Manage)]
        public IActionResult Post([FromBody]BasicProductAliasInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            if(appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), nameof(DomainModel.Product.BasicProductAlias), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }

            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(BasicProductAliasUpdateCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.BasicProductAlias_Modify, Roles = Constants.Strings.JwtClaims.Administrator)]
        public IActionResult Put([FromBody]BasicProductAliasUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.UPDATED_ITEM), nameof(DomainModel.Product.BasicProductAlias), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }

            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(BasicProductAliasDeleteCommandOutputDTO))]
        public IActionResult Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.DELETED_ITEM), nameof(DomainModel.Product.BasicProductAlias), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }

            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

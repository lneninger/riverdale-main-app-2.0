using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetAllCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.UpdateCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.UpdateCommand.Models;
using ApplicationLogic.SignalR;
using DomainModel.SaleOpportunity;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RiverdaleMainApp2_0.Auth;
using System.Collections.Generic;
using Authorization = Microsoft.AspNetCore.Authorization;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// SaleOpportunityTargetPriceProduct API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/saleopportunityTargetPriceproduct")]
    public class SaleOpportunityTargetPriceProductController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOpportunityTargetPriceProductController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public SaleOpportunityTargetPriceProductController(IHubContext<GlobalHub, IGlobalHub> hubContext, ISaleOpportunityTargetPriceProductPageQueryCommand pageQueryCommand, ISaleOpportunityTargetPriceProductGetAllCommand getAllCommand, ISaleOpportunityTargetPriceProductGetByIdCommand getByIdCommand, ISaleOpportunityTargetPriceProductInsertCommand insertCommand, ISaleOpportunityTargetPriceProductUpdateCommand updateCommand, ISaleOpportunityTargetPriceProductDeleteCommand deleteCommand):base(/*hubContext*/)
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
        public ISaleOpportunityTargetPriceProductGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public ISaleOpportunityTargetPriceProductPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public ISaleOpportunityTargetPriceProductGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public ISaleOpportunityTargetPriceProductInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public ISaleOpportunityTargetPriceProductUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public ISaleOpportunityTargetPriceProductDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<SaleOpportunityTargetPriceProductPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return result.IsSucceed ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<SaleOpportunityTargetPriceProductGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(SaleOpportunityTargetPriceProductGetByIdCommandOutputDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(SaleOpportunityTargetPriceProductInsertCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.SaleOpportunityTargetPriceProduct_Manage)]
        public IActionResult Post([FromBody]SaleOpportunityTargetPriceProductInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), nameof(SaleOpportunityTargetPriceProduct), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }

            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(SaleOpportunityTargetPriceProductUpdateCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.SaleOpportunityTargetPriceProduct_Modify, Roles = Constants.Strings.JwtClaims.Administrator)]
        public IActionResult Put([FromBody]SaleOpportunityTargetPriceProductUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(SaleOpportunityTargetPriceProductDeleteCommandOutputDTO))]
        public IActionResult Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

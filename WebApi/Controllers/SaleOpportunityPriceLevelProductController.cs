using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand.Models;
using ApplicationLogic.SignalR;
using CommunicationModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.SignalR;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authorization;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RiverdaleMainApp2_0.Auth;
using System.Collections.Generic;
using System.Linq;
using Authorization = Microsoft.AspNetCore.Authorization;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// SaleOpportunityPriceLevelProduct API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/saleopportunitypricelevelproduct")]
    public class SaleOpportunityPriceLevelProductController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOpportunityPriceLevelProductController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public SaleOpportunityPriceLevelProductController(IHubContext<GlobalHub, IGlobalHub> hubContext, ISaleOpportunityPriceLevelProductPageQueryCommand pageQueryCommand, ISaleOpportunityPriceLevelProductGetAllCommand getAllCommand, ISaleOpportunityPriceLevelProductGetByIdCommand getByIdCommand, ISaleOpportunityPriceLevelProductInsertCommand insertCommand, ISaleOpportunityPriceLevelProductUpdateCommand updateCommand, ISaleOpportunityPriceLevelProductDeleteCommand deleteCommand):base(/*hubContext*/)
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
        public ISaleOpportunityPriceLevelProductGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public ISaleOpportunityPriceLevelProductPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public ISaleOpportunityPriceLevelProductGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public ISaleOpportunityPriceLevelProductInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public ISaleOpportunityPriceLevelProductUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public ISaleOpportunityPriceLevelProductDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<SaleOpportunityPriceLevelProductPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return result.IsSucceed ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<SaleOpportunityPriceLevelProductGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(SaleOpportunityPriceLevelProductGetByIdCommandOutputDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(SaleOpportunityPriceLevelProductInsertCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.SaleOpportunityPriceLevelProduct_Manage)]
        public IActionResult Post([FromBody]SaleOpportunityPriceLevelProductInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), "SaleOpportunityPriceLevelProduct", appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);

            }
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(SaleOpportunityPriceLevelProductUpdateCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.SaleOpportunityPriceLevelProduct_Modify, Roles = Constants.Strings.JwtClaims.Administrator)]
        public IActionResult Put([FromBody]SaleOpportunityPriceLevelProductUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(SaleOpportunityPriceLevelProductDeleteCommandOutputDTO))]
        public IActionResult Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

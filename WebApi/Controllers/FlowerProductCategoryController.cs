using ApplicationLogic.Business.Commands.FlowerProductCategory.DeleteCommand;
using ApplicationLogic.Business.Commands.FlowerProductCategory.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand;
using ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand;
using ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand;
using ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand.Models;
using ApplicationLogic.Business.Commands.FlowerProductCategory.PageQueryCommand;
using ApplicationLogic.Business.Commands.FlowerProductCategory.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand;
using ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand.Models;
using ApplicationLogic.SignalR;
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
    /// Product API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/flowerproductcategory")]
    public class FlowerProductCategoryController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public FlowerProductCategoryController(IHubContext<GlobalHub, IGlobalHub> hubContext, IFlowerProductCategoryPageQueryCommand pageQueryCommand, IFlowerProductCategoryGetAllCommand getAllCommand, IFlowerProductCategoryGetByIdCommand getByIdCommand, IFlowerProductCategoryInsertCommand insertCommand, IFlowerProductCategoryUpdateCommand updateCommand, IFlowerProductCategoryDeleteCommand deleteCommand):base(/*hubContext*/)
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
        public IFlowerProductCategoryGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IFlowerProductCategoryPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IFlowerProductCategoryGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public IFlowerProductCategoryInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public IFlowerProductCategoryUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public IFlowerProductCategoryDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<FlowerProductCategoryPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<FlowerProductCategoryPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<FlowerProductCategoryGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(FlowerProductCategoryGetByIdCommandOutputDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(FlowerProductCategoryInsertCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.FlowerProductCategory_Manage)]
        public IActionResult Post([FromBody]FlowerProductCategoryInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), "FlowerProductCategory", appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);

            }
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(FlowerProductCategoryUpdateCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.FlowerProductCategory_Modify, Roles = Constants.Strings.JwtClaims.Administrator)]
        public IActionResult Put([FromBody]FlowerProductCategoryUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(FlowerProductCategoryDeleteCommandOutputDTO))]
        public IActionResult Delete(string id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

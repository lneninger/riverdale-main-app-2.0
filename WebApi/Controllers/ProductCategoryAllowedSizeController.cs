﻿using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand.Models;
using ApplicationLogic.SignalR;
using DomainModel.Product;
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
    /// Product API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/productcategoryallowedsize")]
    public class ProductCategoryAllowedSizeController : BaseController
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
        public ProductCategoryAllowedSizeController(IHubContext<GlobalHub, IGlobalHub> hubContext, IProductCategoryAllowedSizePageQueryCommand pageQueryCommand, IProductCategoryAllowedSizeGetAllCommand getAllCommand, IProductCategoryAllowedSizeGetByIdCommand getByIdCommand, IProductCategoryAllowedSizeInsertCommand insertCommand, IProductCategoryAllowedSizeUpdateCommand updateCommand, IProductCategoryAllowedSizeDeleteCommand deleteCommand):base(/*hubContext*/)
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
        public IProductCategoryAllowedSizeGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IProductCategoryAllowedSizePageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IProductCategoryAllowedSizeGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public IProductCategoryAllowedSizeInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public IProductCategoryAllowedSizeUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public IProductCategoryAllowedSizeDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<ProductCategoryAllowedSizePageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<ProductCategoryAllowedSizePageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<ProductCategoryAllowedSizeGetAllCommandOutputDTO>))]
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
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(ProductCategoryAllowedSizeGetByIdCommandOutputDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(ProductCategoryAllowedSizeInsertCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.Product_Manage)]
        public IActionResult Post([FromBody]ProductCategoryAllowedSizeInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            if (appResult.IsSucceed)
            {
                var signalArgs = new SignalREventArgs(SignalREvents.DATA_CHANGED.Identifier, nameof(SignalREvents.DATA_CHANGED.ActionEnum.ADDED_ITEM), nameof(ProductCategoryAllowedColorType), appResult.Bag);
                this.SignalRHubContext.Clients.All.DataChanged(signalArgs);
            }
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(ProductCategoryAllowedSizeUpdateCommandOutputDTO))]
        [Authorization.Authorize(Policy = PermissionsEnum.Product_Modify, Roles = Constants.Strings.JwtClaims.Administrator)]
        public IActionResult Put([FromBody]ProductCategoryAllowedSizeUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(ProductCategoryAllowedSizeDeleteCommandOutputDTO))]
        public IActionResult Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
    }
}

﻿using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand;
using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand.Models;
using ApplicationLogic.SignalR;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Authorization = Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiverdaleMainApp2_0.Auth;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Framework.SignalR;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/funzacategory")]
    public class FunzaCategoryController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunzaCategoryController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public FunzaCategoryController(IHubContext<GlobalHub, IGlobalHub> hubContext, IFunzaCategoryPageQueryCommand pageQueryCommand): base()
        {
            this.SignalRHubContext = hubContext;
            this.PageQueryCommand = pageQueryCommand;
        }


        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IFunzaCategoryPageQueryCommand PageQueryCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<FunzaCategoryPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<FunzaCategoryPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

    }
}

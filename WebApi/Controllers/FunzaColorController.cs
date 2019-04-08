using ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand;
using ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand.Models;
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
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/funzacolor")]
    public class FunzaColorController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunzaColorController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public FunzaColorController(IHubContext<GlobalHub, IGlobalHub> hubContext, IFunzaColorPageQueryCommand pageQueryCommand): base()
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
        public IFunzaColorPageQueryCommand PageQueryCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<FunzaColorPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<FunzaColorPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

    }
}

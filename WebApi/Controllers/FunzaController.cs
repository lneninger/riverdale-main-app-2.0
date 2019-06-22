using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Funza.PackingsUpdateCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand;
using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand;
using ApplicationLogic.SignalR;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.SignalR;
using FunzaInternalClients.Sync;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RiverdaleMainApp2_0.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authorization = Microsoft.AspNetCore.Authorization;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Product API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/funza")]
    public class FunzaController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="quoteGetItemsCommand"></param>
        /// <param name="syncCommand"></param>
        public FunzaController(IHubContext<GlobalHub, IGlobalHub> hubContext, IFunzaQuoteGetItemsCommand quoteGetItemsCommand, IFunzaSyncCommand syncCommand, IInternalSyncClient funzaSync) :base()
        {
            this.SignalRHubContext = hubContext;
            this.QuoteGetItemsCommand = quoteGetItemsCommand;
            this.SyncCommand = syncCommand;
            this.FunzaSync = funzaSync;



        }

        /// <summary>
        /// 
        /// </summary>
        public IFunzaQuoteGetItemsCommand QuoteGetItemsCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public IFunzaSyncCommand SyncCommand { get; }

        /// <summary>
        /// Gets the funza synchronize.
        /// </summary>
        /// <value>
        /// The funza synchronize.
        /// </value>
        public IInternalSyncClient FunzaSync { get; }

        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<FunzaAuthenticateCommandOutputDTO>))]
        [Route("sync")]
        public async Task<IActionResult> Sync()
        {
            try
            {
                var syncResult = await this.FunzaSync.Sync();
                //var syncResult = this.SyncCommand.Execute();

                return this.Ok(syncResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<FunzaQuoteGetItemsCommandOutputDTO>))]
        [Route("quoteitems")]
        public IActionResult GetQuoteItems([FromBody]PageQuery<FunzaQuoteGetItemsCommandInputDTO> input)
        {
            var syncResult = this.QuoteGetItemsCommand.Execute(input);

            return this.Ok(syncResult);
        }

    }
}

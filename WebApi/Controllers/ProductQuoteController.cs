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
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using System.Threading.Tasks;
using FunzaInternalClients.Quote;
using FunzaInternalClients.Quote.Models;
using ApplicationLogic.Business.Commands.Product.GetByIdCommand;
using ApplicationLogic.Business.Commands.Funza.GetByIdCommand.Models;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/productquote")]
    public class ProductQuoteController : BaseController
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
        public ProductQuoteController(IHubContext<GlobalHub, IGlobalHub> hubContext, IFunzaQuoteGetItemsCommand pageQueryCommand, IProductGetByIdCommand getByIdCommand, IInternalQuoteClient quoteClient) : base()
        {
            this.SignalRHubContext = hubContext;
            this.PageQueryCommand = pageQueryCommand;
            this.GetByIdCommand = getByIdCommand;
            
            this.QuoteClient = quoteClient;

        }


        /// <summary>
        /// 
        /// </summary>
        public IHubContext<GlobalHub, IGlobalHub> SignalRHubContext { get; }

        /// <summary>
        /// 
        /// </summary>
        public IFunzaQuoteGetItemsCommand PageQueryCommand { get; }

        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public IProductGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the quote client.
        /// </summary>
        /// <value>
        /// The quote client.
        /// </value>
        public IInternalQuoteClient QuoteClient { get; }

        /// <summary>
        /// Posts the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpPost("upsert/{id}")]
        public async Task<IActionResult> Post(int id)
        {
            var product = this.GetByIdCommand.Execute(id);

            var payload = new InternalBridgeCreateQuoteInput
            {
                ProductId = id,
                Title = $"Product {System.DateTime.UtcNow : yyyy-MM-ddhhmmss}"
            };

            var funzaResponse = (await this.QuoteClient.GetQuotes()).Content;
            
            return this.Ok(funzaResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[HttpPost, ProducesResponseType(200, Type = typeof(PageResult<FunzaQuotePageQueryCommandOutputDTO>))]
        //[Route("pagequery")]
        //public IActionResult PageQuery([FromBody]PageQuery<FunzaQuotePageQueryCommandInputDTO> input)
        //{
        //    var result = this.PageQueryCommand.Execute(input);

        //    return this.Ok(result);
        //}

    }
}

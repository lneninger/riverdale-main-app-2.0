using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunzaDirectClients.InternalClients.Quote;
using FunzaDirectClients.InternalClients.Security;
using FunzaDirectClients.InternalClients.Security.Models;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public ISecurityClient SecurityClient { get; }

        public SecurityController(ISecurityClient securityClient)
        {
            this.SecurityClient = securityClient;
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Login([FromBody]AuthenticationModel model)
        {
            var result = (await this.SecurityClient.Authenticate(model)).Content;
            return this.Ok(result);
        }

    }
}
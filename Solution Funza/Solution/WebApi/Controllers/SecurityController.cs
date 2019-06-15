using FunzaDirectClients.Clients.Security;
using FunzaDirectClients.Clients.Security.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
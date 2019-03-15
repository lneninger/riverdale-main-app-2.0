using Framework.Logging.Log4Net;
using Microsoft.AspNetCore.Mvc;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public LoggerCustom Logger = Framework.Logging.Log4Net.LoggerFactory.Create(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController(/*IHubContext<GlobalHub> hubContext*/): base()
        {
            //this.HubContext = hubContext;
        }

        //public IHubContext<GlobalHub> HubContext { get; }
    }
}
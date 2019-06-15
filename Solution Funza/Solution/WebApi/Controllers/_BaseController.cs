﻿using Framework.Logging.Log4Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.SignalR;

namespace WebApi.Controllers
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
        public BaseController(IHubContext<GlobalHub> hubContext = null) : base()
        {
            //this.HubContext = hubContext;
        }

        //public IHubContext<GlobalHub> HubContext { get; }
    }
}

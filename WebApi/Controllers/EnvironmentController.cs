using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApplicationLogic.Business.Commons;
using ApplicationLogic.Business.Commons.DTOs;
using RiverdaleMainApp2_0.Auth;
using Framework.Core.Messages;
using ApplicationLogic.SignalR;
using Microsoft.AspNetCore.SignalR;
using RiverdaleMainApp2_0.ViewModels;
using ApplicationLogic.AppSettings;
using Microsoft.Extensions.Configuration;
using Framework.Commons;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/environment")]
    public class EnvironmentController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentController"/> class.
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="funzaSettings"></param>
        /// <param name="appConfig"></param>
        public EnvironmentController(IHubContext<GlobalHub> hubContext, FunzaSettings funzaSettings, AppConfig appConfig) : base(hubContext)
        {
            this.AppConfig = appConfig;
            this.FunzaSettings = funzaSettings;
        }

        public AppConfig AppConfig { get; }

        /// <summary>
        /// 
        /// </summary>
        public FunzaSettings FunzaSettings { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(EnvironmentConfigDTO))]
        public IActionResult Get()
        {
            var result = new OperationResponse<EnvironmentConfigDTO>();
            result.Bag = new EnvironmentConfigDTO
            {
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                ConnectionString = this.AppConfig.Configuration.GetConnectionString("RiverdaleModel"),
                FunzaSettings = this.FunzaSettings
            };

            return this.Ok(result);
        }

    }
}

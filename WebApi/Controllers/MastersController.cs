using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunicationModel;
using FizzWare.NBuilder;
using ApplicationLogic.Business.Commands.Customer.GetAllCommand;
using ApplicationLogic.Business.Commands.Customer.GetByIdCommand;
using ApplicationLogic.Business.Commands.Customer.InsertCommand;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using ApplicationLogic.Business.Interfaces;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using ApplicationLogic.Business.Commons;
using ApplicationLogic.Business.Commons.DTOs;
using RiverdaleMainApp2_0.Auth;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/masters")]
    public class MastersController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MastersController"/> class.
        /// </summary>
        /// <param name="masterDataProvider"></param>
        public MastersController(IMasterDataProvider masterDataProvider)
        {
            this.MasterDataProvider = masterDataProvider;
        }

        /// <summary>
        /// Gets the customer service.
        /// </summary>
        /// <value>
        /// The customer service.
        /// </value>
        public IMasterDataProvider MasterDataProvider { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(List<EnumItemDTO<string>>))]
        [Route("thirdpartyapptype")]
        public IActionResult ThirdPartyAppType()
        {
            var result = this.MasterDataProvider.GetToEnumThirdPartyAppType();

            return this.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(List<EnumItemDTO<string>>))]
        [Route("productcolortype")]
        public IActionResult ProductColorType()
        {
            var result = this.MasterDataProvider.GetToEnumProductColorType();
            return this.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(List<EnumItemDTO<string>>))]
        [Route("customerfreightoutratetype")]
        public IActionResult CustomerFreightoutRateType()
        {
            var result = this.MasterDataProvider.GetToEnumCustomerFreightoutRateType();
            return this.Ok(result);
        }

        /// <summary>
        /// Customers this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(List<EnumItemDTO<string>>))]
        [Route("customer")]
        public IActionResult Customer()
        {
            var result = this.MasterDataProvider.GetToEnumCustomer();
            return this.Ok(result);
        }

        /// <summary>
        /// Users this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(List<EnumItemDTO<string>>))]
        [Route("user")]
        public IActionResult GetToEnumAppUser()
        {
            var result = this.MasterDataProvider.GetToEnumAppUser();
            return this.Ok(result);
        }


        [HttpGet, ProducesResponseType(200, Type = typeof(List<EnumItemDTO<string>>))]
        [Route("permission")]
        public IActionResult GetToEnumPermissions()
        {
            var @enumNames = Enum.GetNames(typeof(PermissionsEnum.Enum));
            var result = @enumNames.Select(enumName => new EnumItemDTO<string> { Key = enumName, Value = enumName });
            return this.Ok(result);
        }
    }
}

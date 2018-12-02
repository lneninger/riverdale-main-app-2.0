using ApplicationLogic.Business.Commands.AppUser.RegisterCommand;
using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand;
using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.Customer.GetAllCommand;
using ApplicationLogic.Business.Commands.Customer.GetByIdCommand;
using ApplicationLogic.Business.Commands.Customer.InsertCommand;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand;
using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand;
using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using CommunicationModel;
using DomainDatabaseMapping;
using DomainModel.Identity;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Microsoft.AspNetCore.Identity;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using RiverdaleMainApp2_0.Auth.Helpers;
using RiverdaleMainApp2_0.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IdentityDBContext IdentityDBContext;

        /// <summary>
        /// 
        /// </summary>
        private readonly UserManager<AppUser> UserManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUserRegisterCommand"></param>
        public AccountsController(IAppUserRegisterCommand appUserRegisterCommand)
        {
            this.AppUserRegisterCommand = appUserRegisterCommand;
        }

        /// <summary>
        /// 
        /// </summary>
        public IAppUserRegisterCommand AppUserRegisterCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var userIdentity = new AppUser {
            //    Email = model.Email,
            //    UserName = model.UserName,
            //    Password = model.Password,
            //    PictureUrl = model.PictureUrl


            //};

            var input = new AppUserRegisterCommandInputDTO
            {
                Email = model.Email,
                UserName = model.UserName,
                Password = model.Password,
                PictureUrl = model.PictureUrl
            };

            var result = this.AppUserRegisterCommand.Execute(input);

            //var result = await UserManager.CreateAsync(userIdentity, model.Password);

            //if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            //await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            //await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}

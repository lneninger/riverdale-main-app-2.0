using ApplicationLogic.Business.Commands.AppUser.AuthenticateCommand;
using ApplicationLogic.Business.Commands.AppUser.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RiverdaleMainApp2_0.Auth;
using RiverdaleMainApp2_0.Auth.Helpers;
using RiverdaleMainApp2_0.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        /// <param name="userManager"></param>
        /// <param name="jwtFactory"></param>
        /// <param name="jwtOptions"></param>
        /// <param name="appUserGetByIdCommand"></param>
        ///// <param name="appUserRegisterCommand"></param>
        ///// <param name="appUserAuthenticateCommand"></param>
        ///// <param name="appUserGetByIdCommand"></param>
        public AccountsController(UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions/*, IAppUserRegisterCommand appUserRegisterCommand, IAppUserAuthenticateCommand appUserAuthenticateCommand*/, IAppUserGetByIdCommand appUserGetByIdCommand)
        {
            this.UserManager = userManager;
            this.JwtFactory = jwtFactory;
            this.JwtOptions = jwtOptions.Value;
            //this.AppUserRegisterCommand = appUserRegisterCommand;
            //this.AppUserAuthenticateCommand = appUserAuthenticateCommand;
            this.AppUserGetByIdCommand = appUserGetByIdCommand;
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>
        /// The user manager.
        /// </value>
        public UserManager<AppUser> UserManager { get; }

        /// <summary>
        /// The JWT factory
        /// </summary>
        public IJwtFactory JwtFactory;

        /// <summary>
        /// The JWT options
        /// </summary>
        public JwtIssuerOptions JwtOptions;


        ///// <summary>
        ///// 
        ///// </summary>
        //public IAppUserRegisterCommand AppUserRegisterCommand { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public IAppUserAuthenticateCommand AppUserAuthenticateCommand { get; }

        /// <summary>
        /// Gets the application user get by identifier command.
        /// </summary>
        /// <value>
        /// The application user get by identifier command.
        /// </value>
        public IAppUserGetByIdCommand AppUserGetByIdCommand { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[HttpPost("register")]
        //public IActionResult Post([FromBody]AppUserRegisterCommandInputDTO input)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = this.AppUserRegisterCommand.Execute(input);

        //    return new OkObjectResult("Account created");
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAlt([FromBody]AppUserAuthenticateCommandInputDTO input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(input.UserName, input.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            var id = identity.Claims.Single(c => c.Type == "id").Value;

            var appResult = this.AppUserGetByIdCommand.Execute(id);
            /*
            var appResult = this.AppUserAuthenticateCommand.Execute(input);

            if (appResult == null || appResult.Bag == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Startup.SecretKey);
            var expiresAt = DateTime.UtcNow.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, appResult.Bag.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            */
            var user = appResult;//.Bag;
            // return basic user info (without password) and token to store client side

            return Ok(new
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = await this.JwtFactory.GenerateEncodedToken(input.UserName, identity),//identity.tokenString,
                PictureUrl = user.PictureUrl,
                ExpiresAt = this.JwtOptions.Expiration,//expiresAt,
                ExpiresIn = this.JwtOptions.ValidFor.TotalSeconds//expiresAt,
            });
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody]AppUserAuthenticateCommandInputDTO input)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var appResult = this.AppUserAuthenticateCommand.Execute(input);

        //    if (appResult == null || appResult.Bag == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Startup.SecretKey);
        //    var expiresAt = DateTime.UtcNow.AddDays(7);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(JwtRegisteredClaimNames.NameId, appResult.Bag.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);
        //    var user = appResult.Bag;
        //    // return basic user info (without password) and token to store client side
        //    return Ok(new
        //    {
        //        UserName = user.UserName,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        AccessToken = tokenString,
        //        PictureUrl = user.PictureUrl,
        //        ExpiresAt = expiresAt,
        //    });
        //}

        /// <summary>
        /// Get Authentication info
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("authenticationInfo")]
        public async Task<IActionResult> AuthenticationInfoAlt()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var claimsIdentity = User.Identity as ClaimsIdentity;

            // alternatively
            // claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            // get some claim by type
            var id = claimsIdentity.Name;//.FindFirst("some-claim");
            var appResult = this.AppUserGetByIdCommand.Execute(id);
            var user = appResult;
            var newClaimsIdentity = await Task.FromResult(this.JwtFactory.GenerateClaimsIdentity(appResult.UserName, id));

            return Ok(new
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AccessToken = await this.JwtFactory.GenerateEncodedToken(user.UserName, newClaimsIdentity),//identity.tokenString,
                PictureUrl = user.PictureUrl,
                ExpiresAt = this.JwtOptions.Expiration,//expiresAt,
                ExpiresIn = this.JwtOptions.ValidFor.TotalSeconds//expiresAt,
            });
        }

        /// <summary>
        /// Get Authentication info
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("authenticationInfo/{token}")]
        public IActionResult AuthenticationInfo(string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Startup.SecretKey);
            var expiresAt = DateTime.UtcNow.AddDays(7);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            if (tokenHandler.CanReadToken(token))
            {
                var tokenSecure = tokenHandler.ReadToken(token);
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var validatedToken = tokenHandler.ValidateToken(token, validations, out tokenSecure);
                var id = validatedToken.Identity.Name;

                if (id != null)
                {
                    var appResult = this.AppUserGetByIdCommand.Execute(id);

                    return Ok(new
                    {
                        UserName = appResult.UserName,
                        FirstName = appResult.FirstName,
                        LastName = appResult.LastName,
                        AccessToken = token,
                        PictureUrl = appResult.PictureUrl,
                        ExpiresAt = tokenSecure.ValidTo,
                    });
                }



                return null;
                //securityToken.
            }

            return null;


            //var appResult = this.AppUserAuthenticateCommand.Execute(input);

            //if (appResult == null || appResult.Bag == null)
            //    return BadRequest(new { message = "Username or password is incorrect" });

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(Startup.SecretKey);
            //var expiresAt = DateTime.UtcNow.AddDays(7);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, appResult.Bag.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);
            //var user = appResult.Bag;
            //// return basic user info (without password) and token to store client side
            //return Ok(new
            //{
            //    UserName = user.UserName,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    AccessToken = tokenString,
            //    PictureUrl = user.PictureUrl,
            //    ExpiresAt = expiresAt,
            //});
        }

        [NonAction]
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                // get the user to verifty
                var userToVerify = await this.UserManager.FindByNameAsync(userName);

                if (userToVerify != null)
                {
                    // check the credentials  
                    if (await this.UserManager.CheckPasswordAsync(userToVerify, password))
                    {
                        return await Task.FromResult(this.JwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
                    }
                }
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}

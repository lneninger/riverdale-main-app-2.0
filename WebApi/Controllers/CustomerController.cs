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
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
//using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RiverdaleMainApp2_0.Controllers
{
    /// <summary>
    /// Customer API interface
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="pageQueryCommand">The page query command</param>
        /// <param name="getAllCommand">The get all command.</param>
        /// <param name="getByIdCommand">The get by identifier command.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        public CustomerController(ICustomerPageQueryCommand pageQueryCommand, ICustomerGetAllCommand getAllCommand, ICustomerGetByIdCommand getByIdCommand, ICustomerInsertCommand insertCommand, ICustomerUpdateCommand updateCommand, ICustomerDeleteCommand deleteCommand)
        {
            this.PageQueryCommand = pageQueryCommand;
            this.GetAllCommand = getAllCommand;
            this.GetByIdCommand = getByIdCommand;
            this.InsertCommand = insertCommand;
            this.UpdateCommand = updateCommand;
            this.DeleteCommand = deleteCommand;
        }

        /// <summary>
        /// Gets the get all command.
        /// </summary>
        /// <value>
        /// The get all command.
        /// </value>
        public ICustomerGetAllCommand GetAllCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public ICustomerPageQueryCommand PageQueryCommand { get; }


        /// <summary>
        /// Gets the get by identifier command.
        /// </summary>
        /// <value>
        /// The get by identifier command.
        /// </value>
        public ICustomerGetByIdCommand GetByIdCommand { get; }

        /// <summary>
        /// Gets the insert command.
        /// </summary>
        /// <value>
        /// The insert command.
        /// </value>
        public ICustomerInsertCommand InsertCommand { get; }

        /// <summary>
        /// Gets the update command.
        /// </summary>
        /// <value>
        /// The update command.
        /// </value>
        public ICustomerUpdateCommand UpdateCommand { get; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public ICustomerDeleteCommand DeleteCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(PageResult<CustomerPageQueryCommandOutputDTO>))]
        [Route("pagequery")]
        public IActionResult PageQuery([FromBody]PageQuery<CustomerPageQueryCommandInputDTO> input)
        {
            var result = this.PageQueryCommand.Execute(input);

            return this.Ok(result);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet(""), ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDTO>))]
        public IActionResult Get()
        {
            var applicationResponse = this.GetAllCommand.Execute();

            var result = applicationResponse?.Bag.Select(appItem => new CustomerDTO {
                Name = appItem.Name,
                //ERPId = appItem.ERPId,
            });

            return this.Ok(result);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(200, Type = typeof(CustomerDTO))]
        public IActionResult Get(int id)
        {
            var result = this.GetByIdCommand.Execute(id);

            return this.Ok(result);
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(CustomerInsertCommandOutputDTO))]
        public IActionResult Post([FromBody]CustomerInsertCommandInputDTO model)
        {
            var appResult = this.InsertCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(CustomerUpdateCommandOutputDTO))]
        public IActionResult Put([FromBody]CustomerUpdateCommandInputDTO model)
        {
            var appResult = this.UpdateCommand.Execute(model);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(CustomerDeleteCommandOutputDTO))]
        public IActionResult Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);
            return appResult.IsSucceed ? (IActionResult)this.Ok(appResult) : (IActionResult)this.BadRequest(appResult);
        }
        
    }
}

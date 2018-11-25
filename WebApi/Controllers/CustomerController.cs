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
        [HttpGet("", Name = "GetAllCustomer"), ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDTO>))]
        public IActionResult Get()
        {
            var applicationResponse = this.GetAllCommand.Execute();
            var result = applicationResponse.Select(appItem => new CustomerDTO {
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
        [HttpGet("{id}", Name = "GetCustomerById"), ProducesResponseType(200, Type = typeof(CustomerDTO))]
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
        [HttpPost, ProducesResponseType(200, Type = typeof(CustomerDTO))]
        public IActionResult Post([FromBody]CustomerDTO model)
        {
            var input = new CustomerInsertCommandInputDTO
            {
                Name = model.Name,
                //ERPId = model.ERPId
            };

            var appResult = this.InsertCommand.Execute(input);
            var result = new CustomerDTO
            {
                Id = appResult.Id,
                Name = appResult.Name,
                //ERPId = appResult.ERPId
            };

            return this.Ok(result);
        }

        /// <summary>
        /// Puts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        [HttpPut(), ProducesResponseType(200, Type = typeof(CustomerDTO))]
        public void Put([FromBody]CustomerDTO model)
        {
            var input = new CustomerUpdateCommandInputDTO
            {

            };

            this.UpdateCommand.Execute(input);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}"), ProducesResponseType(200, Type = typeof(CustomerDTO))]
        public CustomerDTO Delete(int id)
        {
            var appResult = this.DeleteCommand.Execute(id);

            var result = new CustomerDTO
            {

            };

            return result;
        }
    }
}

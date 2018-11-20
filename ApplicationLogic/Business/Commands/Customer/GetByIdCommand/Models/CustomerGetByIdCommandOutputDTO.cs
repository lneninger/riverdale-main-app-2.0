using System;

namespace FocusServices.Business.Commands.Customer.GetByIdCommand.Models
{
    public class CustomerGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
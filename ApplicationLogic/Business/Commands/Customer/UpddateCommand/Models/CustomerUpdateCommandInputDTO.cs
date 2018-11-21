using System;

namespace ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models
{
    public class CustomerUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
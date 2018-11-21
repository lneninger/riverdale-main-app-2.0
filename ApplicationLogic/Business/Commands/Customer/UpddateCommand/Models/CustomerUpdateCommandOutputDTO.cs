using System;

namespace ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models
{
    public class CustomerUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
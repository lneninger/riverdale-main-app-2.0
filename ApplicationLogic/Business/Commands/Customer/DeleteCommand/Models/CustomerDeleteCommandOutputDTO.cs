using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models
{
    public class CustomerDeleteCommandOutputDTO
    {

        public CustomerDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
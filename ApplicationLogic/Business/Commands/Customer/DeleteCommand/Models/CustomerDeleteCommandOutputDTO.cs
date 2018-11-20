using FocusApplication.Business.Commons.DTOs;
using System;
using System.Collections.Generic;

namespace FocusServices.Business.Commands.Customer.DeleteCommand.Models
{
    public class CustomerDeleteCommandOutputDTO
    {

        public CustomerDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
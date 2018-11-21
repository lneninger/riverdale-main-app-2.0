using FocusApplication.Business.Commons.DTOs;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand.Models
{
    public class CustomerInsertCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
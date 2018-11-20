using System;

namespace FocusServices.Business.Commands.Customer.GetAllCommand.Models
{
    public class CustomerGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
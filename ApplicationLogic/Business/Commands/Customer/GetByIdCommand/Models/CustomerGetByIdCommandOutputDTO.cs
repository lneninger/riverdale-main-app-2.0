using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models
{
    public class CustomerGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CustomerGetByIdCommandOutputThirdPartySettingsDTO> ThirdPartySettings { get; set; }
        public CustomerGetByIdCommandOutputFreightoutDTO Freightout { get; set; }
    }
}
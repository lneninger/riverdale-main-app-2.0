using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models
{
    public class CustomerGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyCustomerId { get; set; }
    }
}

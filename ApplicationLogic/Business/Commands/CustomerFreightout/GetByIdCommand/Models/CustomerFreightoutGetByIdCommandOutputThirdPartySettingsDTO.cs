using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models
{
    public class CustomerFreightoutGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyCustomerFreightoutId { get; set; }
    }
}

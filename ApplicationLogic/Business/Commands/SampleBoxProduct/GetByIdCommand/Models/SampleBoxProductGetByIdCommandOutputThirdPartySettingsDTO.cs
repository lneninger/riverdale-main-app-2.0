using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetByIdCommand.Models
{
    public class SampleBoxProductGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Commands.Funza.GetByIdCommand.Models
{
    public class ProductGetByIdCommandOutputThirdPartySettingsDTO
    {
        public int Id { get; set; }
        public string ThirdPartyAppTypeId { get; set; }
        public string ThirdPartyProductId { get; set; }
    }
}

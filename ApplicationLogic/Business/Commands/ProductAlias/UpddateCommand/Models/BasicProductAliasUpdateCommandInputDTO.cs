using System;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand.Models
{
    public class BasicProductAliasUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
using System;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand.Models
{
    public class BasicProductAliasUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
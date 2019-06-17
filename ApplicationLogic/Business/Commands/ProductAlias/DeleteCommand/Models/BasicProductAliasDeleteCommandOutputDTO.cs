using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand.Models
{
    public class BasicProductAliasDeleteCommandOutputDTO
    {

        public BasicProductAliasDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
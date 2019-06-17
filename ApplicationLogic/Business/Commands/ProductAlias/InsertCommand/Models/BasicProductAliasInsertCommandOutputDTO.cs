using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models
{
    public class BasicProductAliasInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
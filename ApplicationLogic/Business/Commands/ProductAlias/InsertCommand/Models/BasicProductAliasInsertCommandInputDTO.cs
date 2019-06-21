using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models
{
    public class BasicProductAliasInsertCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string ColorTypeId { get; set; }
        public int ProductCategorySizeId { get; set; }
    }
}
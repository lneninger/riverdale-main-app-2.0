using System;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand.Models
{
    public class BasicProductAliasPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int? ProductCategorySizeId { get; set; }
        public string ProductCategorySize { get; set; }

        public string ColorTypeId { get; set; }
        public string ColorTypeName { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class BasicProductAlias : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }
        public virtual AbstractProduct Product { get; set; }

        public string ColorTypeId { get; set; }
        public virtual ProductColorType ColorType { get; set; }

        public int? ProductCategorySizeId { get; set; }
        public virtual ProductCategoryAllowedSize ProductCategorySize { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

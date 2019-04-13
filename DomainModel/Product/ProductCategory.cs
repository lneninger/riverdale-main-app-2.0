using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class ProductCategory : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FlowerProduct> Flowers { get; set; }

        public virtual ICollection<ProductCategorySize> Sizes { get; set; }

        public virtual ICollection<ProductCategoryAllowedColorType> AllowedColorTypes { get; set; }


        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

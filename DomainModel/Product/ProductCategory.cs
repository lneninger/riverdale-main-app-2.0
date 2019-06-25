using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class ProductCategory : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public string Identifier { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AbstractProduct> Products { get; set; }

        public virtual ICollection<ProductCategoryAllowedSize> Sizes { get; set; }

        public virtual ICollection<ProductCategoryAllowedColorType> AllowedColorTypes { get; set; }


        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

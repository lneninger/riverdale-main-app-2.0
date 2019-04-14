using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class ProductCategoryAllowedColorType : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string ProductColorTypeId { get; set; }
        public virtual ProductColorType ProductColorType { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string TempId { get; set; }
    }
}

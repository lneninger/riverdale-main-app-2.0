using DomainModel._Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    /// <summary>
    /// 
    /// </summary>
    public class AbstractProduct : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        public ProductTypeEnum ProductTypeEnum { get {
                return (ProductTypeEnum)Enum.Parse(typeof(ProductTypeEnum), this.ProductTypeId);
            }
            set {
                this.ProductTypeId = value.ToString();
            }
        }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }

        //Collections

        public virtual IEnumerable<ProductMedia> ProductMedias { get; set; }


        public string ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public IEnumerable<ProductCategoryAllowedColorType> ProductCategoryAllowedColorTypes { get; set; }
    }
}

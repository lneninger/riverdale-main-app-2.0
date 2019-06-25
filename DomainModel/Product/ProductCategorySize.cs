using Framework.EF.DbContextImpl.Persistance;
using System;

namespace DomainModel.Product
{
    public class ProductCategoryAllowedSize : AbstractBaseEntity, ILogicalDeleteEntity
    {

        public ProductCategoryAllowedSize(): base()
        {
        }

        public int Id { get; set; }

        public string Size { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }


        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
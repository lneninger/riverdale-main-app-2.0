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

        public virtual IEnumerable<ProductMedia> ProductMedias { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

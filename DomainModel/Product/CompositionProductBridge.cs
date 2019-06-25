using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class CompositionProductBridge: AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public int CompositionProductId { get; set; }

        public virtual CompositionProduct CompositionProduct { get; set; }

        public string ColorTypeId { get; set; }
        public virtual ProductColorType ColorType { get; set; }

        public int CompositionItemId { get; set; }
        public virtual AbstractProduct CompositionItem { get; set; }

        public int CompositionItemAmount { get; set; }

        public int? ProductCategorySizeId { get; set; }
        public virtual ProductCategoryAllowedSize ProductCategorySize { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class ProductQuote: AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string ExternalId { get; set; }

        public int ProductId { get; set; }
        public virtual AbstractProduct Product { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

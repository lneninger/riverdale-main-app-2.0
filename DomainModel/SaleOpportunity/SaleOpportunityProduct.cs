using DomainModel.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SaleOpportunityProduct : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }
        public virtual SaleOpportunity SaleOpportunity { get; set; }

        public int ProductId { get; set; }
        public virtual AbstractProduct Product { get; set; }

        public int ProductAmount { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

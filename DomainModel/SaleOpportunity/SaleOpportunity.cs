using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SaleOpportunity : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SaleSeasonTypeId { get; set; }
        public SaleSeasonType SaleSeasonType { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual IEnumerable<SaleOpportunityProduct> SaleOpportunityProducts { get; set; }
    }
}

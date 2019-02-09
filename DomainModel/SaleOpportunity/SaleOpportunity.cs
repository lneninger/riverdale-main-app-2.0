using DomainModel.Company.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SaleOpportunity : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? TargetPrice { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int SaleSeasonTypeId { get; set; }
        public virtual SaleSeasonType SaleSeasonType { get; set; }

        public virtual SaleOpportunitySettings SaleOpportunitySettings { get; set; }

        public virtual ICollection<SampleBox> SampleBoxes { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }

    }
}

using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SampleBox : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public int SaleOpportunityTargetPriceId { get; set; }
        public virtual SaleOpportunityTargetPrice SaleOpportunityTargetPrice { get; set; }

        public virtual ICollection<SampleBoxProduct> SampleBoxProducts { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

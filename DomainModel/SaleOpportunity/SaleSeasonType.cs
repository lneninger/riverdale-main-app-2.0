using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SaleSeasonType : AbstractBaseEntity
    {
        public int Id { get; set; }

        public string SaleSeasonCategoryTypeId { get; set; }

        public virtual SaleSeasonCategoryType SaleSeasonCategoryType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<SaleOpportunity> SaleOpportunities { get; set; }
    }
}

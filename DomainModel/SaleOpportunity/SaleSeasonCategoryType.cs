using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SaleSeasonCategoryType : AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public IEnumerable<SaleSeasonType> SaleSeasons { get; set; }
        public virtual IEnumerable<SaleSeasonType> SaleSeasons { get; set; }
    }
}

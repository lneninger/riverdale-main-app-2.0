using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Company.Customer
{
    public class CustomerSettings : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public bool DefaultIsWet { get; set; }

        public bool DefaultIsDeliver { get; set; }

        public bool? DefaultOther { get; set; }

        public decimal? DefaultRebate { get; set; }

        public decimal? DefaultDuty { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

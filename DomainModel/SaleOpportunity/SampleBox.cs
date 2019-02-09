﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.SaleOpportunity
{
    public class SampleBox : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public int SaleOpportunityId { get; set; }
        public virtual SaleOpportunity SaleOpportunity { get; set; }

        public virtual ICollection<SampleBoxProduct> SampleBoxProducts { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

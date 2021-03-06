﻿using System;
using System.Collections.Generic;
using DomainModel.Product;
using Framework.EF.DbContextImpl.Persistance;

namespace DomainModel.SaleOpportunity
{
    public class SampleBoxProduct : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }

        public int SaleOpportunityTargetPriceProductId { get; set; }
        public virtual SaleOpportunityTargetPriceProduct SaleOpportunityTargetPriceProduct { get; set; }

        public int SampleBoxId { get; set; }
        public virtual SampleBox SampleBox { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

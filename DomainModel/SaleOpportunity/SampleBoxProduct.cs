﻿using System;
using System.Collections.Generic;
using DomainModel.Product;

namespace DomainModel.SaleOpportunity
{
    public class SampleBoxProduct : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }

        public int ProductAmount { get; set; }

        public int ProductId { get; set; }
        public virtual AbstractProduct Product { get; set; }

        public int SampleBoxId { get; set; }
        public virtual SampleBox SampleBox { get; set; }

        public int? ProductAllowedColorTypeId { get; set; }
        public virtual ProductAllowedColorType ProductAllowedColorType { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
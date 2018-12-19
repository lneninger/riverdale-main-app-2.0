﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class CompositionProductBridge: AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public int CompositionProductId { get; set; }

        public virtual CompositionProduct CompositionProduct { get; set; }


        public int CompositionItemId { get; set; }

        public virtual AbstractProduct CompositionItem { get; set; }


        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}

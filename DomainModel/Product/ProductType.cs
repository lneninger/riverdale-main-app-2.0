﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class ProductType : AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<AbstractProduct> Products { get; set; }
    }
}

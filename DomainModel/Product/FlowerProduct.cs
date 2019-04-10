using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class FlowerProduct : AbstractProduct
    {
        public string FlowerProductCategoryId { get; set; }
        public virtual FlowerProductCategory FlowerProductCategory { get; set; }
    }
}

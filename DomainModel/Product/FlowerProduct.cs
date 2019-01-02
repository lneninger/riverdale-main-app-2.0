using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class FlowerProduct : AbstractProduct
    {
        public string ProductColorTypeId { get; set; }
        public virtual ProductColorType ProductColorType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class CompositionProduct: AbstractProduct
    {
        public string ProductColorTypeId { get; set; }
        public virtual ProductColorType ProductColorType { get; set; }

        public virtual IEnumerable<CompositionProductBridge> Items { get; set; }
    }
}

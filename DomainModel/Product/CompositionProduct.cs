using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Product
{
    public class CompositionProduct: AbstractProduct
    {

        public IEnumerable<CompositionProductBridge> Items { get; set; }
    }
}

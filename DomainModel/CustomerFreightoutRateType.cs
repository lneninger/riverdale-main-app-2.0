using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class CustomerFreightoutRateType: AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

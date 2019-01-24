using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Company.Customer
{
    public class CustomerFreightoutRateType: AbstractBaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<CustomerFreightout> CustomerFreightouts { get; set; }
    }
}

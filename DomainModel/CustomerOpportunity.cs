using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class CustomerOpportunity: AbstractBaseEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}

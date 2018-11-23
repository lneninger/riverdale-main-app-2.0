using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Customer : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public Customer()
        {
            this.CustomerOpportunities = new List<CustomerOpportunity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CustomerOpportunity> CustomerOpportunities { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
        public IEnumerable<CustomerThirdPartyAppSetting> CustomerThirdPartyAppSettings { get; set; }
    }
}

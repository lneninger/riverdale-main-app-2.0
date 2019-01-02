using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.SaleOpportunity;

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

        public virtual IEnumerable<CustomerOpportunity> CustomerOpportunities { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual IEnumerable<CustomerThirdPartyAppSetting> CustomerThirdPartyAppSettings { get; set; }

        public virtual IEnumerable<CustomerFreightout> CustomerFreightouts { get; set; }

        public virtual IEnumerable<SaleOpportunity.SaleOpportunity> SaleOpportunities { get; set; }
    }
}

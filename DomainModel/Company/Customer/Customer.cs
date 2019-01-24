using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.SaleOpportunity;

namespace DomainModel.Company.Customer
{
    public class Customer : AbstractCompany
    {
        public Customer()
        {
            this.CustomerOpportunities = new List<CustomerOpportunity>();
        }

        public virtual IEnumerable<CustomerOpportunity> CustomerOpportunities { get; set; }

        public virtual IEnumerable<CustomerThirdPartyAppSetting> CustomerThirdPartyAppSettings { get; set; }

        public virtual IEnumerable<CustomerFreightout> CustomerFreightouts { get; set; }

        public virtual IEnumerable<SaleOpportunity.SaleOpportunity> SaleOpportunities { get; set; }
    }
}

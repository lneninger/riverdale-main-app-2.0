using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class CustomerThirdPartyAppSetting: AbstractBaseEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string ThridPartyAppTypeId { get; set; }
        public ThirdPartyAppType ThirdPartyAppType { get; set; }

        public string ThirdPartyCustomerId { get; set; }
    }
}

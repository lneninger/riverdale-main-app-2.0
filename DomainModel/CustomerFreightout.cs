using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class CustomerFreightout
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public string CustomerFreightoutRateTypeId { get; set; }
        public CustomerFreightoutRateType CustomerFreightoutRateType { get; set; }

        public decimal Cost { get; set; }

        public decimal WProtect { get; set; }

        public decimal SecondLeg { get; set; }

        public decimal? SurchargeHourly { get; set; }

        public decimal? SurchargeYearly { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}

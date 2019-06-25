using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Company.Customer
{
    public class CustomerFreightout : AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public string CustomerFreightoutRateTypeId { get; set; }

        public virtual CustomerFreightoutRateType CustomerFreightoutRateType { get; set; }

        public decimal Cost { get; set; }

        public decimal WProtect { get; set; }

        public decimal SecondLeg { get; set; }

        public decimal? SurchargeHourly { get; set; }

        public decimal? SurchargeYearly { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }

        //public static implicit operator CustomerFreightout(CustomerFreightout v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

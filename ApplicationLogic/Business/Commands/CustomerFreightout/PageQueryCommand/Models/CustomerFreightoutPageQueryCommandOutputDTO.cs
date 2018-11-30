using System;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models
{
    public class CustomerFreightoutPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal SecondLeg { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal? SurchargeHourly { get; set; }
        public decimal? SurchargeYearly { get; set; }
        public decimal WProtect { get; set; }
        public string CustomerFreightoutRateTypeId { get; set; }
        public decimal Cost { get; set; }
    }
}
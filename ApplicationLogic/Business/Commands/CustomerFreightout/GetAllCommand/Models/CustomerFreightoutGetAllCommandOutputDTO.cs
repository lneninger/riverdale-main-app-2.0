using System;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models
{
    public class CustomerFreightoutGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal Cost { get; set; }
        public decimal? SurchargeHourly { get; set; }
        public string CustomerFreightoutRateTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal SecondLeg { get; set; }
        public decimal? SurchargeYearly { get; set; }
        public decimal WProtect { get; set; }
    }
}
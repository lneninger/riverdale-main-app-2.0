using System;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models
{
    public class CustomerFreightoutUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public DateTime DateFrom { get; set; }
        public string CustomerFreightoutRateTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTo { get; set; }
        public decimal SecondLeg { get; set; }
        public decimal? SurchargeHourly { get; set; }
        public decimal? SurchargeYearly { get; set; }
        public decimal WProtect { get; set; }
        public decimal Cost { get; set; }
    }
}
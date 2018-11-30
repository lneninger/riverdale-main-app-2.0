using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models
{
    public class CustomerFreightoutGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Cost { get; set; }
        public string CustomerFreightoutRateTypeId { get; set; }
        public decimal? SurchargeHourly { get; set; }
        public DateTime DateTo { get; set; }
        public decimal SecondLeg { get; set; }
        public decimal? SurchargeYearly { get; set; }
        public decimal WProtect { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
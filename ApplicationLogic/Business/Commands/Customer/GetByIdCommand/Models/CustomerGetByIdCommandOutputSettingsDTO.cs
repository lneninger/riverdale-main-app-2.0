using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models
{
    public class CustomerGetByIdCommandOutputSettingsDTO
    {
        public int Id { get; set; }

        public decimal? DefaultDuty { get; set; }

        public bool DefaultIsDeliver { get; set; }

        public bool DefaultIsWet { get; set; }

        public bool? DefaultOther { get; set; }

        public decimal? DefaultRebate { get; set; }
    }
}
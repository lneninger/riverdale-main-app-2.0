﻿using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.QuotesUpdateCommand.Models
{
    public class FunzaQuotesUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
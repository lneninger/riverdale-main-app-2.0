﻿using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand.Models
{
    public class FunzaQuotePageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
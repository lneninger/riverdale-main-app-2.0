﻿using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand.Models
{
    public class CustomerInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
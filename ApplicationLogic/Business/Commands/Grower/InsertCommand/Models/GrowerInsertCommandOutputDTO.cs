﻿using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.InsertCommand.Models
{
    public class GrowerInsertCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
﻿using System;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand.Models
{
    public class BasicProductAliasGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
﻿using System;

namespace ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models
{
    public class ProductPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public string SalesforceId { get; set; }
        public DateTime? CreatedAt { get; set; }
       
    }
}
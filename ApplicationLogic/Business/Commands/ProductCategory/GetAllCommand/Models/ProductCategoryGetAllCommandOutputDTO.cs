﻿using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetAllCommand.Models
{
    public class ProductCategoryGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }

        public FileItemRefOutputDTO MainPicture { get; set; }
    }
}
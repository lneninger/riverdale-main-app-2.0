﻿using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.GetAllCommand.Models
{
    public class SampleBoxProductGetAllCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmount { get; set; }

        public DateTime? CreatedAt { get; set; }

        public FileItemRefOutputDTO MainPicture { get; set; }
    }
}
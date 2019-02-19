using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand.Models
{
    public class SaleOpportunityPriceLevelProductGetAllCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int RelatedProductId { get; set; }

        public int ProductAmount { get; set; }

        public DateTime? CreatedAt { get; set; }

        public FileItemRefOutputDTO MainPicture { get; set; }
    }
}
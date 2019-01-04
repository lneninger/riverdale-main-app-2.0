using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.PageQueryCommand.Models
{
    public class SaleOpportunityPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SaleSeasonTypeId { get; set; }
        public string SaleSeasonTypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
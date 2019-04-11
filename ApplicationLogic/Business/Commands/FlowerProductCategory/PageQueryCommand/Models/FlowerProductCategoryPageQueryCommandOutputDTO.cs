using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.PageQueryCommand.Models
{
    public class FlowerProductCategoryPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public string SalesforceId { get; set; }
        public DateTime? CreatedAt { get; set; }
       
        public FileItemRefOutputDTO MainPicture { get; set; }

        public string FlowerFlowerProductCategoryCategoryName { get; set; }
    }
}
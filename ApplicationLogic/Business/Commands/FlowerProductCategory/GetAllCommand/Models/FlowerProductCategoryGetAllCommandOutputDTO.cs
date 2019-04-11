using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand.Models
{
    public class FlowerProductCategoryGetAllCommandOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }

        public FileItemRefOutputDTO MainPicture { get; set; }
    }
}
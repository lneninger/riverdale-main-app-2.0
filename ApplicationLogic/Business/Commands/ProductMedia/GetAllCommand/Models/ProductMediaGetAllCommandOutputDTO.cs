using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand.Models
{
    public class ProductMediaGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public FileItemRefOutputDTO MainPicture { get; set; }
    }
}
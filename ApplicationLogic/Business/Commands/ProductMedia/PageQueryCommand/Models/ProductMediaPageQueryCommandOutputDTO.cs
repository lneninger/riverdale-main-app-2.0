using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.ProductMedia.PageQueryCommand.Models
{
    public class ProductMediaPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public string SalesforceId { get; set; }
        public DateTime? CreatedAt { get; set; }
       
        public FileItemRefOutputDTO MainPicture { get; set; }

    }
}
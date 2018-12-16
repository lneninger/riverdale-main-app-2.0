using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commands.ProductMedia.Commons;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand.Models
{
    public class ProductMediaGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
        public string ProductMediaTypeId { get; set; }
        public ProductMediaTypeEnum? ProductMediaTypeEnum
        {
            get
            {
                object temp;
                Enum.TryParse(typeof(ProductMediaTypeEnum), ProductMediaTypeId, out temp);
                return temp != null ? (ProductMediaTypeEnum?)temp : null;
            }
            set
            {
                this.ProductMediaTypeId = value == null ? null : value.ToString();
            }
        }
    }
}
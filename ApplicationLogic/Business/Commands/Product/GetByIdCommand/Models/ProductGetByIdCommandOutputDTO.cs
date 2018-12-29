using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commands.Product.Commons;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models
{
    public class ProductGetByIdCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FileItemRefOutputDTO> Medias { get; set; }
        public string ProductTypeId { get; set; }
        public ProductTypeEnum? ProductTypeEnum
        {
            get
            {
                object temp;
                Enum.TryParse(typeof(ProductTypeEnum), ProductTypeId, out temp);
                return temp != null ? (ProductTypeEnum?)temp : null;
            }
            set
            {
                this.ProductTypeId = value == null ? null : value.ToString();
            }
        }

        public IEnumerable<ProductGetByIdCommandOutputRelatedProductItemDTO> RelatedProducts { get; set; }
    }
}
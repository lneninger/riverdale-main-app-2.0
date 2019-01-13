using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand.Models
{
    public class ProductAllowedColorTypeGetByIdCommandOutputRelatedProductAllowedColorTypeItemDTO
    {
        public int Id { get; set; }

        public int ProductAllowedColorTypeId { get; set; }

        public int RelatedProductAllowedColorTypeId { get; set; }

        public int Stems { get; set; }

        public string RelatedProductAllowedColorTypeName { get; set; }

        public string RelatedProductAllowedColorTypeTypeName { get; set; }

        public string RelatedProductAllowedColorTypeTypeDescription { get; set; }

        public int RelatedProductAllowedColorTypePictureId { get; set; }
    }
}

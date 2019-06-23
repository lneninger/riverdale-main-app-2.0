using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand.Models
{
    public class FunzaGetProductsCommandOutput
    {
        public int ProductId { get; set; }

        public int SpecieId { get; set; }

        public int VarietyId { get; set; }

        public int GradeId { get; set; }

        public int ColorId { get; set; }

        public string Code { get; set; }

        public bool Active { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public int CategoryId { get; set; }

        public int ProductTypeId { get; set; }

        public int ReferenceId { get; set; }

        public int ReferenceTypeId { get; set; }

        public string ReferenceTypeName { get; set; }

        public string ReferenceCode { get; set; }

        public string ReferenceDescription { get; set; }

        public string ProductTypeName { get; set; }

        public string Category { get; set; }

        public bool SendToQuotator { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
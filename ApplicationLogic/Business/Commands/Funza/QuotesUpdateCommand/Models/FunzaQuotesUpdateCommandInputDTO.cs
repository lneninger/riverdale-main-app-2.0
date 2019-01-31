using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.QuotesUpdateCommand.Models
{
    public class FunzaQuotesUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public int SpecieId { get; set; }
        public int VarieryId { get; set; }
        public int GradeId { get; set; }
        public int ColorId { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int QuoteTypeId { get; set; }
        public string QuoteTypeName { get; set; }

        public int ReferenceId { get; set; }
        public string ReferenceCode { get; set; }
        public string ReferenceDescription { get; set; }

        public int ReferenceTypeId { get; set; }
        public string ReferenceTypeName { get; set; }
       
        public bool SendQuotator { get; set; }
        public DateTime FunzaUpdatedDate { get; set; }
    }
}
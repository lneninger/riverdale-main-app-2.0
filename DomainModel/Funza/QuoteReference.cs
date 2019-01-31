using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Funza
{
    public class QuoteReference : AbstractBaseEntity
    {
        public int Id { get; set; }
        public int FunzaId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int State { get; set; }

        public string AdjustmentRequestUserId { get; set; }

        public int StepCreation { get; set; }

         
    }
}

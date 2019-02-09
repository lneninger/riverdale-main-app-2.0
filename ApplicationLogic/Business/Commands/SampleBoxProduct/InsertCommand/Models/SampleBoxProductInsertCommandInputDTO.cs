using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.InsertCommand.Models
{
    public class SampleBoxProductInsertCommandInputDTO
    {
        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }
    }
}
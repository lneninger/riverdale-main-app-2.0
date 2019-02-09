using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models
{
    public class SampleBoxUpdateCommandInputDTO
    {
        public int Id { get; set; }

        //public int SaleOpportunityId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductColorTypeId { get; set; }
    }
}
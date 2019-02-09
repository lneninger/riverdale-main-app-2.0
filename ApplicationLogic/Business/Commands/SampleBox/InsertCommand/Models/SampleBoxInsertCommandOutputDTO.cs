using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.InsertCommand.Models
{
    public class SampleBoxInsertCommandOutputDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SampleBoxId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductName { get; set; }

        public string ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }

        public int ProductPictureId { get; set; }
    }
}
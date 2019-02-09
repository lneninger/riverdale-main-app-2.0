using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.DeleteCommand.Models
{
    public class SampleBoxDeleteCommandOutputDTO
    {

        public SampleBoxDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmmount { get; set; }
    }
}
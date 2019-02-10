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

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
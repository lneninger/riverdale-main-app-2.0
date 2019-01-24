using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.DeleteCommand.Models
{
    public class GrowerDeleteCommandOutputDTO
    {

        public GrowerDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
using System;

namespace ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models
{
    public class SampleBoxUpdateCommandOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; internal set; }
    }
}
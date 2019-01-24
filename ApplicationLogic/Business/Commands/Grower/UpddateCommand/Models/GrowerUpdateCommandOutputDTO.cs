using System;

namespace ApplicationLogic.Business.Commands.Grower.UpdateCommand.Models
{
    public class GrowerUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
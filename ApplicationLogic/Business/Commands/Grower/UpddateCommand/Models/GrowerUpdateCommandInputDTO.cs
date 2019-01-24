using System;

namespace ApplicationLogic.Business.Commands.Grower.UpdateCommand.Models
{
    public class GrowerUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
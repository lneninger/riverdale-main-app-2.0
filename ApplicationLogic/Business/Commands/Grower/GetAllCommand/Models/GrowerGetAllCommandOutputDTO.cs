using System;

namespace ApplicationLogic.Business.Commands.Grower.GetAllCommand.Models
{
    public class GrowerGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
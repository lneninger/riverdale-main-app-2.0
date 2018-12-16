using System;

namespace ApplicationLogic.Business.Commands.File.GetAllCommand.Models
{
    public class FileGetAllCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
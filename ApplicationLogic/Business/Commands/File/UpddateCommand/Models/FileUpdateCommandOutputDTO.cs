using System;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand.Models
{
    public class FileUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
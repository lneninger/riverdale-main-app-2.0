using System;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand.Models
{
    public class FileUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
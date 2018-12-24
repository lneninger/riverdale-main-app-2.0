using System;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand.Models
{
    public class FileUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string FileName { get; internal set; }
    }
}
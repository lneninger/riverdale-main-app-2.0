using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.DeleteCommand.Models
{
    public class FileDeleteCommandOutputDTO
    {

        public FileDeleteCommandOutputDTO()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
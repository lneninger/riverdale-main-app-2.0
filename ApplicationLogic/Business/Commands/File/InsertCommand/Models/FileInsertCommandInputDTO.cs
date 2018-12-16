using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.InsertCommand.Models
{
    public class FileInsertCommandInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}
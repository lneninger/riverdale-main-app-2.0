using System;

namespace FunzaApplicationLogic.Commands.Size.SizePageQueryCommand.Models
{
    public class SizePageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
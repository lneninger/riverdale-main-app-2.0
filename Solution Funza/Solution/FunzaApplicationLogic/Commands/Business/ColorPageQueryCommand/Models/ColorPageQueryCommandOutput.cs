using System;

namespace FunzaApplicationLogic.Commands.ColorPageQueryCommand.Models
{
    public class ColorPageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
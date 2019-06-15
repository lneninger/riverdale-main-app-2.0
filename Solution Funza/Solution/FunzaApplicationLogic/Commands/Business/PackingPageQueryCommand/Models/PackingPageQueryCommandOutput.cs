using System;

namespace FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand.Models
{
    public class PackingPageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
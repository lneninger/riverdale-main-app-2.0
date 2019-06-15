using System;

namespace FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand.Models
{
    public class CategoryPageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
using System;

namespace FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand.Models
{
    public class ProductPageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
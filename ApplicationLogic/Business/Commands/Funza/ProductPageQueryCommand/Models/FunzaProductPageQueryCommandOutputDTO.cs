using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand.Models
{
    public class FunzaProductPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
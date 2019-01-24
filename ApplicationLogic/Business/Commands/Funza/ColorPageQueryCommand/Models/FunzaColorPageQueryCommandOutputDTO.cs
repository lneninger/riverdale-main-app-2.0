using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand.Models
{
    public class FunzaColorPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
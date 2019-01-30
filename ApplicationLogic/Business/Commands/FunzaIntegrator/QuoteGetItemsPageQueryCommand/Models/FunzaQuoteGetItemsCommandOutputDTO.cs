using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models
{
    public class FunzaQuoteGetItemsCommandOutputDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
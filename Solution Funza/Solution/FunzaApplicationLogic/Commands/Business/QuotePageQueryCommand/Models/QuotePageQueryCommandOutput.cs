using System;

namespace FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand.Models
{
    public class QuotePageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
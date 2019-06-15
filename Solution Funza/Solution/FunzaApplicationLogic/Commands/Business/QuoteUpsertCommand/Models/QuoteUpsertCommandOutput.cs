using System;

namespace FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models
{
    public class QuoteUpsertCommandOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
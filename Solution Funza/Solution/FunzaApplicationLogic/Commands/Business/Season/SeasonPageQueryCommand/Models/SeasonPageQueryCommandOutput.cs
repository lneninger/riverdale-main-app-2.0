using System;

namespace FunzaApplicationLogic.Commands.Season.SeasonPageQueryCommand.Models
{
    public class SeasonPageQueryCommandOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
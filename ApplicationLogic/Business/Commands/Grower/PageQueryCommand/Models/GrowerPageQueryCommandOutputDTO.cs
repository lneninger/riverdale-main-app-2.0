using System;

namespace ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models
{
    public class GrowerPageQueryCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
        public string SalesforceId { get; set; }
        public DateTime? CreatedAt { get; set; }
       
    }
}
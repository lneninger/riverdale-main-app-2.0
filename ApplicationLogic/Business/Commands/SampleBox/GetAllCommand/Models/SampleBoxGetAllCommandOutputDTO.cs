using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SampleBox.GetAllCommand.Models
{
    public class SampleBoxGetAllCommandOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
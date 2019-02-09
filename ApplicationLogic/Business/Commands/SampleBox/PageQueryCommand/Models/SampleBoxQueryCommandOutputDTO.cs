using ApplicationLogic.Business.Commons.DTOs;
using System;

namespace ApplicationLogic.Business.Commands.SampleBox.PageQueryCommand.Models
{
    public class SampleBoxPageQueryCommandOutputDTO
    {
        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int ProductId { get; set; }

        public int ProductAmount { get; set; }

    }
}
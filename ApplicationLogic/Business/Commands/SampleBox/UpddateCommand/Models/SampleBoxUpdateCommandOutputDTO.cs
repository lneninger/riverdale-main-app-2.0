using System;

namespace ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models
{
    public class SampleBoxUpdateCommandOutputDTO
    {
        public int Id { get; set; }

        public int SampleBoxId { get; set; }

        public int ProductAmount { get; set; }

        public string ProductColorTypeId { get; set; }

        public int ProductId { get; internal set; }

        public string ProductName { get; set; }

        public int ProductPictureId { get; set; }

        public string ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductTypeDescription { get; set; }
    }
}
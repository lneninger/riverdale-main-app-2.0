using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SampleBox.UpdateCommand.Models
{
    public class SampleBoxUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
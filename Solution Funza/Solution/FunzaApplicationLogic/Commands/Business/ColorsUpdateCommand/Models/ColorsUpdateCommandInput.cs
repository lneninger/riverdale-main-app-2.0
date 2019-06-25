using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand.Models
{
    public class ColorsUpdateCommandInput
    {
        public string Id { get; set; }

        public Guid IntegrationId { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }

        public string Name { get; set; }

        public string NameEnglish { get; set; }

        public string State { get; set; }

        public string Version { get; set; }

        public string Hexagecimal { get; set; }

        public string Image { get; set; }
    }
}
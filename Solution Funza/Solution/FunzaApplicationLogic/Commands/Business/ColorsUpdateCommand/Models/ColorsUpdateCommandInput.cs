using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand.Models
{
    public class ColorsUpdateCommandInput
    {
        public int FunzaId { get; set; }

        public Guid IntegrationId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime FunzaCreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime FunzaUpdatedDate { get; set; }

        public string Name { get; set; }

        public string NameEnglish { get; set; }

        public bool Status { get; set; }

        public string Version { get; set; }

        public string ValueRGB { get; set; }

        public string Image { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Size.SizeUpdateCommand.Models
{
    public class SizesUpdateCommandInput
    {
        public int Id { get; set; }
        public int FunzaId { get; set; }
        public Guid IntegrationId { get; set; }

        public int Name { get; set; }
        public string EnglishName { get; set; }
        public bool State { get; set; }
        public int Description { get; set; }
        public bool AllowCause { get; set; }
        public bool Exportable { get; set; }
        public int Order { get; set; }
        public bool AdmitValidation { get; set; }
        public string Version { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string FunzaCreatedBy { get; set; }
        public DateTime FunzaCreatedDate { get; set; }
    }
}
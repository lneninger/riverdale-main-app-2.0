using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models
{
    public class CategoriesUpdateCommandInput
    {
        public int Id { get; set; }

        public int FunzaId { get; set; }

        public Guid IntegrationId { get; set; }

        public string Name { get; set; }

        public bool ToOrder { get; set; }

        public bool ToStem { get; set; }

        public string FunzaCreatedBy { get; set; }

        public DateTime FunzaCreatedDate { get; set; }

        public string FunzaUpdatedBy { get; set; }

        public DateTime? FunzaUpdatedDate { get; set; }
    }
}
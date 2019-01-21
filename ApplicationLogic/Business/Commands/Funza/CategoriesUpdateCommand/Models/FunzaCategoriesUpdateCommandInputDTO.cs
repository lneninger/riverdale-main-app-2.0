using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.CategoriesUpdateCommand.Models
{
    public class FunzaCategoriesUpdateCommandInputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ToOrder { get; set; }

        public bool ToStem { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
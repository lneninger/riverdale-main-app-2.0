using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetSizesCommand.Models
{
    public class FunzaGetSizesCommandOutput
    {
        public int Id { get; set; }

        public int GradeId { get; set; }

        public int Name { get; set; }

        public int EnglishName { get; set; }

        public int State { get; set; }

        public int Description { get; set; }

        public int AllowCouse { get; set; }

        public int Exportable { get; set; }

        public int Order { get; set; }

        public int AdmiteValidacion { get; set; }

        public int Version { get; set; }
    }
}
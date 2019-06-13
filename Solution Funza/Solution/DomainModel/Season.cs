using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Season
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public int Code { get; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "FechaInicio")]
        public DateTime? BeginDate { get; set; }

        [Display(Name = "FechaFin")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }
    }
}

using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Labor: AbstractBaseEntity
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "code")]
        public string Code { get; set; }

        [Display(Name = "cantidadTallos")]
        public int UnitAmount { get; set; }

        [Display(Name = "monto")]
        public decimal Cost { get; set; }

        [Display(Name = "activo")]
        public bool Active { get; set; }

        [Display(Name = "tipoRamoId")]
        public int BouquetTypeId { get; set; }
    }
}

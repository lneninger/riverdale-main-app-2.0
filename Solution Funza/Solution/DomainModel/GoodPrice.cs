using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class GoodPrice: AbstractBaseEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Display(Name = "Categoria")]
        public string Category { get; set; }

        [Display(Name = "IdCategoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "UnidadMedida")]
        public string UnitMeasure { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Display(Name = "InsumoId")]
        public int GoodId { get; set; }

        [Display(Name = "Valor")]
        public decimal Value { get; set; }
    }
}

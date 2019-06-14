using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Price
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "valor")]
        public int Value { get; set; }

        [Display(Name = "temporadaId")]
        public int SeasonId { get; set; }

        [Display(Name = "activo")]
        public bool Active { get; set; }

        [Display(Name = "productoId")]
        public int ProductId { get; set; }

        [Display(Name = "codigo")]
        public string Code { get; set; }
    }
}

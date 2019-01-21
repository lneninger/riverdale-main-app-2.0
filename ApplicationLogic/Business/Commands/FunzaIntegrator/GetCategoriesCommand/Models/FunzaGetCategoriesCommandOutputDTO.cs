using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand.Models
{
    public class FunzaGetCategoriesCommandOutputDTO
    {
        public int IdCategoriaProductos { get; set; }

        public string Nombre { get; set; }

        public bool AlPedido { get; set; }

        public bool AlRamo { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
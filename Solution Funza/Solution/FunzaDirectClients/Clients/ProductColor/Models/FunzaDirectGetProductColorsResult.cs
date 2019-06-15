using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.ProductColor.Models
{
    public class FunzaDirectGetProductColorsResult
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Categoria { get; set; }

        public int IdCategoria { get; set; }

        public string Descripcion { get; set; }

        public string UnidadMedida { get; set; }

        public bool Activo { get; set; }

        public int InsumoId { get; set; }

        public int Valor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Product.Models
{
    public class FunzaDirectGetProductsResult
    {
        public int IdProducto { get; set; }

        public int IdEspecie { get; set; }

        public int IdVariedad { get; set; }

        public int IdGrado { get; set; }

        public int IdColor { get; set; }

        public string Codigo { get; set; }

        public bool Activo { get; set; }

        public string Descripcion { get; set; }

        public string Observaciones { get; set; }

        public int IdCategoria { get; set; }

        public int IdTipoProducto { get; set; }

        public int IdReferencia { get; set; }

        public int IdTipoReferencia { get; set; }

        public string TipoReferencia { get; set; }

        public string CodReferencia { get; set; }

        public string DescripcionRef { get; set; }

        public string TipoProducto { get; set; }

        public string Categoria { get; set; }

        public bool EnviarACotizador { get; set; }

        public DateTime Updateddate { get; set; }
    }
}

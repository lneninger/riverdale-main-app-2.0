using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Sizes.Models
{
    public class DirectGetSizesResult
    {
        public int Id { get; set; }

        public int IdGrado { get; set; }

        public int Nombre { get; set; }

        public int NombreIngles { get; set; }

        public int Estado { get; set; }

        public int Descripcion { get; set; }

        public int AdmiteCausa { get; set; }

        public int Exportable { get; set; }

        public int Orden { get; set; }

        public int AdmiteValidacion { get; set; }

        public int Version { get; set; }
    }
}

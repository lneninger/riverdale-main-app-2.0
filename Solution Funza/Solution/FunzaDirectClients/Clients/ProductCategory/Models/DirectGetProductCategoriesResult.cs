using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductCategory.Models
{
    public class DirectGetProductCategoriesResult
    {
        [JsonProperty(PropertyName = "IdCategoriaProductos")]
        public int FunzaId { get; set; }

        [JsonProperty(PropertyName = "Nombre")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "AlPedido")]
        public bool ToOrder { get; set; }

        [JsonProperty(PropertyName = "AlRamo")]
        public bool ToStem { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public string FunzaCreatedBy { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime FunzaCreatedDate { get; set; }

        [JsonProperty(PropertyName = "UpdatedBy")]
        public string FunzaUpdatedBy { get; set; }

        [JsonProperty(PropertyName = "UpdatedDate")]
        public DateTime? FunzaUpdatedDate { get; set; }
    }
}

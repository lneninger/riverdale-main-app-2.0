using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductColor.Models
{
    public class DirectGetProductColorsResult
    {
        [JsonProperty(PropertyName = "IdColor")]
        public int FunzaId { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public string FunzaCreatedBy { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime FunzaCreatedDate { get; set; }

        [JsonProperty(PropertyName = "UpdatedBy")]
        public string FunzaUpdatedBy { get; set; }

        [JsonProperty(PropertyName = "UpdatedDate")]
        public DateTime FunzaUpdatedDate { get; set; }

        

        [JsonProperty(PropertyName = "Nombre")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "NombreIngles")]
        public string NameEnglish { get; set; }

        [JsonProperty(PropertyName = "Estado")]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "ValorRGB")]
        public string ValueRGB { get; set; }

        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }
    }
}

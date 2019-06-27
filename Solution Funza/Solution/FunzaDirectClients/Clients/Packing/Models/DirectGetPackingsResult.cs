using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Packing.Models
{
    public class DirectGetPackingsResult
    {
        [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }//": 0,

        [JsonProperty(PropertyName = "createdBy")]
    public string FunzaCreatedBy { get; set; }//": "string",

        [JsonProperty(PropertyName = "createdDate")]
    public DateTime FunzaCreatedDate { get; set; }//": "2019-06-27T08:47:17.939Z",

        [JsonProperty(PropertyName = "updatedBy")]
    public string FunzaUpdatedBy { get; set; }//": "string",

        [JsonProperty(PropertyName = "updatedDate")]
    public DateTime FunzaUpdatedDate { get; set; }//": "2019-06-27T08:47:17.939Z",

        [JsonProperty(PropertyName = "idEmpaque")]
    public int FunzaId { get; set; }//": 0,

        [JsonProperty(PropertyName = "nombre")]
    public string Name { get; set; }//": "string",

        [JsonProperty(PropertyName = "nombreIngles")]
    public string NameEnglish { get; set; }//": "string",

        [JsonProperty(PropertyName = "descripcion")]
    public string Description { get; set; }//": "string",

        [JsonProperty(PropertyName = "equivalentesFull")]
    public decimal EquivalentsFull { get; set; }//": 0,

        [JsonProperty(PropertyName = "largo")]
    public decimal Width { get; set; }//": 0,

        [JsonProperty(PropertyName = "ancho")]
    public decimal Length { get; set; }//": 0,

        [JsonProperty(PropertyName = "alto")]
    public decimal Height { get; set; }//": 0,

        [JsonProperty(PropertyName = "volumen")]
    public decimal Volume { get; set; }//": 0,

        [JsonProperty(PropertyName = "peso")]
    public decimal Weight { get; set; }//": 0,

        [JsonProperty(PropertyName = "estado")]
    public bool Status { get; set; }//": true,

        [JsonProperty(PropertyName = "imagen")]
    public string Image { get; set; }//": "string",

        [JsonProperty(PropertyName = "codigoCargoMaster")]
    public string CargoMasterCode { get; set; }//": "string",

        [JsonProperty(PropertyName = "descripcionVolumen")]
    public string VolumeDescription { get; set; }//": "string",

        [JsonProperty(PropertyName = "volumneEquivalenteFull")]
    public decimal VolumeEquivalentFull { get; set; }//": 0
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace FunzaApplicationLogic.Commands.Funza.GetAllCommand.Models
{
    public class ProductGetAllCommandOutput
    {
        [Display(Name= "Id")]
        public int Id { get; internal set; }

        [Display(Name= "IdProducto")]
        public int ProductId { get; set; }

        [Display(Name= "IdEspecie")]
        public int SpecieId { get; set; }

        [Display(Name= "IdVariedad")]
        public int VariatyId { get; set; }

        [Display(Name= "IdGrado")]
        public int SizeId { get; set; }

        [Display(Name= "IdColor")]
        public int ColorId { get; set; }

        [Display(Name= "Codigo")]
        public string Code { get; set; }

        [Display(Name= "Activo")]
        public bool Active { get; set; }

        [Display(Name= "Descripcion")]
        public string Description { get; set; }

        [Display(Name= "Observaciones")]
        public string Notes { get; set; }

        [Display(Name= "IdCategoria")]
        public int CategoryId { get; set; }

        [Display(Name= "IdTipoProducto")]
        public int ProductTypeId { get; set; }

        [Display(Name= "IdReferencia")]
        public int ReferenceId { get; set; }

        [Display(Name= "IdTipoReferencia")]
        public int ReferenceTypeId { get; set; }

        [Display(Name= "TipoReferencia")]
        public string ReferenceType { get; set; }

        [Display(Name= "CodReferencia")]
        public string ReferenceCode { get; set; }

        [Display(Name= "DescripcionRef")]
        public string DescriptionRef { get; set; }

        [Display(Name= "TipoProducto")]
        public string ProductType { get; set; }

        [Display(Name= "Categoria")]
        public string Category { get; set; }

        [Display(Name= "EnviarACotizador")]
        public bool SendToQuotator { get; set; }

        [Display(Name= "Updateddate")]
        public DateTime Updateddate { get; set; }
    }
}
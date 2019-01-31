using ApplicationLogic.Business.Commons.DTOs;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models
{
    public class FunzaQuoteGetItemsCommandOutputDTO
    {
        public string Title { get; set; }

        public int Status { get; set; }

        public string AdjustRequestUserId { get; set; }

        public int CreateStep { get; set; }

        public string Code { get; set; }

        public FunzaQuoteGetItemsCommandOutputSubClientDTO SubClient { get; set; }
        public FunzaQuoteGetItemsCommandOutputBouquetTypeDTO BouquetType { get; set; }
        public FunzaQuoteGetItemsCommandOutputSeasonDTO Season { get; set; }
        public List<FunzaQuoteGetItemsCommandOutputProductDTO> Products { get; set; }
        public List<FunzaQuoteGetItemsCommandOutputSupplyDTO> Supplies { get; set; }
    }

    public class FunzaQuoteGetItemsCommandOutputSubClientDTO
    {
        public int Id { get; set; }//"id": 1501
        public string Code { get; set; }//"codigo": "3-1501",
        public string Name { get; set; }//"nombre": "Generic",
        public decimal Margen { get; set; }//"margen": 0.08,
        public bool Status { get; set; }//"estado": true,
        public int ClientId { get; set; }//"clienteId": 3,
        public string ClientName { get; set; }//"clienteNombre": "RIVERDALE FARMS, LLC.",
        

    }

    public class FunzaQuoteGetItemsCommandOutputProductTypeDTO
    {
        public string Type { get; set; }//"tipo": "Mixed Bouquet",
        public string Abrev { get; set; }//"abrev": "BQ",
        public int IsDeleted { get; set; }//"isDeleted": false,
        public int PackingTypeId { get; set; }//"idTipoEmpaque": 6,
        public int InvoicingUnitId { get; set; }//"idUnidadFacturación": 2,
        public DateTime LastModificationTime { get; set; }//"lastModificationTime": "2018-05-16T16:31:33.9089761",
        public int LastModifierUserId { get; set; }//"lastModifierUserId": null,
        public DateTime CreatedDate { get; set; }//"creationTime": "2018-05-16T16:31:33.8152224",
        public string CreatedUserId { get; set; }//"creatorUserId": null,
        public int Id { get; set; }//"id": 5


    }

    public class FunzaQuoteGetItemsCommandOutputBouquetTypeDTO
    {
        public int Id { get; set; }//"id": 8
        public string Name { get; set; }//"nombre": "CHOP & DROP",
        public string Abrev { get; set; }//"abrev": null,
        public DateTime CreatedDate { get; set; }//"creationTime": "2018-07-11T00:00:00",
        public int CreatedUserId { get; set; }//"creatorUserId": 9,

        public List<FunzaQuoteGetItemsCommandOutputLaborDTO> Labor { get; set; }
    }

    public class FunzaQuoteGetItemsCommandOutputLaborDTO
    {
        public int Stems { get; set; } //"cantidadTallos": 10,
        public decimal Amount { get; set; }//"monto": 0.28,
        public bool Active { get; set; }//"activo": true,
        public int BouquetTypeId { get; set; }//"tipoRamoId": 8,
    }

    public class FunzaQuoteGetItemsCommandOutputSeasonDTO
    {
        public int Id { get; set; }//"id": 4
        public int Code { get; set; }//"codigo": "4",
        public string Name { get; set; }//"nombre": "Easter",
        public DateTime BeginDate { get; set; }//"fechaInicio": "03/15/2019",
        public DateTime EndDate { get; set; }//"fechaFin": "04/06/2019",
        public bool Active { get; set; }//"activo": true,
    }

    public class FunzaQuoteGetItemsCommandOutputProductDTO
    {
        public int Id { get; set; }//"id": 4383
        public string ProductDescription { get; set; }//"productoDescripcion": "ALSTROEMERIA BUTTER PLUS BICOLOR LAVENDER ",
        public int ProductId { get; set; }                //"productoId": 2512,
        public string GradeName { get; set; }//"gradoNombre": "BUTTER PLUS",
        public int GradeId { get; set; }//"gradoId": 12,
        public int SpecieId { get; set; }//"especieId": 5,
        public string SpecieName { get; set; }//"especieNombre": "ALSTROEMERIA",
        public string ColorName { get; set; }//"colorNombre": "BICOLOR LAVENDER",
        public int ColorId { get; set; }//"colorId": 60,
        public int Quantity { get; set; }//"cantidad": 5,
        public decimal Price { get; set; }//"precioValor": 0.25,
        public int PriceId { get; set; }//"precioId": 1729,
        public decimal Discount { get; set; }//"descuento": 0.0,
        public decimal TotalPrice { get; set; }//"precioTotal": 1.25,
        public bool IsDeleted { get; set; }//"isDeleted": false,
        public bool IsAdjusted { get; set; }//"isAdjusted": false,
        public decimal ConfirmationPrice { get; set; }//"confirmationPrice": 0.0,
    }

    public class FunzaQuoteGetItemsCommandOutputSupplyDTO
    {
        public int Id { get; set; }//"id": 2100
        public int SupplyId { get; set; }//"insumoId": 1380,
        public string Category { get; set; }//"categoria": "SLEEVE",
        public string Description { get; set; }//"descripcion": "GROWER SLEEVE 3.5\"X16\"X13\"",
        public int Quantity { get; set; }//"cantidad": 1,
        public decimal Price { get; set; }//"precioValor": 0.08,
        public int PriceId { get; set; }//"precioId": 33,
        public decimal Discount { get; set; }//"descuento": 0.0,
        public decimal TotalPrice { get; set; }//"precioTotal": 0.08,
        public bool IsDeleted { get; set; }//"isDeleted": false,
        public bool IsAdjusted { get; set; }//"isAdjusted": false,
        public decimal ConfirmationPrice { get; set; }//"confirmationPrice": 0.0,
    }
}
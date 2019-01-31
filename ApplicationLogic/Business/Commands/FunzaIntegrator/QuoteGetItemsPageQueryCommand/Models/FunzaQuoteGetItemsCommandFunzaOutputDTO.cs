﻿using ApplicationLogic.Business.Commons.DTOs;
using ApplicationLogic.Business.Commons.Funza.DTOs;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models
{
    public class FunzaQuoteGetItemsCommandFunzaOutputDTO
    {
        public string Titulo { get; set; }

        public int Estado { get; set; }

        public string AdjustRequestUserId { get; set; }

        public int PasoCreacion { get; set; }

        public string Codigo { get; set; }

        public FunzaQuoteGetItemsCommandFunzaOutputSubClientDTO SubCliente { get; set; }
        public FunzaQuoteGetItemsCommandFunzaOutputBouquetTypeDTO TipoRamo { get; set; }
        public FunzaQuoteGetItemsCommandFunzaOutputSeasonDTO Temporada { get; set; }
        public List<FunzaQuoteGetItemsCommandFunzaOutputProductDTO> Productos { get; set; }
        public List<FunzaQuoteGetItemsCommandFunzaOutputSupplyDTO> Insumos { get; set; }
    }

    public class FunzaQuoteGetItemsCommandFunzaOutputSubClientDTO
    {
        public int Id { get; set; }//"id": 1501
        public string Codigo { get; set; }//"codigo": "3-1501",
        public string Nombre { get; set; }//"nombre": "Generic",
        public decimal Margen { get; set; }//"margen": 0.08,
        public bool Estado { get; set; }//"estado": true,
        public int ClienteId { get; set; }//"clienteId": 3,
        public string ClienteNombre { get; set; }//"clienteNombre": "RIVERDALE FARMS, LLC.",
    }

    public class FunzaQuoteGetItemsCommandFunzaOutputProductTypeDTO
    {
        public string Tipo { get; set; }//"tipo": "Mixed Bouquet",
        public string Abrev { get; set; }//"abrev": "BQ",
        public int IsDeleted { get; set; }//"isDeleted": false,
        public int IdTipoEmpaque { get; set; }//"idTipoEmpaque": 6,
        public int IdUnidadFacturacion { get; set; }//"idUnidadFacturación": 2,
        public DateTime LastModificationTime { get; set; }//"lastModificationTime": "2018-05-16T16:31:33.9089761",
        public int LastModifierUserId { get; set; }//"lastModifierUserId": null,
        public DateTime CreationDate { get; set; }//"creationTime": "2018-05-16T16:31:33.8152224",
        public string CreationUserId { get; set; }//"creatorUserId": null,
        public int Id { get; set; }//"id": 5


    }

    public class FunzaQuoteGetItemsCommandFunzaOutputBouquetTypeDTO
    {
        public string Nombre { get; set; }//"nombre": "CHOP & DROP",
        public string Abrev { get; set; }//"abrev": null,
        public DateTime CreationTime { get; set; }//"creationTime": "2018-07-11T00:00:00",
        public int CreatorUserId { get; set; }//"creatorUserId": 9,
        public int Id { get; set; }//"id": 8

        public List<FunzaQuoteGetItemsCommandFunzaOutputLaborDTO> Labor { get; set; }
    }

    public class FunzaQuoteGetItemsCommandFunzaOutputLaborDTO
    {
        public int CantidadTallos { get; set; } //"cantidadTallos": 10,
        public decimal Monto { get; set; }//"monto": 0.28,
        public bool Activo { get; set; }//"activo": true,
        public int TipoRamoId { get; set; }//"tipoRamoId": 8,
    }

    public class FunzaQuoteGetItemsCommandFunzaOutputSeasonDTO
    {
        public int Id { get; set; }//"id": 4
        public int Codigo { get; set; }//"codigo": "4",
        public string Nombre { get; set; }//"nombre": "Easter",
        public DateTime FechaInicio { get; set; }//"fechaInicio": "03/15/2019",
        public DateTime FechaFin { get; set; }//"fechaFin": "04/06/2019",
        public bool Activo { get; set; }//"activo": true,
    }

    public class FunzaQuoteGetItemsCommandFunzaOutputProductDTO
    {
        public int Id { get; set; }//"id": 4383
        public string ProductoDescripcion { get; set; }//"productoDescripcion": "ALSTROEMERIA BUTTER PLUS BICOLOR LAVENDER ",
        public int ProductoId { get; set; }                //"productoId": 2512,
        public string GradoNombre { get; set; }//"gradoNombre": "BUTTER PLUS",
        public int GradoId { get; set; }//"gradoId": 12,
        public int EspecieId { get; set; }//"especieId": 5,
        public string EspecieNombre { get; set; }//"especieNombre": "ALSTROEMERIA",
        public string ColorNombre { get; set; }//"colorNombre": "BICOLOR LAVENDER",
        public int ColorId { get; set; }//"colorId": 60,
        public int Cantidad { get; set; }//"cantidad": 5,
        public decimal PrecioValor { get; set; }//"precioValor": 0.25,
        public int PrecioId { get; set; }//"precioId": 1729,
        public decimal Descuento { get; set; }//"descuento": 0.0,
        public decimal PrecioTotal { get; set; }//"precioTotal": 1.25,
        public bool IsDeleted { get; set; }//"isDeleted": false,
        public bool IsAdjusted { get; set; }//"isAdjusted": false,
        public decimal ConfirmationPrice { get; set; }//"confirmationPrice": 0.0,
    }

    public class FunzaQuoteGetItemsCommandFunzaOutputSupplyDTO
    {
        public int Id { get; set; }//"id": 2100
        public int InsumoId { get; set; }//"insumoId": 1380,
        public string Categoria { get; set; }//"categoria": "SLEEVE",
        public string Descripcion { get; set; }//"descripcion": "GROWER SLEEVE 3.5\"X16\"X13\"",
        public int Cantidad { get; set; }//"cantidad": 1,
        public decimal PrecioValor { get; set; }//"precioValor": 0.08,
        public int PrecioId { get; set; }//"precioId": 33,
        public decimal Descuento { get; set; }//"descuento": 0.0,
        public decimal PrecioTotal { get; set; }//"precioTotal": 0.08,
        public bool IsDeleted { get; set; }//"isDeleted": false,
        public bool IsAdjusted { get; set; }//"isAdjusted": false,
        public decimal ConfirmationPrice { get; set; }//"confirmationPrice": 0.0,
    }
}
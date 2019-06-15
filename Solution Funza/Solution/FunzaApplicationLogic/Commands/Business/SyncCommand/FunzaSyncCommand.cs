using Framework.Autofac;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models;
using FunzaApplicationLogic.Commands.Funza.ColorsUpdateCommand.Models;
using FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models;
using FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models;
using FunzaApplicationLogic.Commands.Funza.QuotesUpdateCommand.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.SyncCommand
{
    public class FunzaSyncCommand : BaseIoCDisposable, IFunzaSyncCommand
    {
        public FunzaSyncCommand(IFunzaGetProductsCommand getProductsCommand, IFunzaProductsUpdateCommand productsUpdateCommand, IFunzaGetColorsCommand getColorsCommand, IFunzaColorsUpdateCommand colorsUpdateCommand, IFunzaGetCategoriesCommand getCategoriesCommand, IFunzaCategoriesUpdateCommand categoriesUpdateCommand, IFunzaGetPackingsCommand getPackingsCommand, IFunzaPackingsUpdateCommand packingsUpdateCommand/*, IFunzaQuoteGetItemsCommand getQuotesCommand*/, IFunzaQuotesUpdateCommand quotesUpdateCommand)
        {
            this.ProductsUpdateCommand = productsUpdateCommand;
            this.GetProductsCommand = getProductsCommand;

            this.GetColorsCommand = getColorsCommand;
            this.ColorsUpdateCommand = colorsUpdateCommand;

            this.GetCategoriesCommand = getCategoriesCommand;
            this.CategoriesUpdateCommand = categoriesUpdateCommand;

            this.GetPackingsCommand = getPackingsCommand;
            this.PackingsUpdateCommand = packingsUpdateCommand;

            //this.GetQuotesCommand = getQuotesCommand;
            this.QuotesUpdateCommand = quotesUpdateCommand;
        }

        public IFunzaGetProductsCommand GetProductsCommand { get; }
        public IFunzaGetColorsCommand GetColorsCommand { get; }
        public IFunzaProductsUpdateCommand ProductsUpdateCommand { get; }
        public IFunzaPackingsUpdateCommand PackingsUpdateCommand { get; }
        public IFunzaColorsUpdateCommand ColorsUpdateCommand { get; }
        public IFunzaGetCategoriesCommand GetCategoriesCommand { get; }
        public IFunzaCategoriesUpdateCommand CategoriesUpdateCommand { get; }
        public IFunzaGetPackingsCommand GetPackingsCommand { get; }
        //public IFunzaQuoteGetItemsCommand GetQuotesCommand { get; }
        public IFunzaQuotesUpdateCommand QuotesUpdateCommand { get; }

        public async Task<OperationResponse> ExecuteAsync()
        {
            var taskDictionary = new Dictionary<string, Task<Object>>();
            var result = new OperationResponse();
            
            taskDictionary.Add(
                "Products"
                , Task.Run<object>(async() =>
                {
                    var combination = new List<FunzaGetProductsCommandOutput>();
                    var filter = new PageQuery<FunzaGetProductsCommandInput>();
                    var source = await this.GetProductsCommand.ExecuteAsync(filter);
                    combination.AddRange(source.Bag.Items);
                    while (source.IsSucceed && source.Bag?.Items.Count > 0 )
                    {
                        filter.PageIndex++;
                        source = await this.GetProductsCommand.ExecuteAsync(filter);
                        if (source.IsSucceed && source.Bag != null)
                        {
                            combination.AddRange(source.Bag.Items);
                        }
                    }

                    var mapping = this.Map(combination);

                    return this.ProductsUpdateCommand.Execute(mapping);

                })
            );

            taskDictionary.Add(
                "Colors"
                , Task.Run<object>(async () =>
                {
                    var combination = new List<FunzaGetColorsCommandOutput>();
                    var filter = new PageQuery<FunzaGetColorsCommandInput>();
                    var source = await this.GetColorsCommand.ExecuteAsync(filter);
                    combination.AddRange(source.Bag.Items);
                    while (source.IsSucceed && source.Bag?.Items.Count > 0)
                    {
                        filter.PageIndex++;
                        source = await this.GetColorsCommand.ExecuteAsync(filter);
                        if (source.IsSucceed && source.Bag != null)
                        {
                            combination.AddRange(source.Bag.Items);
                        }
                    }

                    var mapping = this.Map(combination);

                    return this.ColorsUpdateCommand.Execute(mapping);

                })
            );
            
            taskDictionary.Add(
                "Categories"
                , Task.Run<object>(async () =>
                {
                    var combination = new List<FunzaGetCategoriesCommandOutput>();
                    var filter = new PageQuery<FunzaGetCategoriesCommandInput>();
                    var source = await this.GetCategoriesCommand.ExecuteAsync(filter);
                    combination.AddRange(source.Bag.Items);
                    while (source.IsSucceed && source.Bag?.Items.Count > 0)
                    {
                        filter.PageIndex++;
                        source = await this.GetCategoriesCommand.ExecuteAsync(filter);
                        if (source.IsSucceed && source.Bag != null)
                        {
                            combination.AddRange(source.Bag.Items);
                        }
                    }

                    var mapping = this.Map(combination);

                    return this.CategoriesUpdateCommand.Execute(mapping);

                })
            );
            
            /*
            taskDictionary.Add(
                "Packings"
                , Task.Run<object>(() =>
                {
                    var source = this.GetPackingsCommand.Execute();
                    if (source.IsSucceed && source.Bag != null && source.Bag.Count() > 0)
                    {
                        var dest = this.Map(source.Bag);
                        return this.PackingsUpdateCommand.Execute(dest);
                    }

                    return new OperationResponse<FunzaPackingsUpdateCommandOutputDTO>();
                })
            );

            taskDictionary.Add(
                "Quotes"
                , Task.Run<object>(() =>
                {
                    int pageIndex = 0;
                    int pageSize = 100;
                    var pageQuery = new PageQuery<FunzaQuoteGetItemsCommandInputDTO> {
                        PageIndex = pageIndex, PageSize = pageSize
                    };

                    PageResult<FunzaQuoteGetItemsCommandOutputDTO> loopResult = null;

                    for (; pageIndex == 0 || (pageIndex > 0 && loopResult.Items.Count == pageSize); pageIndex++)
                    {
                        var source = this.GetQuotesCommand.Execute(pageQuery);
                        loopResult = source.Bag;
                        if (source.IsSucceed && source.Bag != null && loopResult.Items.Count() > 0)
                        {
                            var dest = this.Map(loopResult.Items);
                            return this.QuotesUpdateCommand.Execute(dest);
                        }
                    }

                    return new OperationResponse<FunzaPackingsUpdateCommandOutputDTO>();
                })
            );*/

            Task.WaitAll(taskDictionary.Values.ToArray());
            
            result.AddResponse(taskDictionary["Products"].Result as OperationResponse);
            result.AddResponse(taskDictionary["Colors"].Result as OperationResponse);
            result.AddResponse(taskDictionary["Categories"].Result as OperationResponse);
            //result.AddResponse(taskDictionary["Packings"].Result as OperationResponse);
            //result.AddResponse(taskDictionary["Quotes"].Result as OperationResponse);

            return result;
        }

        private IEnumerable<ProductsUpdateCommandInput> Map(IEnumerable<FunzaGetProductsCommandOutput> source)
        {
            var result = source.Select(item => new ProductsUpdateCommandInput
            {
                Active = item.Activo,
                CategoryId = item.IdCategoria,
                CategoryName = item.Categoria,
                Code = item.Codigo,
                ColorId = item.IdColor,
                Description = item.Descripcion,
                GradeId = item.IdGrado,
                Id = item.IdProducto,
                Comments = item.Observaciones,
                ProductTypeId = item.IdTipoProducto,
                ProductTypeName = item.TipoProducto,
                ReferenceCode = item.CodReferencia,
                ReferenceDescription = item.DescripcionRef,
                ReferenceId = item.IdReferencia,
                ReferenceTypeId = item.IdTipoReferencia,
                ReferenceTypeName = item.TipoReferencia,
                SendQuotator = item.EnviarACotizador,
                SpecieId = item.IdEspecie,
                VarieryId = item.IdVariedad,
                FunzaUpdatedDate = item.Updateddate,
            });

            return result;
        }

        private IEnumerable<FunzaColorsUpdateCommandInputDTO> Map(IEnumerable<FunzaGetColorsCommandOutput> source)
        {
            var result = source.Select(item => new FunzaColorsUpdateCommandInputDTO
            {
                CreatedBy = item.CreatedBy,
                Hexagecimal = item.Hex,
                Id = item.IdColor,
                CreatedDate = item.CreatedDate,
                Image = item.Img,
                Name = item.Nombre,
                NameEnglish = item.NombreIngles,
                State = item.Estado,
                UpdatedBy = item.UpdatedBy,
                UpdatedDate = item.UpdatedDate,
                Version = item.Version,
            });

            return result;
        }

        private IEnumerable<FunzaCategoriesUpdateCommandInputDTO> Map(IEnumerable<FunzaGetCategoriesCommandOutput> source)
        {
            var result = source.Select(item => new FunzaCategoriesUpdateCommandInputDTO
            {
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
                Id = item.IdCategoriaProductos,
                Name = item.Nombre,
                ToOrder = item.AlPedido,
                ToStem = item.AlRamo,
                UpdatedBy = item.UpdatedBy,
                UpdatedDate = item.UpdatedDate,
            });

            return result;
        }

        //private IEnumerable<FunzaPackingsUpdateCommandInputDTO> Map(IEnumerable<FunzaGetPackingsCommandOutput> source)
        //{
        //    var result = source.Select(item => new FunzaPackingsUpdateCommandInputDTO {
        //        CargoMasterCode = item.CodigoCargoMaster,
        //        CreatedBy = item.CodigoCargoMaster,
        //        CreatedDate = item.CreatedDate,
        //        Description = item.Descripcion,
        //        EquivalentFullQuotator = item.EquivalenteFullCotizador,
        //        EquivalentsFull = item.EquivalentesFull,
        //        Id = item.Id,
        //        Height = item.Alto,
        //        Image = item.Imagen,
        //        Length = item.Largo,
        //        Name = item.Nombre,
        //        NameEnglish = item.NombreIngles,
        //        SentToQuotator = item.EviarACotizador,
        //        State = item.Estado,
        //        UpdatedBy = item.UpdatedBy,
        //        UpdatedDate = item.UpdatedDate,
        //        Volume = item.Volumen,
        //        VolumeDescripcion = item.DescripcionVolumen,
        //        VolumeEquivalentFull = item.VolumneEquivalenteFull,
        //        Weight = item.Peso,
        //        Width = item.Ancho,
        //    });

        //    return result;
        //}

        //private IEnumerable<FunzaQuotesUpdateCommandInputDTO> Map(IEnumerable<FunzaQuoteGetItemsCommandOutputDTO> source)
        //{
        //    var result = source.Select(item => new FunzaQuotesUpdateCommandInputDTO
        //    {
        //        FunzaId = item.Id,
        //        Title = item.Title,
        //        Code = item.Code,
        //        CreateStep = item.CreateStep,
        //        Status = item.Status,
        //        AdjustRequestUserId = item.AdjustRequestUserId,

                






        //        SubClient = new FunzaQuoteUpdateCommandOutputSubClientDTO
        //        {
        //            Id = item.SubClient.Id,
        //            ClientId = item.SubClient.ClientId,
        //            ClientName = item.SubClient.ClientName,
        //            Name = item.SubClient.Name,
        //            Code = item.SubClient.Code,
        //            Margen = item.SubClient.Margen,
        //            Status = item.SubClient.Status
        //        },
        //        BouquetType = new FunzaQuoteUpdateCommandOutputBouquetTypeDTO
        //        {
        //            Id = item.BouquetType.Id,
        //            Abrev = item.BouquetType.Abrev,
        //            CreatedDate = item.BouquetType.CreatedDate,
        //            CreatedUserId = item.BouquetType.CreatedUserId,
        //            Name = item.BouquetType.Name,
        //            Labor = item.BouquetType.Labor.Select(laborItem => new FunzaQuoteUpdateCommandOutputLaborDTO
        //            {
        //                BouquetTypeId = laborItem.BouquetTypeId,
        //                Active = laborItem.Active,
        //                Stems = laborItem.Stems,
        //                Amount = laborItem.Amount
        //            }).ToList()
        //        },
        //        Products = item.Products.Select(productItem => new FunzaQuoteUpdateCommandOutputProductDTO
        //        {
        //            Id = productItem.Id,
        //            ProductId = productItem.ProductId,
        //            ColorId = productItem.ColorId,
        //            ColorName = productItem.ColorName,
        //            ConfirmationPrice = productItem.ConfirmationPrice,
        //            Discount = productItem.Discount,
        //            GradeId = productItem.GradeId,
        //            GradeName = productItem.GradeName,
        //            IsAdjusted = productItem.IsAdjusted,
        //            IsDeleted = productItem.IsDeleted,
        //            Price = productItem.Price,
        //            PriceId = productItem.PriceId,
        //            TotalPrice = productItem.TotalPrice,
        //            ProductDescription = productItem.ProductDescription,
        //            Quantity = productItem.Quantity,
        //            SpecieId = productItem.SpecieId,
        //            SpecieName = productItem.SpecieName,
        //        }).ToList(),
        //        Season = new FunzaQuoteUpdateCommandOutputSeasonDTO
        //        {
        //            Id = item.Season.Id,
        //            Active = item.Season.Active,
        //            Name = item.Season.Name,
        //            BeginDate = item.Season.BeginDate,
        //            EndDate = item.Season.EndDate,
        //            Code = item.Season.Code
        //        },
        //        Supplies = item.Supplies.Select(supplyItem => new FunzaQuoteUpdateCommandOutputSupplyDTO
        //        {
        //            Id = supplyItem.Id,
        //            Category = supplyItem.Category,
        //            ConfirmationPrice = supplyItem.ConfirmationPrice,
        //            Description = supplyItem.Description,
        //            Discount = supplyItem.Discount,
        //            IsAdjusted = supplyItem.IsAdjusted,
        //            IsDeleted = supplyItem.IsDeleted,
        //            Price = supplyItem.Price,
        //            PriceId = supplyItem.PriceId,
        //            Quantity = supplyItem.Quantity,
        //            SupplyId = supplyItem.SupplyId,
        //            TotalPrice = supplyItem.TotalPrice
        //        }).ToList()
        //    }).ToList();

        //    return result;
        //}
    }
}

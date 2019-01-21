using ApplicationLogic.Business.Commands.Funza.CategoriesUpdateCommand.Models;
using ApplicationLogic.Business.Commands.Funza.ColorsUpdateCommand.Models;
using ApplicationLogic.Business.Commands.Funza.PackingsUpdateCommand.Models;
using ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using DomainModel.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationLogic.Business.Commands.Funza.PackingsUpdateCommand
{
    public class FunzaSyncCommand : BaseIoCDisposable, IFunzaSyncCommand
    {
        public FunzaSyncCommand(IFunzaGetProductsCommand getProductsCommand, IFunzaProductsUpdateCommand productsUpdateCommand, IFunzaGetColorsCommand getColorsCommand, IFunzaColorsUpdateCommand colorsUpdateCommand, IFunzaGetCategoriesCommand getCategoriesCommand, IFunzaCategoriesUpdateCommand categoriesUpdateCommand, IFunzaGetPackingsCommand getPackingsCommand, IFunzaPackingsUpdateCommand packingsUpdateCommand)
        {
            this.ProductsUpdateCommand = productsUpdateCommand;
            this.GetProductsCommand = getProductsCommand;

            this.GetColorsCommand = getColorsCommand;
            this.ColorsUpdateCommand = colorsUpdateCommand;

            this.GetCategoriesCommand = getCategoriesCommand;
            this.CategoriesUpdateCommand = categoriesUpdateCommand;

            this.GetPackingsCommand = getPackingsCommand;
            this.PackingsUpdateCommand = packingsUpdateCommand;
        }

        public IFunzaGetProductsCommand GetProductsCommand { get; }
        public IFunzaGetColorsCommand GetColorsCommand { get; }
        public IFunzaProductsUpdateCommand ProductsUpdateCommand { get; }

        public IFunzaPackingsUpdateCommand PackingsUpdateCommand { get; }
        public IFunzaColorsUpdateCommand ColorsUpdateCommand { get; }
        public IFunzaGetCategoriesCommand GetCategoriesCommand { get; }
        public IFunzaCategoriesUpdateCommand CategoriesUpdateCommand { get; }
        public IFunzaGetPackingsCommand GetPackingsCommand { get; }

        public OperationResponse Execute()
        {
            var taskDictionary = new Dictionary<string, Task<Object>>();
            var result = new OperationResponse();

            taskDictionary.Add(
                "Products"
                , Task.Run<object>(() =>
                {
                    var source = this.GetProductsCommand.Execute();
                    if (source.IsSucceed && source.Bag != null && source.Bag.Count() > 0)
                    {
                        var dest = this.Map(source.Bag);
                        return this.ProductsUpdateCommand.Execute(dest);
                    }

                    return new OperationResponse<FunzaProductsUpdateCommandOutputDTO>();
                })
            );

            taskDictionary.Add(
                "Colors"
                , Task.Run<object>(() =>
                {
                    var source = this.GetColorsCommand.Execute();
                    if (source.IsSucceed && source.Bag != null && source.Bag.Count() > 0)
                    {
                        var dest = this.Map(source.Bag);
                        return this.ColorsUpdateCommand.Execute(dest);
                    }

                    return new OperationResponse<FunzaColorsUpdateCommandOutputDTO>();
                })
            );

            taskDictionary.Add(
                "Categories"
                , Task.Run<object>(() =>
                {
                    var source = this.GetCategoriesCommand.Execute();
                    if (source.IsSucceed && source.Bag != null && source.Bag.Count() > 0)
                    {
                        var dest = this.Map(source.Bag);
                        return this.CategoriesUpdateCommand.Execute(dest);
                    }

                    return new OperationResponse<FunzaCategoriesUpdateCommandOutputDTO>();
                })
            );

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

            Task.WaitAll(taskDictionary.Values.ToArray());

            result.AddResponse(taskDictionary["Products"].Result as OperationResponse);
            result.AddResponse(taskDictionary["Colors"].Result as OperationResponse);
            result.AddResponse(taskDictionary["Categories"].Result as OperationResponse);
            result.AddResponse(taskDictionary["Packings"].Result as OperationResponse);

            return result;
        }

        private IEnumerable<FunzaProductsUpdateCommandInputDTO> Map(IEnumerable<FunzaGetProductsCommandOutputDTO> source)
        {
            var result = source.Select(item => new FunzaProductsUpdateCommandInputDTO
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

        private IEnumerable<FunzaColorsUpdateCommandInputDTO> Map(IEnumerable<FunzaGetColorsCommandOutputDTO> source)
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

        private IEnumerable<FunzaCategoriesUpdateCommandInputDTO> Map(IEnumerable<FunzaGetCategoriesCommandOutputDTO> source)
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

        private IEnumerable<FunzaPackingsUpdateCommandInputDTO> Map(IEnumerable<FunzaGetPackingsCommandOutputDTO> source)
        {
            var result = source.Select(item => new FunzaPackingsUpdateCommandInputDTO {
                CargoMasterCode = item.CodigoCargoMaster,
                CreatedBy = item.CodigoCargoMaster,
                CreatedDate = item.CreatedDate,
                DefinitiveInvoiceCargo = item.CargosFacturaDefinitiva,
                DefinitiveInvoiceItems = item.ItemsFacturaDefinitiva,
                Description = item.Descripcion,
                EquivalentFullQuotator = item.EquivalenteFullCotizador,
                EquivalentsFull = item.EquivalentesFull,
                Id = item.Id,
                Height = item.Alto,
                Image = item.Imagen,
                Length = item.Largo,
                Name = item.Nombre,
                NameEnglish = item.NombreIngles,
                NoteItems = item.ItemsNota,
                SentToQuotator = item.EviarACotizador,
                State = item.Estado,
                UpdatedBy = item.UpdatedBy,
                UpdatedDate = item.UpdatedDate,
                Volume = item.Volumen,
                VolumeDescripcion = item.DescripcionVolumen,
                VolumeEquivalentFull = item.VolumneEquivalenteFull,
                Weight = item.Peso,
                Width = item.Ancho,
            });

            return result;
        }
    }
}

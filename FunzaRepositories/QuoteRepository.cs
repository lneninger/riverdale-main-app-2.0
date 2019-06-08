using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using ApplicationLogic.Business.Commons.Funza.DTOs;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaInternalClients.Quote;
using FunzaInternalClients.Quote.Models;
using RestSharp;

namespace FunzaRepositories
{
    public class QuoteRepository : ApplicationLogic.Repositories.Funza.IQuoteRepository
    {
        public IInternalQuoteClient QuoteClient { get; }

        public QuoteRepository(FunzaInternalClients.Quote.IInternalQuoteClient QuoteClient)
        {
            this.QuoteClient = QuoteClient;
        }

        public OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>> PageQuery(PageQuery<FunzaQuoteGetItemsCommandInputDTO> input, string endpointURL, string accessToken)
        {
            var result = new OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>>();

            var client = new RestClient(endpointURL);
            var internalInput = new FunzaQuoteGetItemsCommandFunzaInputDTO
            {
                SkipCount = input.PageIndex * input.PageSize,
                MaxResultCount = input.PageSize == default(int) ? 10 : input.PageSize,
            };
            if (!string.IsNullOrWhiteSpace(input.CustomFilter.Term)) {
                internalInput.Nombre = input.CustomFilter.Term.Trim();
            }

            var request = new RestRequest(Method.GET);
            request.AddObject(internalInput);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<FunzaPageResult<FunzaQuoteGetItemsCommandFunzaOutputDTO>>(request);

            if (response.Data != null && response.Data.Success)
            {
                result.Bag = MappingQuoteGetAllResult(response);
            }

            return result;
        }

        private static PageResult<FunzaQuoteGetItemsCommandOutputDTO> MappingQuoteGetAllResult(IRestResponse<FunzaPageResult<FunzaQuoteGetItemsCommandFunzaOutputDTO>> response)
        {
            var result = new PageResult<FunzaQuoteGetItemsCommandOutputDTO>
            {
                Items = response.Data.Result.Items.Select(item => new FunzaQuoteGetItemsCommandOutputDTO
                {
                    Title = item.Titulo,
                    Code = item.Codigo,
                    CreateStep = item.PasoCreacion,
                    Status = item.Estado,
                    AdjustRequestUserId = item.AdjustRequestUserId,
                    SubClient = new FunzaQuoteGetItemsCommandOutputSubClientDTO
                    {
                        Id = item.SubCliente.Id,
                        ClientId = item.SubCliente.ClienteId,
                        ClientName = item.SubCliente.ClienteNombre,
                        Name = item.SubCliente.Nombre,
                        Code = item.SubCliente.Codigo,
                        Margen = item.SubCliente.Margen,
                        Status = item.SubCliente.Estado
                    },
                    BouquetType = new FunzaQuoteGetItemsCommandOutputBouquetTypeDTO
                    {
                        Id = item.TipoRamo.Id,
                        Abrev = item.TipoRamo.Abrev,
                        CreatedDate = item.TipoRamo.CreationTime,
                        CreatedUserId = item.TipoRamo.CreatorUserId,
                        Name = item.TipoRamo.Nombre,
                        Labor = item.TipoRamo.Labor.Select(laborItem => new FunzaQuoteGetItemsCommandOutputLaborDTO
                        {
                            BouquetTypeId = laborItem.TipoRamoId,
                            Active = laborItem.Activo,
                            Stems = laborItem.CantidadTallos,
                            Amount = laborItem.Monto
                        }).ToList()
                    },
                    Products = item.Productos.Select(productItem => new FunzaQuoteGetItemsCommandOutputProductDTO
                    {
                        Id = productItem.Id,
                        ProductId = productItem.ProductoId,
                        ColorId = productItem.ColorId,
                        ColorName = productItem.ColorNombre,
                        ConfirmationPrice = productItem.ConfirmationPrice,
                        Discount = productItem.Descuento,
                        GradeId = productItem.GradoId,
                        GradeName = productItem.GradoNombre,
                        IsAdjusted = productItem.IsAdjusted,
                        IsDeleted = productItem.IsDeleted,
                        Price = productItem.PrecioValor,
                        PriceId = productItem.PrecioId,
                        TotalPrice = productItem.PrecioTotal,
                        ProductDescription = productItem.ProductoDescripcion,
                        Quantity = productItem.Cantidad,
                        SpecieId = productItem.EspecieId,
                        SpecieName = productItem.EspecieNombre,
                    }).ToList(),
                    Season = new FunzaQuoteGetItemsCommandOutputSeasonDTO
                    {
                        Id = item.Temporada.Id,
                        Active = item.Temporada.Activo,
                        Name = item.Temporada.Nombre,
                        BeginDate = item.Temporada.FechaInicio,
                        EndDate = item.Temporada.FechaFin,
                        Code = item.Temporada.Codigo
                    },
                    Supplies = item.Insumos.Select(supplyItem => new FunzaQuoteGetItemsCommandOutputSupplyDTO
                    {
                        Id = supplyItem.Id,
                        Category = supplyItem.Categoria,
                        ConfirmationPrice = supplyItem.ConfirmationPrice,
                        Description = supplyItem.Descripcion,
                        Discount = supplyItem.Descuento,
                        IsAdjusted = supplyItem.IsAdjusted,
                        IsDeleted = supplyItem.IsDeleted,
                        Price = supplyItem.PrecioValor,
                        PriceId = supplyItem.PrecioId,
                        Quantity = supplyItem.Cantidad,
                        SupplyId = supplyItem.InsumoId,
                        TotalPrice = supplyItem.PrecioTotal
                    }).ToList()
                }).ToList()
            };

            return result;
        }




        public async Task<OperationResponse<InternalBridgeCreateQuoteOutput>> Upsert(AbstractProduct input)
        {
            var result = new OperationResponse<InternalBridgeCreateQuoteOutput>();
            var payload = new InternalBridgeCreateQuoteInput {
            };

            var resultContent = (await this.QuoteClient.CreateQuote(payload)).Content;

            var resultMap = new InternalBridgeCreateQuoteOutput
            {
            };

            result.Bag = resultMap;

            return result;

            //var client = new RestClient(endpointURL);
            //var internalInput = new FunzaQuoteGetItemsCommandFunzaInputDTO
            //{
            //    SkipCount = input.PageIndex * input.PageSize,
            //    MaxResultCount = input.PageSize == default(int) ? 10 : input.PageSize,
            //};
            //if (!string.IsNullOrWhiteSpace(input.CustomFilter.Term))
            //{
            //    internalInput.Nombre = input.CustomFilter.Term.Trim();
            //}

            //var request = new RestRequest(Method.GET);
            //request.AddObject(internalInput);
            //request.AddHeader("Authorization", $"Bearer {accessToken}");

            //var response = client.Execute<FunzaPageResult<FunzaQuoteGetItemsCommandFunzaOutputDTO>>(request);

            //if (response.Data != null && response.Data.Success)
            //{
            //    result.Bag = MappingQuoteGetAllResult(response);
            //}

            return result;
        }

    }
}

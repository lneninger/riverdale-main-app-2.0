using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Season.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Season
{
    public interface ISeasonClient: IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetSeasonsResult>>>> GetSeasons(int SkipCount = 0, int MaxResultCount = 10);

    }
}

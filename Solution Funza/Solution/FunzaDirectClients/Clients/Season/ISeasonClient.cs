using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.Season.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Season
{
    public interface ISeasonClient: IRefitClient
    {
        [Get("/")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetAllSeasonResult>>>> GetSeasons();

    }
}

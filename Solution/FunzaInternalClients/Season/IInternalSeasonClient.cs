using FunzaInternalClients.Season.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaInternalClients.Season
{
    public interface IInternalSeasonClient
    {
        [Post("/")]
        Task<ApiResponse<InternalBridgeSeasonMapOutput>> Map(InternalBridgeSeasonMapInput model);
    }
}

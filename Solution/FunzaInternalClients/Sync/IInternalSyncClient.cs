using Framework.Core.Messages;
using FunzaInternalClients.Season.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaInternalClients.Sync
{
    public interface IInternalSyncClient
    {
        [Put("/")]
        Task<ApiResponse<OperationResponse>> Sync();
    }
}

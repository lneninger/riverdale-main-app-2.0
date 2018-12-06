using ApplicationLogic.Business.Commons.DTOs;
using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons
{
    public interface IMasterDataProvider
    {
        OperationResponse<List<EnumItemDTO<string>>> GetToEnumThirdPartyAppType();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductColorType();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumCustomerFreightoutRateType();

        OperationResponse<List<EnumItemDTO<int>>> GetToEnumCustomer();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumAppUser();
    }
}

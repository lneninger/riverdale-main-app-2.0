using ApplicationLogic.Business.Commons.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons
{
    public interface IMasterDataProvider
    {
        List<EnumItemDTO<string>> GetToEnumThirdPartyAppType();

        List<EnumItemDTO<string>> GetToEnumProductColorType();

        List<EnumItemDTO<string>> GetToEnumCustomerFreightoutRateType();

        
    }
}

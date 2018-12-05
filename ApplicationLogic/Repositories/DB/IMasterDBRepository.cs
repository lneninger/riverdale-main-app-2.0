using System;
using System.Collections.Generic;
using System.Text;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Repositories.DB
{
    public interface IMasterDBRepository
    {
        List<EnumItemDTO<string>> GetToEnumThirdPartyAppType();

        List<EnumItemDTO<string>> GetToEnumProductColorType();

        List<EnumItemDTO<string>> GetToEnumCustomerFreightoutRateType();

        List<EnumItemDTO<int>> GetToEnumCustomer();

        List<EnumItemDTO<string>> GetToEnumUser();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using ApplicationLogic.Business.Commons.DTOs;
using Framework.Core.Messages;
using Framework.Core.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IMasterDBRepository
    {
        OperationResponse<List<EnumItemDTO<string>>> GetToEnumThirdPartyAppType();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductColorType();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumCustomerFreightoutRateType();

        OperationResponse<List<EnumItemDTO<int>>> GetToEnumCustomer();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumUser();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductType();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumRole();

        OperationResponse<List<EnumItemDTO<int>>> GetToEnumProducts();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumSeasonCategories();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumSeasonCategoriesWithSeasons();

        OperationResponse<List<EnumItemDTO<string>>> GetToEnumGrowerTypesWithGrower();

        OperationResponse<List<EnumItemDTO<int>>> GetToEnumProductCategory();
    }
}

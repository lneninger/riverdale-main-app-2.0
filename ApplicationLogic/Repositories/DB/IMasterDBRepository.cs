using System;
using System.Collections.Generic;
using System.Text;
using ApplicationLogic.Business.Commons.DTOs;

namespace ApplicationLogic.Repositories.DB
{
    public interface IMasterDBRepository
    {
        List<EnumItemDTO<string>> GetToEnumThirdPartyAppType();
    }
}

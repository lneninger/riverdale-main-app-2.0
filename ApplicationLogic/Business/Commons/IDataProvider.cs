using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons
{
    public interface IDataProvider
    {
        List<EnumItemDTO> GetToEnumThirdPartyAppType();
    }
}

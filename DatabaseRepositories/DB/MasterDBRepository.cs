using ApplicationLogic.Business.Commons.DTOs;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FocusRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseRepositories.DB
{
    public class MasterDBRepository : AbstractDBRepository, IMasterDBRepository
    {
        public MasterDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public List<EnumItemDTO<string>> GetToEnumThirdPartyAppType()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<ThirdPartyAppType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name }).ToList();
            }
        }

        public List<EnumItemDTO<string>> GetToEnumProductColorType()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<ProductColorType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "HexCode", masterItem.HexCode }, { "IsBasicCode", masterItem.IsBasicColor } } }).ToList();
            }
        }

        public List<EnumItemDTO<string>> GetToEnumCustomerFreightoutRateType()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<CustomerFreightoutRateType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "Description", masterItem.Description } } }).ToList();
            }
        }
    }
}

using ApplicationLogic.Business.Commons.DTOs;
using ApplicationLogic.Repositories.DB;
using EntityFrameworkCore.DbContextScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons
{
    public class MasterDataProvider: IMasterDataProvider
    {
        public IMasterDBRepository Repository { get; }
        public IDbContextScopeFactory DbContextScopeFactory { get; }

        public MasterDataProvider(IDbContextScopeFactory dbContextScopeFactory, IMasterDBRepository repository)
        {
            this.DbContextScopeFactory = dbContextScopeFactory;
            this.Repository = repository;
        }


        public List<EnumItemDTO<string>> GetToEnumThirdPartyAppType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumThirdPartyAppType();
            }

        }

        public List<EnumItemDTO<string>> GetToEnumProductColorType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumProductColorType();
            }

        }

        public List<EnumItemDTO<string>> GetToEnumCustomerFreightoutRateType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumCustomerFreightoutRateType();
            }
        }


        public List<EnumItemDTO<int>> GetToEnumCustomer()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumCustomer();
            }
        }

        public List<EnumItemDTO<string>> GetToEnumAppUser()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumUser();
            }
        }
    }
}

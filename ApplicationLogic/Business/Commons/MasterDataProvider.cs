using ApplicationLogic.Business.Commons.DTOs;
using ApplicationLogic.Repositories.DB;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
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


        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumThirdPartyAppType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumThirdPartyAppType();
            }

        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductColorType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumProductColorType();
            }

        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumCustomerFreightoutRateType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumCustomerFreightoutRateType();
            }
        }


        public OperationResponse<List<EnumItemDTO<int>>> GetToEnumCustomer()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumCustomer();
            }
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumAppUser()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumUser();
            }
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductType()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetToEnumProductType();
            }
        }
    }
}

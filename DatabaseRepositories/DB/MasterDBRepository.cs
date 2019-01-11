using ApplicationLogic.Business.Commons.DTOs;
using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Identity;
using Framework.Core.Messages;
using DomainModel.Product;
using Microsoft.AspNetCore.Identity;
using DomainModel.SaleOpportunity;

namespace DatabaseRepositories.DB
{
    public class MasterDBRepository : AbstractDBRepository, IMasterDBRepository
    {
        public MasterDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumThirdPartyAppType()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ThirdPartyAppType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting third party", ex);
            }

            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductColorType()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<ProductColorType>().Where(o => !(o.IsDeleted ?? false)).Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "HexCode", masterItem.HexCode }, { "IsBasicCode", masterItem.IsBasicColor } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting third party", ex);
            }
            
            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumCustomerFreightoutRateType()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CustomerFreightoutRateType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "Description", masterItem.Description } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting third party", ex);
            }
            
            return result;
        }

        public OperationResponse<List<EnumItemDTO<int>>> GetToEnumCustomer()
        {
            var result = new OperationResponse<List<EnumItemDTO<int>>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<Customer>().Where(o => o.IsDeleted ?? false == false).Select(masterItem => new EnumItemDTO<int> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "Description", masterItem.Name } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting third party", ex);
            }
            
            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumUser()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
                {
                    result.Bag = dbLocator.Set<AppUser>().Where(o => (o.IsDeleted ?? false) == false).Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.UserName, Extras = new Dictionary<string, object> { { "Email", masterItem.NormalizedEmail }, { "FirstName", masterItem.FirstName }, { "LastName", masterItem.LastName } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting users", ex);
            }
            
            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumProductType()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<ProductType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "Description", masterItem.Description } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting users", ex);
            }
            
            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumRole()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<IdentityDBContext>())
                {
                    result.Bag = dbLocator.Set<IdentityRole>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "NormalizedName", masterItem.NormalizedName } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting users", ex);
            }

            return result;
        }

        public OperationResponse<List<EnumItemDTO<int>>> GetToEnumProducts()
        {
            var result = new OperationResponse<List<EnumItemDTO<int>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<AbstractProduct>().Select(masterItem => new EnumItemDTO<int> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "PictureId", masterItem.ProductMedias.Select(media => media.FileRepositoryId).FirstOrDefault()} } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error geting users", ex);
            }

            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumSeasonCategories()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<SaleSeasonCategoryType>().Select(masterItem => new EnumItemDTO<string> { Key = masterItem.Id, Value = masterItem.Name, Extras = new Dictionary<string, object> { { "Description", masterItem.Description } } }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting season categories", ex);
            }

            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumSeasonCategoriesWithSeasons()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<SaleSeasonCategoryType>().Select(masterItem => new EnumItemDTO<string>
                    {
                        Key = masterItem.Id, Value = masterItem.Name
                        , Extras = new Dictionary<string, object>
                        {
                            { "Description", masterItem.Description }
                            , { "SaleSeasonTypes", masterItem.SaleSeasons.Select(
                                seasonType => new EnumItemDTO<int>
                                {
                                    Key = seasonType.Id
                                    , Value = seasonType.Name
                                    , Extras = new Dictionary<string, object>
                                    {
                                        { "Description", seasonType.Description }
                                    }
                                })
                            }
                        }
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting season categories with season types", ex);
            }

            return result;
        }

        public OperationResponse<List<EnumItemDTO<string>>> GetToEnumGrowerTypesWithGrower()
        {
            var result = new OperationResponse<List<EnumItemDTO<string>>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<GrowerType>().Select(masterItem => new EnumItemDTO<string>
                    {
                        Key = masterItem.Id,
                        Value = masterItem.Name
                        ,
                        Extras = new Dictionary<string, object>
                        {
                            { "Description", masterItem.Description }
                            , { "Growers", masterItem.Growers.Select(
                                seasonType => new EnumItemDTO<int>
                                {
                                    Key = seasonType.Id
                                    , Value = seasonType.Name
                                    , Extras = new Dictionary<string, object>
                                    {
                                        { "CityName", seasonType.Origin.City},
                                        { "CountryName", seasonType.Origin.Country}
                                    }
                                }).ToList()
                            }
                        }
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting season grower types with grower types", ex);
            }

            return result;
        }
    }
}

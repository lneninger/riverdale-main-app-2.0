using ApplicationLogic.Repositories.DB;
using DomainDatabaseMapping;
using DomainModel.Funza;
using EntityFrameworkCore.DbContextScope;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseRepositories.DB
{
    public class FunzaCategoryDBRepository : AbstractDBRepository, IFunzaCategoryReferenceDBRepository
    {
        public FunzaCategoryDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<CategoryReference>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<DomainModel.Funza.CategoryReference>>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<DomainModel.Funza.CategoryReference>().AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all Funza Categories", ex);
            }

            return result;
        }

        

        public OperationResponse<CategoryReference> GetById(int id)
        {
            var result = new OperationResponse<CategoryReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CategoryReference>().Where(o => o.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Category {id}", ex);
            }

            return result;
        }

        public OperationResponse<CategoryReference> GetByFunzaId(int id)
        {
            var result = new OperationResponse<CategoryReference>();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                {
                    result.Bag = dbLocator.Set<CategoryReference>().Where(o => o.FunzaId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting Funza Category {id}", ex);
            }

            return result;
        }

        public OperationResponse Add(CategoryReference entity)
        {
            var result = new OperationResponse();
            try
            {
                var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>();
                dbLocator.Add(entity);
            }
            catch (Exception ex)
            {
                result.AddException($"Error adding Funza Category", ex);
            }

            return result;
            
        }

    }
}

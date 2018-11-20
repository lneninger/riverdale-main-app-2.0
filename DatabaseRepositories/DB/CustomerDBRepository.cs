using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using FocusApplication.Business.Commons.DTOs;
using FocusApplication.Repositories.DB;
using FocusServices.Business.Commands.Customer.DeleteCommand.Models;
using FocusServices.Business.Commands.Customer.GetAllCommand.Models;
using FocusServices.Business.Commands.Customer.GetByIdCommand.Models;
using FocusServices.Business.Commands.Customer.InsertCommand.Models;
using FocusServices.Business.Commands.Customer.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FocusRepositories.DB
{
    public class CustomerDBRepository : AbstractDBRepository<Customer>, ICustomerDBRepository
    {
        public CustomerDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public IEnumerable<CustomerGetAllCommandOutputDTO> GetAll()
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<Customer>().Select(entityItem => new CustomerGetAllCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Name = entityItem.Name,
                    ERPId = entityItem.ERPId,
                }).ToList();
            }
        }

        public CustomerGetByIdCommandOutputDTO GetById(int id)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                return dbLocator.Set<Customer>().Where(o => o.Id == id).Select(entityItem => new CustomerGetByIdCommandOutputDTO
                {
                    Id = entityItem.Id,
                    Name = entityItem.Name,
                    ERPId = entityItem.ERPId
                }).FirstOrDefault();
            }
        }

        public CustomerInsertCommandOutputDTO Insert(CustomerInsertCommandInputDTO input)
        {
            var entity = new Customer
            {
                Name = input.Name,
                ERPId = input.ERPId,
            };

            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var result = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerInsertCommandOutputDTO
                {
                    Id = o.Id,
                    ERPId = o.ERPId
                }).FirstOrDefault();

                return result;
            }

        }

        public CustomerUpdateCommandOutputDTO Update(CustomerUpdateCommandInputDTO input)
        {
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.Name = input.Name;
                    entity.ERPId = input.ERPId;
                }

                dbLocator.SaveChanges();


                var result = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerUpdateCommandOutputDTO
                {
                    Id = o.Id,
                    ERPId = o.ERPId
                }).FirstOrDefault();

                return result;
            }
        }

        public CustomerDeleteCommandOutputDTO Delete(int id)
        {
            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<Customer>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var result = dbLocator.Set<Customer>().Where(o => o.Id == entity.Id).Select(o => new CustomerDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                        ERPId = o.ERPId
                    }).FirstOrDefault();

                    return result;
                }
            }

            return null;
        }

    }
}

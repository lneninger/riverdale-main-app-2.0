using DomainDatabaseMapping;
using DomainModel;
using EntityFrameworkCore.DbContextScope;
using FizzWare.NBuilder;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.File.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.File.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Business.Commands.File.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using LMB.PredicateBuilderExtension;
using Framework.EF.DbContextImpl.Persistance;
using Framework.EF.DbContextImpl.Persistance.Models.Sorting;
using System.Linq.Expressions;
using DomainModel._Commons.Enums;
using Framework.Storage.DataHolders.Messages;
using DomainModel.File;

namespace DatabaseRepositories.DB
{
    public class FileDBRepository : AbstractDBRepository, IFileDBRepository
    {
        public FileDBRepository(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public OperationResponse<IEnumerable<FileGetAllCommandOutputDTO>> GetAll()
        {
            var result = new OperationResponse<IEnumerable<FileGetAllCommandOutputDTO>>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<File>().Select(entityItem => new FileGetAllCommandOutputDTO
                    {
                        Id = entityItem.Id,
                        CreatedAt = entityItem.CreatedAt

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting all", ex);
            }

            return result;
        }

        public OperationResponse<PageResult<FilePageQueryCommandOutputDTO>> PageQuery(PageQuery<FilePageQueryCommandInputDTO> input)
        {
            var result = new OperationResponse<PageResult<FilePageQueryCommandOutputDTO>>();
            try
            {
                // predicate construction
                var predicate = PredicateBuilderExtension.True<File>();
                if (input.CustomFilter != null)
                {
                    var filter = input.CustomFilter;
                    //if (!string.IsNullOrWhiteSpace(filter.Term))
                    //{
                    //    predicate = predicate.And(o => o.Name.Contains(filter.Term, StringComparison.InvariantCultureIgnoreCase));
                    //}
                }

                using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {


                    var query = dbLocator.Set<File>().AsQueryable();


                    var advancedSorting = new List<SortItem<File>>();
                    Expression<Func<File, object>> expression;
                    //if (input.Sort.ContainsKey("erpId"))
                    //{
                    //    expression = o => o.FileThirdPartyAppSettings.Where(third => third.ThirdPartyAppTypeId == ThirdPartyAppTypeEnum.BusinessERP).SingleOrDefault().ThirdPartyFileId;
                    //    advancedSorting.Add(new SortItem<File> { PropertyName = "erpId", SortExpression = expression, SortOrder = "desc" });
                    //}

                    var sorting = new SortingDTO<File>(input.Sort, advancedSorting);

                    result.Bag = query.ProcessPagingSort<File, FilePageQueryCommandOutputDTO>(predicate, input, sorting, o => new FilePageQueryCommandOutputDTO
                    {
                        Id = o.Id,
                        CreatedAt = o.CreatedAt
                    });
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error getting customer page query", ex);
            }

            return result;
        }

        public OperationResponse<FileGetByIdCommandOutputDTO> GetById(int id)
        {
            var result = new OperationResponse<FileGetByIdCommandOutputDTO>();
            try
            {
                using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
                {
                    result.Bag = dbLocator.Set<File>().Where(o => o.Id == id).Select(entityItem => new FileGetByIdCommandOutputDTO
                    {
                        Id = entityItem.Id,
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                result.AddException($"Error Geting User {id}", ex);
            }

            return result;
        }

        public OperationResponse<FileInsertCommandOutputDTO> Insert(FileInsertCommandInputDTO input)
        {
            var result = new OperationResponse<FileInsertCommandOutputDTO>();
            var entity = new File
            {
                RootPath = input.AccessPath,
                AccessPath = input.AccessPath,
                FullFilePath = input.AccessPath,
                RelativePath = input.RelativePath,
                FileName = input.FileName,
                FileSize = input.FileSize,
                ThumbnailFileName = input.ThumbnailFileName
            };

            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                dbLocator.Add(entity);
                dbLocator.SaveChanges();

                var dbResult = dbLocator.Set<File>().Where(o => o.Id == entity.Id).Select(o => new FileInsertCommandOutputDTO
                {
                    Id = o.Id,
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }

        }

        public OperationResponse<FileUpdateCommandOutputDTO> Update(FileUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<FileUpdateCommandOutputDTO>();
            using (var dbLocator = AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<File>().FirstOrDefault(o => o.Id == input.Id);
                if (entity != null)
                {
                    entity.RootPath = input.RootPath ?? entity.RootPath;
                    entity.AccessPath = input.RootPath ?? entity.AccessPath;
                    entity.RelativePath = input.RootPath ?? entity.RelativePath;
                    entity.FileName = input.FileName ?? entity.FileName;
                    entity.FileSize = input.FileSize ?? entity.FileSize;
                    entity.ThumbnailFileName = input.ThumbnailFileName ?? entity.ThumbnailFileName;
                    entity.FileSystemTypeId = input.StorageTypeID ?? entity.FileSystemTypeId;
                }

                dbLocator.SaveChanges();


                var dbResult = dbLocator.Set<File>().Where(o => o.Id == entity.Id).Select(o => new FileUpdateCommandOutputDTO
                {
                    Id = o.Id,
                }).FirstOrDefault();

                result.Bag = dbResult;
                return result;
            }
        }

        public OperationResponse<FileDeleteCommandOutputDTO> Delete(int id)
        {
            var result = new OperationResponse<FileDeleteCommandOutputDTO>();

            using (var dbLocator = this.AmbientDbContextLocator.Get<RiverdaleDBContext>())
            {
                var entity = dbLocator.Set<File>().FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    entity.DeletedAt = DateTime.UtcNow;
                    dbLocator.SaveChanges();

                    var dbResult = dbLocator.Set<File>().Where(o => o.Id == entity.Id).Select(o => new FileDeleteCommandOutputDTO
                    {
                        Id = o.Id,
                    }).FirstOrDefault();

                    result.Bag = dbResult;
                    return result;
                }
            }

            return null;
        }


    }
}

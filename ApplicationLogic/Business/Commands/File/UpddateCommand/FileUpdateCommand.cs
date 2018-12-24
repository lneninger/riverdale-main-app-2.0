using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand
{
    public class FileUpdateCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileUpdateCommand
    {
        public FileUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileUpdateCommandOutputDTO> Execute(FileUpdateCommandInputDTO input)
        {
            var result = new OperationResponse<FileUpdateCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(input.Id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    //getByIdResult.Bag.Name = input.Name;

                    try
                    {
                        dbContextScope.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        result.AddError("Error updating Product Color Type", ex);
                    }

                    getByIdResult = this.Repository.GetById(input.Id);
                    result.AddResponse(getByIdResult);
                    if (result.IsSucceed)
                    {
                        result.Bag = new FileUpdateCommandOutputDTO
                        {
                            Id = getByIdResult.Bag.Id,
                            FileName = getByIdResult.Bag.FileName
                        };
                    }

                }
            }

            return result;
        }
    }
}

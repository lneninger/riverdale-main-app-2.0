using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using Framework.Core.Messages;
using ApplicationLogic.Business.Commands.File.InsertCommand;
using FocusApplication.Business.Commands.FileRepository.FileArguments;
using System.Transactions;
using Framework.Storage.FileStorage.TemporaryStorage;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand
{
    public class ProductMediaInsertCommand : AbstractDBCommand<DomainModel.Product.ProductMedia, IProductMediaDBRepository>, IProductMediaInsertCommand
    {
        public ProductMediaInsertCommand(IFileInsertCommand fileInsertCommand, IDbContextScopeFactory dbContextScopeFactory, IProductMediaDBRepository repository) : base(dbContextScopeFactory, repository)
        {
            this.FileInsertCommand = fileInsertCommand;
        }

        public IFileInsertCommand FileInsertCommand { get; }

        public OperationResponse<ProductMediaInsertCommandOutputDTO> Execute(ProductMediaInsertCommandInputDTO input)
        {
            var result = new OperationResponse<ProductMediaInsertCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                using (var transaction = new TransactionScope())
                {
                    var createFileArgs = this.CreateFileArgs(input);
                    var fileInsertResult = this.FileInsertCommand.Execute<DefaultFileArgs, UploadedFile>(createFileArgs);
                    result.AddResponse(fileInsertResult);

                    if (result.IsSucceed)
                    {
                        var entity = new DomainModel.Product.ProductMedia
                        {
                            ProductId = input.ProductId,
                            FileRepositoryId = fileInsertResult.Bag.Id
                        };

                        try
                        {
                            var insertResult = this.Repository.Insert(entity);
                            dbContextScope.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            result.AddException("Error saving product media", ex);
                        }

                        if (result.IsSucceed)
                        {
                            var getByIdResult = this.Repository.GetById(entity.Id);
                            if (result.IsSucceed)
                            {
                                result.Bag = new ProductMediaInsertCommandOutputDTO
                                {
                                    Id = getByIdResult.Bag.Id
                                };
                            }
                        }
                    }

                    transaction.Complete();
                }
            }

            return result;
        }

        private DefaultFileArgs CreateFileArgs(ProductMediaInsertCommandInputDTO input)
        {
            var result = new DefaultFileArgs(FileAreaEnum.Enum.PRODUCT, nameof(FileAreaEnum.ProductArea.Enum.Media), input);
            return result;
        }
    }
}

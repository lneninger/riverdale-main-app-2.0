using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using Framework.Core.Messages;
using ApplicationLogic.Business.Commands.File.InsertCommand;
using FocusApplication.Business.Commands.FileRepository.FileArguments;

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
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var createFileArgs = this.CreateFileArgs(input);
                this.FileInsertCommand.Execute<DefaultFileArgs>(createFileArgs);

                return this.Repository.Insert(input);
            }
        }

        private DefaultFileArgs CreateFileArgs(ProductMediaInsertCommandInputDTO input)
        {
            var result = new DefaultFileArgs(FileAreaEnum.Enum.PRODUCT, nameof(FileAreaEnum.ProductArea.Enum.Media), input);
            return result;
        }
    }
}

using FocusApplication.Business.Commands.FileRepository.FileArguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models
{
    public class ProductMediaFileArgs: BaseFileArgs<ProductMediaInsertCommandInputDTO>
    {
        public ProductMediaFileArgs(ProductMediaInsertCommandInputDTO input) : base(FileAreaEnum.Enum.PRODUCT, nameof(FileAreaEnum.ProductArea.Enum.Media), input)
        {

        }


        /// <summary>
        /// Gets the file name paths.
        /// </summary>
        /// <returns></returns>
        public override string[] GetFileNameElements()
        {
            this.ValidateFileNameArguments();

            var result = new List<string> { this.FileAreaId, this.FileTypeId };

            if (!string.IsNullOrWhiteSpace(this.LanguageTypeId))
            {
                result.Add(this.LanguageTypeId);
            }

            if (this.UploadedFile.SaveAsGrayscale == true)
            {
                result.Add("grayscale");
            }

            if (!string.IsNullOrWhiteSpace(this.FilePrefix))
            {
                result.Insert(0, this.FilePrefix);
            }

            return result.ToArray();
        }
    }
}

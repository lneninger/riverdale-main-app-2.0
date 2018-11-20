//using Framework.FileStorage.Standard.Models;
using Framework.Storage.DataHolders.Messages;
using Framework.Storage.FileStorage.Models;
using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Business.Commands.FileRepository.FileArguments
{
    public class DefaultFileArgs : FileArgs
    {

        public DefaultFileArgs()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultFileArgs"/> class.
        /// </summary>
        /// <param name="fileAreaId">The file area identifier.</param>
        /// <param name="documentTypeId">The document type identifier.</param>
        /// <param name="languageTypeId">The language type identifier.</param>
        /// <param name="file">The file.</param>
        public DefaultFileArgs(FileAreaEnum.Enum fileAreaId, string documentTypeId, UploadedFile file, string languageTypeId = null, string sourceLocaleLanguageId = null) : base()
        {
            this.FileTypeId = documentTypeId;
            this.FileAreaId = fileAreaId.ToString();
            this.LanguageTypeId = languageTypeId?.Trim();
            this.UploadedFile = file;
            this.SourceLocaleLanguageId = sourceLocaleLanguageId?.Trim();
        }

        /// <summary>
        /// Gets the relative path elements.
        /// </summary>
        /// <returns></returns>
        public override string[] GetRelativePathElements()
        {
            this.ValidateRelativePathArguments();

            var result = new List<string> { this.FileAreaId, this.FileTypeId };

            if (!string.IsNullOrWhiteSpace(this.LanguageTypeId))
            {
                result.Add(this.LanguageTypeId);
            }

            return result.ToArray();
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

            if (!string.IsNullOrWhiteSpace(this.FilePrefix))
            {
                result.Insert(0, this.FilePrefix);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Validates the file name arguments.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OperationResponseException"></exception>
        protected override OperationResponse ValidateFileNameArguments()
        {
            var result = new OperationResponse();

            if (string.IsNullOrWhiteSpace(this.FileAreaId))
            {
                result.AddError($"Area Element on FileNamePaths can not be null");
            }

            if (string.IsNullOrWhiteSpace(this.FileTypeId))
            {
                result.AddError($"Document Element on FileNamePaths can not be null");
            }

            //if (string.IsNullOrWhiteSpace(this.LanguageTypeId))
            //{
            //    result.AddError($"Language Element on FileNamePaths can not be null");
            //}

            if (this.LanguageTypeId != null && this.LanguageTypeId.Length != 2)
            {
                result.AddError($"Language Element on RelativePaths must be a valid Language ID");
            }

            if (!result.IsSucceed)
            {
                throw new OperationResponseException(result);
            }

            return result;
        }

        /// <summary>
        /// Validates the relative path arguments.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OperationResponseException"></exception>
        protected override OperationResponse ValidateRelativePathArguments()
        {
            var result = new OperationResponse();

            if (string.IsNullOrWhiteSpace(this.FileAreaId))
            {
                result.AddError($"Area Element on RelativePaths can not be null");
            }

            if (string.IsNullOrWhiteSpace(this.FileTypeId))
            {
                result.AddError($"Document Element on RelativePaths can not be null");
            }

            if (this.LanguageTypeId != null && this.LanguageTypeId.Length != 2)
            {
                result.AddError($"Language Element on RelativePaths must be a valid Language ID");
            }

            if (!result.IsSucceed)
            {
                throw new OperationResponseException(result);
            }

            return result;
        }

    }
}

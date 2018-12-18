//using Framework.FileStorage.Standard.Models;
using Framework.Core.Messages;
using Framework.Storage.FileStorage.Models;
using Framework.Storage.FileStorage.TemporaryStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Business.Commands.FileRepository.FileArguments
{
    public class PersonFileArgs : DefaultFileArgs
    {
        public PersonFileArgs(FileAreaEnum.PersonArea.Enum fileType, UploadedFile file, string languageId, string languageLocaleId): base(FileAreaEnum.Enum.PERSON, fileType.ToString(), file, languageId, languageLocaleId)
        {

        }

        public override string[] GetFileNameElements()
        {
            var result = base.GetFileNameElements();
            return result;
        }

        public override string[] GetRelativePathElements()
        {
            var result = base.GetFileNameElements();
            return result;
        }

        protected override OperationResponse ValidateFileNameArguments()
        {
            var result = base.ValidateFileNameArguments();

            return result;
        }

        protected override OperationResponse ValidateRelativePathArguments()
        {
            var result = base.ValidateFileNameArguments();

            return result;
        }
    }
}

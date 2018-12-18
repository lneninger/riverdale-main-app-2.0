using Framework.Core.Messages;
using Framework.Storage.FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusApplication.Business.Commands.FileRepository.FileArguments
{
    public class CompanyFileArgs : FileArgs
    {
        public override string[] GetFileNameElements()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRelativePathElements()
        {
            throw new NotImplementedException();
        }

        protected override OperationResponse ValidateFileNameArguments()
        {
            throw new NotImplementedException();
        }

        protected override OperationResponse ValidateRelativePathArguments()
        {
            throw new NotImplementedException();
        }
    }
}

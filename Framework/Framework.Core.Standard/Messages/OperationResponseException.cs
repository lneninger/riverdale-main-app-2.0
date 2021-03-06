﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Storage.DataHolders.Messages
{
    public class OperationResponseException : Exception
    {
        public OperationResponseException(OperationResponse operationResponse)
        {
            this.OperationResponse = operationResponse;
            if (this.OperationResponse != null && this.OperationResponse.Messages != null)
            {
                var messageStringList = operationResponse.Messages.Select(message => $"{nameof(message.MessageType)}: {message.Message}");
                this.Data["Messages"] = string.Join(Environment.NewLine, messageStringList);
            }
        }

        public OperationResponse OperationResponse { get; }

    }
}

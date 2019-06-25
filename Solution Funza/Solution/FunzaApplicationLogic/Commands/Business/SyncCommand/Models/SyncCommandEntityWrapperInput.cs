using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaApplicationLogic.Commands.Business.SyncCommand.Models
{
    public class SyncCommandEntityWrapperInput<T>
    {
        public Guid IntegrationId { get; set; }
        public IEnumerable<T> SyncItems { get; set; }
    }
}

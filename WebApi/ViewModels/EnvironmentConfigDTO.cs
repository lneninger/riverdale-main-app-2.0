using ApplicationLogic.AppSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverdaleMainApp2_0.ViewModels
{
    public class EnvironmentConfigDTO
    {
        public string Environment { get; set; }
        public FunzaSettings FunzaSettings { get; set; }
        public string ConnectionString { get; internal set; }
    }
}

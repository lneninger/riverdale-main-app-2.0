using ApplicationLogic.Business.Commons.Funza.DTOs;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models
{
    public class FunzaQuoteGetItemsCommandFunzaInputDTO : FunzaPageQuery
    {
        public string Nombre { get; set; }
    }
}

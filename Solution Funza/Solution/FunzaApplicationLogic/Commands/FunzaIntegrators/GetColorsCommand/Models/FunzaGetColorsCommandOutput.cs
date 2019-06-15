using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand.Models
{
    public class FunzaGetColorsCommandOutput : BaseFilter
    {
        public string CreatedBy { get; internal set; }
        public string Hex { get; internal set; }
        public string IdColor { get; internal set; }
        public string CreatedDate { get; internal set; }
        public string Img { get; internal set; }
        public string Nombre { get; internal set; }
        public string NombreIngles { get; internal set; }
        public string Estado { get; internal set; }
        public string UpdatedBy { get; internal set; }
        public string UpdatedDate { get; internal set; }
        public string Version { get; internal set; }
    }
}
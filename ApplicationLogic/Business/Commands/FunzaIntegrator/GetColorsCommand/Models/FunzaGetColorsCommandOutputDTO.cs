using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand.Models
{
    public class FunzaGetColorsCommandOutputDTO
    {
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string IdColor { get; set; }
        public string Nombre { get; set; }
        public string NombreIngles { get; set; }
        public string Estado { get; set; }
        public string Version { get; set; }
        public string Hex { get; set; }
        public string Img { get; set; }
    }
}
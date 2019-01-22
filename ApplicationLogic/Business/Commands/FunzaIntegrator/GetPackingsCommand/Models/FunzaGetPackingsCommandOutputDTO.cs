using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand.Models
{
    public class FunzaGetPackingsCommandOutputDTO
    {
        public int Id { get; set; }
        public int FunzaId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string IdEmpaque { get; set; }
        public string Nombre { get; set; }
        public string NombreIngles { get; set; }
        public string Descripcion { get; set; }
        public decimal EquivalentesFull { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public decimal Volumen { get; set; }
        public decimal Peso { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public string CodigoCargoMaster { get; set; }
        public string DescripcionVolumen { get; set; }
        public decimal VolumneEquivalenteFull { get; set; }
        public bool? EviarACotizador { get; set; }
        public string EquivalenteFullCotizador { get; set; }
        //public string[] CargosFacturaDefinitiva { get; set; }
        //public string[] ItemsFacturaDefinitiva { get; set; }
        //public string[] ItemsNota { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models
{
    public class PackingsUpdateCommandInput
    {
        public int Id { get; set; }

        public int FunzaId { get; set; }
        public Guid IntegrationId { get; set; }
        public string FunzaCreatedBy { get; set; }
        public DateTime FunzaCreatedDate { get; set; }
        public string FunzaUpdatedBy { get; set; }
        public DateTime? FunzaUpdatedDate { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public string Description { get; set; }
        public decimal EquivalentsFull { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public string CargoMasterCode { get; set; }
        public string VolumeDescription { get; set; }
        public decimal VolumeEquivalentFull { get; set; }
        public bool? SentToQuotator { get; set; }
        public string EquivalentFullQuotator { get; set; }
        public string[] DefinitiveInvoiceCargo { get; set; }
        public string[] DefinitiveInvoiceItems { get; set; }
        public string[] NoteItems{ get; set; }
    }
}
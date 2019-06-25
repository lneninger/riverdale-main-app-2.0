using Framework.EF.DbContextImpl.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Quote : AbstractBaseEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int FunzaId { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public string AdjustRequestUserId { get; set; }

        public int CreateStep { get; set; }

        public string Code { get; set; }

        public decimal PackingPrice { get; set; }

        public int PackingId { get; set; }

        public int PackingPriceId { get; set; }

        public decimal PackingDescount { get; set; }

        public decimal LaborDiscount { get; set; }

        public int PackingName { get; set; }

        public int ComboId { get; set; }

        public int Quotes { get; set; }

        public int Orders { get; set; }

        public int SatelliteQuoteId { get; set; }

        public int SatelliteQuote { get; set; }

        public int SatelliteQuotes { get; set; }

        public int QuoteAdjustments { get; set; }

        public decimal Margen { get; set; }

        public int NoBouquets { get; set; }

        public decimal StartingPrice { get; set; }

        public decimal PricePerBouquet { get; set; }

        public string Comments { get; set; }

        public string CreatedByUserName { get; set; }

        public string LastModifierUserName { get; set; }

        public decimal ConfirmationPriceLabor { get; set; }

        public decimal ConfirmationPackingPrice { get; set; }

        public decimal TotalCost { get; set; }

        public decimal FinalPrice { get; set; }

        public DateTime LastModificationTime { get; set; }

        public int LastModifierUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public int CreatorUserId { get; set; }
    }
}

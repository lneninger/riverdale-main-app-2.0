namespace DomainModel.SaleOpportunity
{
    public class SaleOpportunitySettings
    {
        public int Id { get; set; }

        public int SaleOpportunityId { get; set; }
        public virtual SaleOpportunity SaleOpportunity { get; set; }

        public bool Delivered { get; set; }
    }
}
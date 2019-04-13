namespace DomainModel.Product
{
    public class ProductCategorySize : AbstractBaseEntity
    {
        public ProductCategorySize(): base()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}